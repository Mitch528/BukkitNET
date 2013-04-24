using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    class RedstoneTorch : Torch, IRedstone
    {

        public RedstoneTorch()
            : base(Material.RedstoneTorchOn)
        {
        }

        public bool IsPowered()
        {
            return ItemType == Material.RedstoneTorchOn;
        }

        public override string ToString()
        {
            return base.ToString() + " " + (IsPowered() ? "" : "NOT ") + "POWERED";
        }

    }
}
