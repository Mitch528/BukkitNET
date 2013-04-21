using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;
using BukkitNET.Permissions;

namespace BukkitNET.Entities
{
    public interface IHumanEntity : ILivingEntity, IAnimalTamer, IPermissible, IInventoryHolder
    {

        IPlayerInventory GetInventory();

        IInventory GetEnderChest();

        bool SetWindowProperty(InventoryView.Property prop, int value);

        InventoryView GetOpenInventory();

        InventoryView OpenInventory(IInventory inventory);

        InventoryView OpenWorkbench(Location location, bool force);

        InventoryView OpenEnchanting(Location location, bool force);

        void OpenInventory(InventoryView inventory);

        void CloseInventory();

        ItemStack GetItemInHand();

        void SetItemInHand(ItemStack item);

        ItemStack GetItemOnCursor();

        void SetItemOnCursor(ItemStack item);

        bool IsSleeping();

        int GetSleepTicks();

        GameMode GetGameMode();

        void SetGameMode(GameMode mode);

        bool IsBlocking();

        int GetExpToLevel();

    }
}
