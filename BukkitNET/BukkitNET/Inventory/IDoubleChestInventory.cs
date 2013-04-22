using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Inventory
{
    public interface IDoubleChestInventory : IInventory
    {

        IInventory GetLeftSide();

        IInventory GetRightSide();

        new DoubleChest GetHolder();

    }
}
