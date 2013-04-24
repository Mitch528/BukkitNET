using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Sandstone : MaterialData
    {

        public SandstoneType Type
        {
            get
            {
                return (SandstoneType)Data;
            }
            set
            {
                Data = (byte)value;
            }
        }

        public Sandstone()
            : base(Material.Sandstone)
        {
        }

        public Sandstone(SandstoneType type)
            : this()
        {
            Type = type;
        }

        public Sandstone(int type)
            : base(type)
        {
        }

        public Sandstone(Material type)
            : base(type)
        {
        }

        public Sandstone(int type, byte data)
            : base(type, data)
        {
        }

        public Sandstone(Material type, byte data)
            : base(type, data)
        {
        }

        public override string ToString()
        {
            return Type + " " + base.ToString();
        }

    }
}
