using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class LongGrass : MaterialData
    {

        public GrassSpecies Species
        {
            get
            {
                return (GrassSpecies)Data;
            }
            set
            {
                Data = (byte)value;
            }
        }

        public LongGrass(GrassSpecies species)
            : this()
        {
            Species = species;
        }

        public LongGrass()
            : base(Material.LongGrass)
        {
        }

        public LongGrass(int type)
            : base(type)
        {
        }

        public LongGrass(Material type)
            : base(type)
        {
        }

        public LongGrass(int type, byte data)
            : base(type, data)
        {
        }

        public LongGrass(Material type, byte data)
            : base(type, data)
        {
        }

        public override string ToString()
        {
            return Species + " " + base.ToString();
        }

    }
}
