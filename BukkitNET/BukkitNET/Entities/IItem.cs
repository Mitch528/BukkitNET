using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;

namespace BukkitNET.Entities
{
    public interface IItem
    {

        ItemStack GetItemStack();

        void SetItemStack(ItemStack stack);

        int GetPickupDelay();

        void SetPickupDelay(int delay);

    }
}
