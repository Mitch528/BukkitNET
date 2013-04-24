using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class DetectorRail : ExtendedRails, IPressureSensor
    {

        public bool IsPressed()
        {
            return (Data & 0x8) == 0x8;
        }

        public void SetPressed(bool isPressed)
        {
            Data = ((byte)(isPressed ? (Data | 0x8) : (Data & ~0x8)));
        }

    }
}
