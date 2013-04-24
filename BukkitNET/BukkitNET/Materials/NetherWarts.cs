using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class NetherWarts : MaterialData
    {

        public NetherWartsState State
        {
            get
            {
                switch (Data)
                {
                    case 0:
                        return NetherWartsState.Seeded;
                    case 1:
                        return NetherWartsState.StageOne;
                    case 2:
                        return NetherWartsState.StageTwo;
                    default:
                        return NetherWartsState.Ripe;
                }
            }
            set
            {
                switch (value)
                {
                    case NetherWartsState.Seeded:
                        Data = ((byte)0x0);
                        return;
                    case NetherWartsState.StageOne:
                        Data = ((byte)0x1);
                        return;
                    case NetherWartsState.StageTwo:
                        Data = ((byte)0x2);
                        return;
                    case NetherWartsState.Ripe:
                        Data = ((byte)0x3);
                        return;
                }
            }
        }

        public NetherWarts()
            : base(Material.NetherWarts)
        {
        }

        public NetherWarts(NetherWartsState state) : this()
        {
            State = state;
        }

        public NetherWarts(int type)
            : base(type)
        {
        }

        public NetherWarts(Material type)
            : base(type)
        {
        }

        public NetherWarts(int type, byte data)
            : base(type, data)
        {
        }

        public NetherWarts(Material type, byte data)
            : base(type, data)
        {
        }

        public override string ToString()
        {
            return State + " " + base.ToString();
        }

    }
}
