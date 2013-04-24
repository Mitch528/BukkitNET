using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Tripwire : MaterialData
    {

        public bool IsActivated
        {
            get
            {
                return (Data & 0x4) != 0;
            }
            set
            {
                int dat = Data & (0x8 | 0x3);
                if (value)
                {
                    dat |= 0x4;
                }
                Data = ((byte)dat);
            }
        }

        public bool IsObjectTriggering
        {
            get
            {
                return (Data & 0x1) != 0;
            }
            set
            {

                int dat = Data & 0xE;
                if (value)
                {
                    dat |= 0x1;
                }
                Data = ((byte)dat);

            }
        }

        public Tripwire()
            : base(Material.Tripwire)
        {
        }

        public Tripwire(int type)
            : base(type)
        {
        }

        public Tripwire(Material type)
            : base(type)
        {
        }

        public Tripwire(int type, byte data)
            : base(type, data)
        {
        }

        public Tripwire(Material type, byte data)
            : base(type, data)
        {
        }

        public override string ToString()
        {
            return base.ToString() + (IsActivated() ? " Activated" : "") + (isObjectTriggering() ? " Triggered" : "");
        }

    }
}
