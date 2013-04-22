﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;

namespace BukkitNET.Block
{
    public interface IDropper : IBlockState, IInventoryHolder
    {

        void Drop();

    }
}
