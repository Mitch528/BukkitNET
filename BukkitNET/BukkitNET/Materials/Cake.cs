using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Cake : MaterialData
    {

        public int SlicesEaten
        {
            get
            {
                return Data;
            }
            set
            {
                if (value < 6)
                {
                    Data = ((byte)value);
                }
            }
        }

        public int SlicesRemaining
        {
            get
            {
                return 6 - Data;
            }
            set
            {
                if (value > 6)
                {
                    value = 6;
                }
                Data = ((byte)(6 - value));
            }
        }

        public Cake()
            : base(Material.CakeBlock)
        {
        }

        public Cake(int type) : base(type)
        {
        }

        public Cake(Material type) : base(type)
        {
        }

        public Cake(int type, byte data) : base(type, data)
        {
        }

        public Cake(Material type, byte data) : base(type, data)
        {
        }

        public override string ToString()
        {
            return base.ToString() + " " + SlicesEaten + "/" + SlicesRemaining + " slices eaten/remaining";
        }

    }
}
