using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET
{

    public enum CropState
    {

        Seeded = 0x0,
        Germinated = 0x1,
        VerySmall = 0x2,
        Small = 0x3,
        Medium = 0x4,
        Tall = 0x5,
        VeryTall = 0x6,
        Ripe = 0x7

    }

    public static class CropStateHelper
    {

        public static CropState GetByData(byte data)
        {
            return (CropState)data;
        }

    }


}
