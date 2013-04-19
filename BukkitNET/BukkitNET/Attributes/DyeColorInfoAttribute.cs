using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DyeColorInfoAttribute : Attribute
    {

        private readonly byte woolData;
        private readonly byte dyeData;
        private readonly Color color;
        private readonly Color firework;
        private readonly static DyeColorInfoAttribute[] BY_WOOL_DATA;
        private readonly static DyeColorInfoAttribute[] BY_DYE_DATA;

        private readonly static Dictionary<Color, DyeColorInfoAttribute> BY_COLOR;
        private readonly static Dictionary<Color, DyeColorInfoAttribute> BY_FIREWORK;


        public DyeColorInfoAttribute(int woolData, int dyeData, int colorRGB, int fireworkRGB)
        {
            this.woolData = (byte)woolData;
            this.dyeData = (byte)dyeData;
            this.color = color;
            this.firework = firework;
        }

        public byte WoolData
        {
            get
            {
                return woolData;
            }
        }

        public byte DyeData
        {
            get
            {
                return dyeData;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }
        }

        public Color FireworkColor
        {
            get
            {
                return firework;
            }
        }

        

    }
}
