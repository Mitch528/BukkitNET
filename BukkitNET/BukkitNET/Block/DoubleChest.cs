using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;

namespace BukkitNET.Block
{
    public class DoubleChest : IInventoryHolder
    {

        private IDoubleChestInventory inventory;

        public DoubleChest(IDoubleChestInventory chest)
        {
            inventory = chest;
        }

        public IInventoryHolder LeftSide
        {
            get
            {
                return (IInventoryHolder)inventory.GetLeftSide().GetHolder();
            }
        }

        public IInventoryHolder RightSide
        {
            get
            {
                return (IInventoryHolder)inventory.GetRightSide().GetHolder();
            }
        }

        public IWorld World
        {
            get
            {
                return ((IChest)LeftSide).GetWorld();
            }
        }

        public double X
        {
            get
            {
                return 0.5 * (((IChest)LeftSide).GetX() + ((IChest)RightSide).GetX());
            }
        }

        public double Y
        {
            get
            {
                return 0.5 * (((IChest)LeftSide).GetY() + ((IChest)RightSide).GetY());
            }
        }

        public double Z
        {
            get
            {
                return 0.5 * (((IChest)LeftSide)).GetZ() + ((IChest)RightSide).GetZ());
            }
        }

        public Location Location
        {
            get
            {
                return new Location(World, X, Y, Z);
            }
        }

        public IInventory GetInventory()
        {
            return inventory;
        }

    }
}
