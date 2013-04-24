using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class PoweredRail : ExtendedRails, IRedstone
    {

        public PoweredRail()
            : base(Material.PoweredRail)
        {
        }

        public bool IsPowered()
        {
            return (Data & 0x8) == 0x8;
        }

        public void SetPowered(bool isPowered)
        {
            Data = ((byte)(isPowered ? (Data | 0x8) : (Data & ~0x8)));
        }

    }
}
