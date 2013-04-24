using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class RedstoneWire : MaterialData, IRedstone
    {


        public RedstoneWire()
            : base(Material.RedstoneWire)
        {
        }

        public RedstoneWire(int type) : base(type)
        {
        }

        public RedstoneWire(Material type) : base(type)
        {
        }

        public RedstoneWire(int type, byte data) : base(type, data)
        {
        }

        public RedstoneWire(Material type, byte data) : base(type, data)
        {
        }

        public bool IsPowered()
        {
            return Data > 0;
        }

        public override string ToString()
        {
            return base.ToString() + " " + (IsPowered() ? "" : "NOT ") + "POWERED";
        }
    }
}
