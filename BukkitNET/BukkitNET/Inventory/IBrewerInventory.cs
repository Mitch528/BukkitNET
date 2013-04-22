using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory
{
    public interface IBrewerInventory : IInventory
    {

        ItemStack GetIngredient();

        void SetIngredient(ItemStack ingredient);

        BrewingStand GetHolder();

    }
}
