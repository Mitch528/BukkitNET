using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Coal : MaterialData
    {

        public CoalType Type
        {
            get
            {
                return CoalTypeHelper.GetByData(Data);
            }
        }

        public Coal()
            : base(Material.Coal)
        {
        }

        public Coal(CoalType type) : this()
        {
            Data = (byte)type;
        }

        public Coal(int type)
            : base(type)
        {
        }

        public Coal(Material type)
            : base(type)
        {
        }

        public Coal(int type, byte data)
            : base(type, data)
        {
        }

        public Coal(Material type, byte data)
            : base(type, data)
        {
        }

    }
}
