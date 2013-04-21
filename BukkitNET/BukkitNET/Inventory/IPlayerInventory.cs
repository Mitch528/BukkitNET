using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Inventory
{
    public interface IPlayerInventory : IInventory
    {

        ItemStack[] GetArmorContents();

        ItemStack GetHelmet();

        ItemStack GetChestplate();

        ItemStack GetLeggings();

        ItemStack GetBoots();

        void SetArmorContents(ItemStack[] items);

        void SetHelmet(ItemStack helmet);

        void SetChestplate(ItemStack chestplate);

        void SetLeggings(ItemStack leggings);

        void SetBoots(ItemStack boots);

        ItemStack GetItemInHand();

        void SetItemInHand(ItemStack stack);

        int GetHeldItemSlot();

        void SetHeldItemSloS(int slot);

        int Clear(int id, int data);

        IHumanEntity GetHolder();

    }
}
