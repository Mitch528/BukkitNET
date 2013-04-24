using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class FurnaceAndDispenser : DirectionalContainer
    {

        public FurnaceAndDispenser(int type) : base(type)
        {
        }

        public FurnaceAndDispenser(Material type) : base(type)
        {
        }

        public FurnaceAndDispenser(int type, byte data) : base(type, data)
        {
        }

        public FurnaceAndDispenser(Material type, byte data) : base(type, data)
        {
        }

    }
}
