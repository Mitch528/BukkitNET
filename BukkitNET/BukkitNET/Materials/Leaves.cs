using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Leaves : MaterialData
    {

        public TreeSpecies Species
        {
            get
            {
                return (TreeSpecies)((byte)(Data & 3));
            }
            set
            {
                Data = (byte)value;
            }
        }

        public Leaves()
            : base(Material.Leaves)
        {
        }

        public Leaves(int type)
            : base(type)
        {
        }

        public Leaves(Material type)
            : base(type)
        {
        }

        public Leaves(int type, byte data)
            : base(type, data)
        {
        }

        public Leaves(Material type, byte data)
            : base(type, data)
        {
        }

        public override string ToString()
        {
            return Species + " " + base.ToString();
        }

    }
}
