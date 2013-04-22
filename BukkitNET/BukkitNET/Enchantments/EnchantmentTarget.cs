using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;

namespace BukkitNET.Enchantments
{

    public enum EnchantmentTarget
    {

        All,
        Armor,
        ArmorFeet,
        ArmorLegs,
        ArmorTorso,
        ArmorHead,
        Weapon,
        Tool,
        Bow

    }

    public static class EnchantmentTargetExtensions
    {

        public static bool Includes(this EnchantmentTarget target, ItemStack iStack)
        {
            return Includes(target, iStack.GetMaterialType());
        }

        public static bool Includes(this EnchantmentTarget target, Material item)
        {

            switch (target)
            {

                case EnchantmentTarget.All:

                    return true;

                case EnchantmentTarget.Armor:

                    return (EnchantmentTarget.ArmorFeet.Includes(item) || EnchantmentTarget.ArmorLegs.Includes(item) || EnchantmentTarget.ArmorHead.Includes(item)
                        || EnchantmentTarget.ArmorTorso.Includes(item));

                case EnchantmentTarget.ArmorFeet:

                    return (item.Equals(Material.LeatherBoots) || item.Equals(Material.ChainmailBoots) || item.Equals(Material.IronBoots) || item.Equals(Material.DiamondBoots)
                        || item.Equals(Material.GoldBoots));

                case EnchantmentTarget.ArmorLegs:

                    return (item.Equals(Material.LeatherLeggings) || item.Equals(Material.ChaimailLeggings) || item.Equals(Material.IronLeggings) || item.Equals(Material.DiamondLeggings)
                        || item.Equals(Material.GoldLeggings));

                case EnchantmentTarget.ArmorTorso:

                    return (item.Equals(Material.LeatherChestplate) || item.Equals(Material.ChainmailChestplate) || item.Equals(Material.IronChestplate) || item.Equals(Material.DiamondChestplate)
                        || item.Equals(Material.GoldChestplate));

                case EnchantmentTarget.ArmorHead:

                    return (item.Equals(Material.LeatherHelmet) || item.Equals(Material.ChainmailHelmet) || item.Equals(Material.DiamondHelmet) || item.Equals(Material.IronHelmet)
                        || item.Equals(Material.GoldHelmet));

                case EnchantmentTarget.Weapon:

                    return (item.Equals(Material.WoodSword) || item.Equals(Material.StoneSword) || item.Equals(Material.IronSword) || item.Equals(Material.DiamondSword)
                        || item.Equals(Material.GoldSword));

                case EnchantmentTarget.Tool:

                    return (item.Equals(Material.WoodSpade) || item.Equals(Material.StoneSpade) || item.Equals(Material.IronSpade) || item.Equals(Material.DiamondSpade)
                        || item.Equals(Material.GoldSpade) || item.Equals(Material.WoodPickaxe) ||  item.Equals(Material.StonePickaxe) || item.Equals(Material.IronPickaxe) 
                        || item.Equals(Material.DiamondPickaxe) || item.Equals(Material.GoldPickaxe) || item.Equals(Material.WoodHoe) || item.Equals(Material.StoneHoe)
                        || item.Equals(Material.IronHoe) || item.Equals(Material.DiamondHoe) || item.Equals(Material.GoldHoe) || item.Equals(Material.WoodAxe)
                        || item.Equals(Material.StoneAxe) || item.Equals(Material.IronAxe) || item.Equals(Material.DiamondAxe) || item.Equals(Material.GoldAxe)
                        || item.Equals(Material.Shears) || item.Equals(Material.FishingRod) || item.Equals(Material.FlintAndSteel)));

                case EnchantmentTarget.Bow:

                    return item.Equals(Material.Bow);

                default:

                    return false;

            }

        }

    }

}
