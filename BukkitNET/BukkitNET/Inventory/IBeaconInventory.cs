﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory
{
    public interface IBeaconInventory
    {

        void SetItem(ItemStack item);

        ItemStack GetItem();

    }
}
