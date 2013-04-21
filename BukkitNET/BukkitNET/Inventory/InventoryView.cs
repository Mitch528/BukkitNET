using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Entities;
using BukkitNET.Events.InventoryEvents;

namespace BukkitNET.Inventory
{
    public abstract class InventoryView
    {

        public const int OUTSIDE = -999;

        public enum Property
        {

            [InventoryPropertyInfo(0, InventoryType.Brewing)]
            BrewTime,

            [InventoryPropertyInfo(0, InventoryType.Furnace)]
            CookTime,

            [InventoryPropertyInfo(1, InventoryType.Furnace)]
            BurnTime,

            [InventoryPropertyInfo(2, InventoryType.Furnace)]
            TicksForCurrentFuel,

            [InventoryPropertyInfo(0, InventoryType.Enchanting)]
            EnchantButton1,

            [InventoryPropertyInfo(1, InventoryType.Enchanting)]
            EnchantButton2,

            [InventoryPropertyInfo(2, InventoryType.Enchanting)]
            EnchantButton3

        }

        public abstract IInventory GetTopInventory();

        public abstract IInventory GetBottomInventory();

        public abstract IHumanEntity GetPlayer();

        public abstract InventoryType GetInventoryType();

        public void SetItem(int slot, ItemStack item)
        {
            if (slot != OUTSIDE)
            {
                if (slot < GetTopInventory().GetSize())
                {
                    GetTopInventory().SetItem(ConvertSlot(slot), item);
                }
                else
                {
                    GetBottomInventory().SetItem(ConvertSlot(slot), item);
                }
            }
            else
            {
                GetPlayer().GetWorld().DropItemNaturally(GetPlayer().GetLocation(), item);
            }
        }

        public ItemStack GetItem(int slot)
        {
            if (slot == OUTSIDE)
            {
                return null;
            }
            if (slot < GetTopInventory().GetSize())
            {
                return GetTopInventory().GetItem(ConvertSlot(slot));
            }
            else
            {
                return GetBottomInventory().GetItem(ConvertSlot(slot));
            }
        }

        public void SetCursor(ItemStack item)
        {
            GetPlayer().SetItemOnCursor(item);
        }

        public ItemStack GetCursor()
        {
            return GetPlayer().GetItemOnCursor();
        }

        public int ConvertSlot(int rawSlot)
        {
            int numInTop = GetTopInventory().GetSize();
            if (rawSlot < numInTop)
            {
                return rawSlot;
            }
            int slot = rawSlot - numInTop;
            if (GetInventoryType() == InventoryType.Crafting)
            {
                if (slot < 4) return 39 - slot;
                else slot -= 4;
            }
            if (slot >= 27) slot -= 27;
            else slot += 9;
            return slot;
        }

        public void Close()
        {
            GetPlayer().CloseInventory();
        }

        public int CountSlots()
        {
            return GetTopInventory().GetSize() + GetBottomInventory().GetSize();
        }

        public bool SetProperty(Property prop, int value)
        {
            return GetPlayer().SetWindowProperty(prop, value);
        }

        public string GetTitle()
        {
            return GetTopInventory().GetTitle();
        }

    }
}
