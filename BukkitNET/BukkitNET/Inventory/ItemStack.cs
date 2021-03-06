﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BukkitNET.Configuration.Serialization;
using BukkitNET.Enchantments;
using BukkitNET.Inventory.Meta;
using BukkitNET.Materials;

namespace BukkitNET.Inventory
{
    public class ItemStack : IConfigurationSerializable
    {

        private int type = 0;
        private int amount = 0;
        private MaterialData data = null;
        private short durability = 0;
        private IItemMeta meta;

        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }
        }

        public bool HasItemMeta
        {
            get
            {
                return !Bukkit.ItemFactory.Equals(meta, null);
            }
        }

        public MaterialData Data
        {
            get
            {
                Material mat = GetMaterialType();
                if (data == null && mat != null && mat.GetData() != null)
                {
                    data = mat.GetNewData((byte)durability);
                }

                return data;
            }
            set
            {

                Material mat = GetMaterialType();

                if (data == null || mat == null || mat.GetData() == null)
                {
                    this.data = data;
                }
                else
                {
                    if ((data.ItemType.GetData() == mat.GetData()) || (data.GetType() == typeof(MaterialData)))
                    {
                        this.data = data;
                    }
                    else
                    {
                        throw new ArgumentException("Provided data is not of type " + mat.GetData().Name + ", found " + data.GetType().Name);
                    }
                }

            }
        }

        public short Durability
        {
            get
            {
                return durability;
            }
            set
            {
                durability = value;
            }
        }

        public int MaxStackSize
        {
            get
            {
                Material material = GetMaterialType();
                if (material != null)
                {
                    return material.MaxStackSize;
                }
                return -1;
            }
        }

        public IItemMeta ItemMeta
        {
            get
            {
                return this.meta == null ? Bukkit.ItemFactory.GetItemMeta(GetType0()) : meta;
            }
            set
            {
                meta = value;
            }
        }

        protected ItemStack() { }

        public ItemStack(int type)
            : this(type, 1)
        {
        }

        public ItemStack(Material type)
            : this(type, 1)
        {
        }

        public ItemStack(int type, int amount)
            : this(type, amount, (short)0)
        {
        }

        public ItemStack(Material type, int amount)
            : this(type.GetId(), amount)
        {
        }

        public ItemStack(int type, int amount, short damage)
        {
            this.type = type;
            this.amount = amount;
            this.durability = damage;
        }

        public ItemStack(Material type, int amount, short damage)
            : this(type.GetId(), amount, damage)
        {
        }

        public ItemStack(ItemStack stack)
        {
            Debug.Assert(stack != null, "Cannot copy null stack");
            this.type = stack.TypeId;
            this.amount = stack.Amount;
            this.durability = stack.Durability;
            this.data = stack.Data;
            if (stack.HasItemMeta)
            {
                SetItemMeta0(stack.ItemMeta, GetType0());
            }
        }

        public Material GetMaterialType()
        {
            return GetType0(GetTypeId());
        }

        private Material GetType0()
        {
            return GetType0(this.type);
        }

        private static Material GetType0(int id)
        {
            Material material = Material.GetMaterial(id);
            return material == null ? Material.AIR : material;
        }

        public void SetType(Material type)
        {
            Debug.Assert(type != null, "Material cannot be null");
            SetTypeId(type.GetId());
        }

        public void SetTypeId(int type)
        {
            this.type = type;
            if (this.meta != null)
            {
                this.meta = Bukkit.ItemFactory.asMetaFor(meta, GetType0());
            }
            CreateData((byte)0);
        }

        private void CreateData(byte data)
        {
            Material mat = MaterialHelper.GetMaterial(type);

            if (mat == default(Material))
            {
                this.data = new MaterialData(type, data);
            }
            else
            {
                this.data = mat.GetNewData(data);
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder("ItemStack{").Append(typeof(ItemStack).Name).Append(" x ").Append(amount);
            if (HasItemMeta)
            {
                toString.Append(", ").Append(ItemMeta);
            }
            return toString.Append('}').ToString();
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (!(obj is ItemStack))
            {
                return false;
            }

            ItemStack stack = (ItemStack)obj;
            return amount == stack.Amount && IsSimilar(stack);
        }

        public bool IsSimilar(ItemStack stack)
        {
            if (stack == null)
            {
                return false;
            }
            if (stack == this)
            {
                return true;
            }
            return type == stack.Type && durability == stack.Durability && HasItemMeta == stack.HasItemMeta && (HasItemMeta ? Bukkit.ItemFactory.Equals(ItemMeta, stack.ItemMeta) : true);
        }

        public ItemStack Clone()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {

            int hash = 1;

            hash = hash * 31 + type;
            hash = hash * 31 + amount;
            hash = hash * 31 + (durability & 0xffff);
            hash = hash * 31 + (HasItemMeta ? (meta == null ? ItemMeta.GetHashCode() : meta.GetHashCode()) : 0);

            return hash;
        }

        public bool ContainsEnchantment(Enchantment ench)
        {
            return meta == null ? false : meta.HasEnchant(ench);
        }

        public int GetEnchantmentLevel(Enchantment ench)
        {
            return meta == null ? 0 : meta.GetEnchantLevel(ench);
        }

        public Dictionary<Enchantment, int> GetEnchantments()
        {
            return meta == null ? new Dictionary<Enchantment, int>() : meta.GetEnchants();
        }

        public void AddEnchantments(Dictionary<Enchantment, int> enchantments)
        {
            Debug.Assert(enchantments != null, "Enchantments cannot be null");
            foreach (var entry in enchantments)
            {
                AddEnchantment(entry.Key, entry.Value);
            }
        }

        public void AddEnchantment(Enchantment ench, int level)
        {
            Debug.Assert(ench != null, "Enchantment cannot be null");
            if ((level < ench.GetStartLevel()) || (level > ench.GetMaxLevel()))
            {
                throw new ArgumentException("Enchantment level is either too low or too high (given " + level + ", bounds are " + ench.GetStartLevel() + " to " + ench.GetMaxLevel());
            }
            else if (!ench.CanEnchantItem(this))
            {
                throw new ArgumentException("Specified enchantment cannot be applied to this itemstack");
            }

            AddUnsafeEnchantment(ench, level);
        }

        public void AddUnsafeEnchantments(Dictionary<Enchantment, int> enchantments)
        {
            foreach (var entry in enchantments)
            {
                AddUnsafeEnchantment(entry.Key, entry.Value);
            }
        }

        public void AddUnsafeEnchantment(Enchantment ench, int level)
        {
            (meta == null ? meta = Bukkit.ItemFactory.GetItemMeta(GetType0()) : meta).AddEnchant(ench, level, true);
        }

        public int RemoveEnchantment(Enchantment ench)
        {
            int level = GetEnchantmentLevel(ench);
            if (level == 0 || meta == null)
            {
                return level;
            }
            meta.RemoveEnchant(ench);
            return level;
        }

        public Dictionary<string, object> Serialize()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            result.Add("type", GetMaterialType().GetName());

            if (durability != 0)
            {
                result.Add("damage", durability);
            }

            if (amount != 1)
            {
                result.Add("amount", amount);
            }

            if (!Bukkit.ItemFactory.Equals(meta, null))
            {
                result.Add("meta", meta);
            }

            return result;
        }

        public static ItemStack Deserialize(Dictionary<string, object> args)
        {
            Material type = MaterialHelper.GetMaterial((string)args["type"]);
            short damage = 0;
            int amount = 1;

            if (args.ContainsKey("damage"))
            {
                damage = (short)((int)args["damage"]);
            }

            if (args.ContainsKey("amount"))
            {
                amount = (int)args["amount"];
            }

            ItemStack result = new ItemStack(type, amount, damage);

            if (args.ContainsKey("enchantments"))
            {
                object raw = args["enchantments"];

                var ints = raw as Dictionary<string, int>;
                if (ints != null)
                {
                    Dictionary<string, int> map = ints;

                    foreach (var entry in map)
                    {
                        Enchantment enchantment = Enchantment.GetByName(entry.Key);

                        if (enchantment != null)
                        {
                            result.AddUnsafeEnchantment(enchantment, entry.Value);
                        }
                    }
                }
            }
            else if (args.ContainsKey("meta"))
            {
                object raw = args["meta"];
                var itemMeta = raw as IItemMeta;
                if (itemMeta != null)
                {
                    result.ItemMeta = itemMeta;
                }
            }

            return result;
        }

        public bool SetItemMeta(IItemMeta itemMeta)
        {
            return SetItemMeta0(itemMeta, GetType0());
        }

        private bool SetItemMeta0(IItemMeta itemMeta, Material material)
        {
            if (itemMeta == null)
            {
                this.meta = null;
                return true;
            }
            if (!Bukkit.ItemFactory.IsApplicable(itemMeta, material))
            {
                return false;
            }
            this.meta = Bukkit.ItemFactory.AsMetaFor(itemMeta, material);
            if (this.meta == itemMeta)
            {
                this.meta = itemMeta.Clone();
            }

            return true;
        }

    }
}
