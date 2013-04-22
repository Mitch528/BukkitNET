using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory
{
    public interface IFurnaceInventory : IInventory
    {

        ItemStack GetResult();

        ItemStack GetFuel();

        ItemStack GetSmelting();

        void SetFuel(ItemStack stack);

        void SetResult(ItemStack stack);

        void SetSmelting(ItemStack stack);

        Furnace GetHolder();

    }
}
