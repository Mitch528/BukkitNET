using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Wool : MaterialData, IColorable
    {

        public Wool()
            : base(Material.Wool)
        {
        }

        public Wool(DyeColor color)
            : this()
        {
            SetColor(color);
        }

        public Wool(int type)
            : base(type)
        {
        }

        public Wool(Material type)
            : base(type)
        {
        }

        public Wool(int type, byte data)
            : base(type, data)
        {
        }

        public Wool(Material type, byte data)
            : base(type, data)
        {
        }

        public DyeColor GetColor()
        {
            return DyeColorHelper.GetByWoolData(Data);
        }

        public void SetColor(DyeColor color)
        {
            Data = color.GetWoolData();
        }

        public override string ToString()
        {
            return GetColor() + " " + base.ToString();
        }

    }
}
