using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Cauldron : MaterialData
    {

        private const int CAULDRON_FULL = 3;
        private const int CAULDRON_EMPTY = 0;

        public bool IsFull
        {
            get
            {
                return Data >= CAULDRON_FULL;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return Data <= CAULDRON_EMPTY;
            }
        }

        public Cauldron()
            : base(Material.Cauldron)
        {
        }

        public Cauldron(byte data)
            : base(Material.Cauldron, data)
        {
        }

        public Cauldron(int type)
            : base(type)
        {
        }

        public Cauldron(Material type)
            : base(type)
        {
        }

        public Cauldron(int type, byte data)
            : base(type, data)
        {
        }

        public Cauldron(Material type, byte data)
            : base(type, data)
        {
        }

        public override string ToString()
        {
            return (IsEmpty ? "EMPTY" : (IsFull ? "FULL" : Data + "/3 FULL")) + " CAULDRON";
        }

    }
}
