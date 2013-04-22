using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;

namespace BukkitNET.Block
{
    public interface IFurnace : IBlockState, IContainerBlock
    {

        short GetBurnTime();

        void SetBurntime(short burnTime);

        short GetCookTime();

        void SetCookTime(short cookTime);

        IFurnaceInventory GetInventory();

    }
}
