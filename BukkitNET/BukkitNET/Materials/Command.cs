using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Command : MaterialData, IRedstone
    {

        public Command()
            : base(Material.Command)
        {
        }

        public Command(int type)
            : base(type)
        {
        }

        public Command(Material type)
            : base(type)
        {
        }

        public Command(int type, byte data)
            : base(type, data)
        {
        }

        public Command(Material type, byte data)
            : base(type, data)
        {
        }

        public bool IsPowered()
        {
            return (Data & 1) != 0;
        }

        public void SetPowered(bool powered)
        {
            Data = ((byte)(powered ? (Data | 1) : (Data & -2)));
        }

        public override string ToString()
        {
            return base.ToString() + " " + (IsPowered() ? "" : "NOT ") + "POWERED";
        }

    }
}
