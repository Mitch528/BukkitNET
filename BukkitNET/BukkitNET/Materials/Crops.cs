using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Crops : MaterialData
    {

        public CropState State
        {
            get
            {
                return CropStateHelper.GetByData(Data);
            }
            set
            {
                Data = (byte)value;
            }
        }

        public Crops()
            : base(Material.Crops)
        {
        }

        public Crops(CropState state)
            : this()
        {
            State = state;
        }

        public Crops(int type)
            : base(type)
        {
        }

        public Crops(Material type)
            : base(type)
        {
        }

        public Crops(int type, byte data)
            : base(type, data)
        {
        }

        public Crops(Material type, byte data)
            : base(type, data)
        {
        }

        public override string ToString()
        {
            return State + " " + base.ToString();
        }

    }
}
