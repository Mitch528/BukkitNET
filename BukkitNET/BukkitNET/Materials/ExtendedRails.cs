using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class ExtendedRails : Rails
    {

        public ExtendedRails(int type)
            : base(type)
        {
        }

        public ExtendedRails(Material type)
            : base(type)
        {
        }

        public ExtendedRails(int type, byte data)
            : base(type, data)
        {
        }

        public ExtendedRails(Material type, byte data)
            : base(type, data)
        {
        }

        public new virtual bool IsCurve
        {
            get
            {
                return false;
            }
        }

        protected virtual new byte GetConvertedData()
        {
            return (byte)(Data & 0x7);
        }

        public virtual new void SetDirection(BlockFace face, bool isOnSlope)
        {
            bool extraBitSet = (Data & 0x8) == 0x8;

            if (face != BlockFace.West && face != BlockFace.East && face != BlockFace.North && face != BlockFace.South)
            {
                throw new ArgumentException("Detector rails and powered rails cannot be set on a curve!");
            }

             base.SetDirection(face, isOnSlope);
            Data = ((byte)(extraBitSet ? (Data | 0x8) : (Data & ~0x8)));
        }

    }
}
