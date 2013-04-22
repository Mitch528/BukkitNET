using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Inventory
{
    public interface IEntityEquipment
    {

        ItemStack GetItemInHand();

        void SetItemInHand(ItemStack stack);

        ItemStack GetHelmet();

        void SetHelmet(ItemStack helmet);

        ItemStack GetChestplate();

        void SetChestplate(ItemStack chestplate);

        ItemStack GetLeggings();

        void SetLeggings(ItemStack leggings);

        ItemStack GetBoots();

        void SetBoots(ItemStack boots);

        ItemStack[] GetArmorContents();

        void SetArmorContents(ItemStack[] items);

        void Clear();

        float GetItemInHandDropChance();

        void SetItemInHandDropChance(float chance);

        float GetHelmetDropChance();

        void SetHelmetDropChance(float chance);

        float GetChestplateDropChance();

        void SetChestplateDropChance(float chance);

        float GetLeggingsDropChance();

        void SetLeggingsDropChance(float chance);

        float GetBootsDropChance();

        void SetBootsDropChance(float chance);

        IEntity GetHolder();

    }
}
