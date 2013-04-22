using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory
{
    public interface ICraftingInventory : IInventory
    {

        ItemStack GetResult();

        ItemStack[] GetMatrix();

        void SetResult(ItemStack newResult);

        void SetMatrix(ItemStack[] contents);

        IRecipe GetRecipe();

    }
}
