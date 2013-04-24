using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class PressurePlate : MaterialData, IPressureSensor
    {

        public PressurePlate()
            : base(Material.WoodPlate)
        {
        }

        public PressurePlate(int type)
            : base(type)
        {
        }

        public PressurePlate(Material type)
            : base(type)
        {
        }

        public PressurePlate(int type, byte data)
            : base(type, data)
        {
        }

        public PressurePlate(Material type, byte data)
            : base(type, data)
        {
        }

        public bool IsPressed()
        {
            return Data == 0x1;
        }

        public override string ToString()
        {
            return base.ToString() + (IsPressed() ? " PRESSED" : "");
        }

    }
}
