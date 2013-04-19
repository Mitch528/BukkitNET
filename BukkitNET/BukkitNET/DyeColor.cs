using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Extensions;

namespace BukkitNET
{

    public enum DyeColor
    {

        [DyeColorInfo(0x0, 0xF, 0xFFFFFF, 0xF0F0F0)]
        White,

        [DyeColorInfo(0x1, 0xE, 0xD87F33, 0xEB8844)]
        Orange,

        [DyeColorInfo(0x2, 0xD, 0xB24CD8, 0xC354CD)]
        Magenta,

        [DyeColorInfo(0x3, 0xC, 0x6699D8, 0x6689D3)]
        LightBlue,

        [DyeColorInfo(0x4, 0xB, 0xE5E533, 0xDECF2A)]
        Yellow,

        [DyeColorInfo(0x5, 0xA, 0x7FCC19, 0x41CD34)]
        Lime,

        [DyeColorInfo(0x6, 0x9, 0xF27FA5, 0xD88198)]
        Pink,

        [DyeColorInfo(0x7, 0x8, 0x4C4C4C, 0x434343)]
        Gray,

        [DyeColorInfo(0x8, 0x7, 0x999999, 0xABABAB)]
        Silver,

        [DyeColorInfo(0x9, 0x6, 0x4C7F99, 0x287697)]
        Cyan,

        [DyeColorInfo(0xA, 0x5, 0x7F3FB2, 0x7B2FBE)]
        Purple,

        [DyeColorInfo(0xB, 0x4, 0x334CB2, 0x253192)]
        Blue,

        [DyeColorInfo(0xC, 0x3, 0x664C33, 0x51301A)]
        Brown,

        [DyeColorInfo(0xD, 0x2, 0x667F33, 0x3B511A)]
        Green,

        [DyeColorInfo(0xE, 0x1, 0x993333, 0xB3312C)]
        Red,

        [DyeColorInfo(0xF, 0x0, 0x191919, 0x1E1B1B)]
        Black

    }

    public static class DyeColorExtensions
    {

        public static DyeColor GetByColor(Color color)
        {

            var dcs = Enum.GetValues(typeof(DyeColor)).Cast<DyeColor>().ToList();

            return (from dc in dcs let c = dc.GetAttribute<DyeColorInfoAttribute>().Color where c.Equals(color) select dc).FirstOrDefault();
        }

        public static DyeColor GetByFireworkColor(Color color)
        {

            var dcs = Enum.GetValues(typeof(DyeColor)).Cast<DyeColor>().ToList();

            return (from dc in dcs let c = dc.GetAttribute<DyeColorInfoAttribute>().FireworkColor where c.Equals(color) select dc).FirstOrDefault();
        }

        public static DyeColor GetByDyeColor(this byte data)
        {

            int i = data & 0xff;

            var dcs = Enum.GetValues(typeof(DyeColor)).Cast<DyeColor>().ToList();

            return (from dc in dcs let dd = dc.GetAttribute<DyeColorInfoAttribute>().DyeData & 0xff where i == dd select dc).FirstOrDefault();
        }

        public static DyeColor GetByWoolData(this byte data)
        {

            int i = data & 0xff;

            var dcs = Enum.GetValues(typeof(DyeColor)).Cast<DyeColor>().ToList();

            return (from dc in dcs let dd = dc.GetAttribute<DyeColorInfoAttribute>().WoolData & 0xff where i == dd select dc).FirstOrDefault();
        }

        public static Color GetColor(this DyeColor dyeColor)
        {
            return dyeColor.GetAttribute<DyeColorInfoAttribute>().Color;
        }

    }

}
