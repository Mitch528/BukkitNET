using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory
{
    public interface IDoubleChestInventory
    {

        IInventory GetLeftSide();

        IInventory GetRightSide();

        DoubleChest GetHolder();

    }
}
