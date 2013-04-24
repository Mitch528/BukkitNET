using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Dye : MaterialData, IColorable
    {

        public Dye()
            : base(Material.InkSack)
        {
        }

        public Dye(int type)
            : base(type)
        {
        }

        public Dye(Material type)
            : base(type)
        {
        }

        public Dye(int type, byte data)
            : base(type, data)
        {
        }

        public Dye(Material type, byte data)
            : base(type, data)
        {
        }

        public DyeColor GetColor()
        {
            return (DyeColor)Data;
        }

        public void SetColor(DyeColor color)
        {
            Data = (byte)color;
        }

        public override string ToString()
        {
            return GetColor() + " DYE(" + Data + ")";
        }



    }
}
