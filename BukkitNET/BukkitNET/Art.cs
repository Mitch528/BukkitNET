using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Extensions;

namespace BukkitNET
{

    public enum Art
    {

        [ArtInfo(0, 1, 1)]
        Kebab,

        [ArtInfo(1, 1, 1)]
        Aztec,

        [ArtInfo(2, 1, 1)]
        Alban,

        [ArtInfo(3, 1, 1)]
        Aztec2,

        [ArtInfo(4, 1, 1)]
        Bomb,

        [ArtInfo(5, 1, 1)]
        Plant,

        [ArtInfo(6, 1, 1)]
        Wasteland,

        [ArtInfo(7, 2, 1)]
        Pool,

        [ArtInfo(8, 2, 1)]
        Courbet,

        [ArtInfo(9, 2, 1)]
        Sea,

        [ArtInfo(10, 2, 1)]
        Sunset,

        [ArtInfo(11, 2, 1)]
        Creebet,

        [ArtInfo(12, 1, 2)]
        Wanderer,

        [ArtInfo(13, 1, 2)]
        Graham,

        [ArtInfo(14, 2, 2)]
        Match,

        [ArtInfo(15, 2, 2)]
        Bust,

        [ArtInfo(16, 2, 2)]
        Stage,

        [ArtInfo(17, 2, 2)]
        Void,

        [ArtInfo(18, 2, 2)]
        SkullAndRoses,

        [ArtInfo(19, 2, 2)]
        Wither,

        [ArtInfo(20, 4, 2)]
        Fighters,

        [ArtInfo(21, 4, 4)]
        Pointer,

        [ArtInfo(22, 4, 4)]
        PigScene,

        [ArtInfo(23, 4, 4)]
        BurningSkull,

        [ArtInfo(24, 4, 3)]
        Skeleton,

        [ArtInfo(25, 4, 3)]
        DonkeyKong

    }

    public static class ArtHelper
    {

        private static Dictionary<string, Art> BY_NAME = new Dictionary<string, Art>();
        private static Dictionary<int, Art> BY_ID = new Dictionary<int, Art>();

        static ArtHelper()
        {

            var vals = Enum.GetValues(typeof(Art));

            foreach (Art art in vals)
            {

                var attrib = art.GetAttribute<ArtInfoAttribute>();

                BY_NAME.Add(art.ToString().ToLower(), art);
                BY_ID.Add(attrib.Id, art);

            }

        }

        public static Art GetById(int id)
        {
            return BY_ID[id];
        }

        public static Art GetByName(string name)
        {
            return BY_NAME[name.ToLower()];
        }

    }

}
