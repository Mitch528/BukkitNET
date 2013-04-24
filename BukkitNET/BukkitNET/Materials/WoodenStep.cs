using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class WoodenStep : MaterialData
    {

        public TreeSpecies Species
        {
            get
            {
                return (TreeSpecies)((byte)(Data & 0x3));
            }
            set
            {
                Data = ((byte)((Data & 0xC) | (byte)value));
            }
        }

        public bool IsInverted
        {
            get
            {
                return ((Data & 0x8) != 0);
            }
            set
            {
                int dat = Data & 0x7;
                if (value)
                {
                    dat |= 0x8;
                }
                Data = ((byte)dat);
            }
        }

        public WoodenStep()
            : base(Material.WoodStep)
        {
        }

        public WoodenStep(TreeSpecies species) : this()
        {
            Species = species;
        }

        public WoodenStep(TreeSpecies species, bool inv) : this()
        {
            Species = species;
            Inverted = inv;
        }

        public WoodenStep(int type)
            : base(type)
        {
        }

        public WoodenStep(Material type)
            : base(type)
        {
        }

        public WoodenStep(int type, byte data)
            : base(type, data)
        {
        }

        public WoodenStep(Material type, byte data)
            : base(type, data)
        {
        }

        public override string ToString()
        {
            return base.ToString() + " " + Species + (IsInverted ? " inverted" : "");
        }

    }
}
