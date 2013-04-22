using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory.Meta
{
    public interface IRepairable
    {

        bool HasRepairCost();

        int GetRepairCost();

        void SetRepairCost(int cost);

        IRepairable Clone();

    }
}
