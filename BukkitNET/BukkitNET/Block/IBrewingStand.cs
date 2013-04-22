using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;

namespace BukkitNET.Block
{
    public interface IBrewingStand : IBlockState, IContainerBlock
    {

        int GetBrewingTime();

        void SetBrewingTime(int brewTime);

        IBrewerInventory GetInventory();

    }
}
