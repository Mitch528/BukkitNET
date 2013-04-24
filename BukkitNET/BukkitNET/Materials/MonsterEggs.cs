using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class MonsterEggs : TexturedMaterial
    {

        private static List<Material> textures = new List<Material>();

        static MonsterEggs()
        {
            textures.Add(Material.Stone);
            textures.Add(Material.CobbleStone);
            textures.Add(Material.SmoothBrick);
        }

        public MonsterEggs()
            : base(Material.MonsterEggs)
        {
        }

        public MonsterEggs(int type)
            : base(type)
        {
        }

        public MonsterEggs(Material type)
            : base((textures.Contains(type)) ? Material.MonsterEggs : type)
        {
            if (textures.Contains(type))
            {
                SetMaterial(type);
            }
        }

        public MonsterEggs(int type, byte data)
            : base(type, data)
        {
        }

        public MonsterEggs(Material type, byte data)
            : base(type, data)
        {
        }

        public override List<Material> GetTextures()
        {
            return textures;
        }

    }
}
