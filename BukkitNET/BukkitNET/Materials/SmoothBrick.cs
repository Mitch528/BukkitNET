using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class SmoothBrick : TexturedMaterial
    {

        private static List<Material> textures = new List<Material>();

        public List<Material> Textures
        {
            get
            {
                return textures;
            }
        }

        static SmoothBrick()
        {
            textures.Add(Material.Stone);
            textures.Add(Material.MossyCobblestone);
            textures.Add(Material.CobbleStone);
            textures.Add(Material.SmoothBrick);
        }

        public SmoothBrick()
            : base(Material.SmoothBrick)
        {
        }

        public SmoothBrick(int type)
            : base(type)
        {
        }

        public SmoothBrick(Material type)
            : base((textures.Contains(type)) ? Material.SmoothBrick : type)
        {
            if (textures.Contains(type))
            {
                SetMaterial(type);
            }
        }

        public SmoothBrick(int type, byte data)
            : base(type, data)
        {
        }

        public SmoothBrick(Material type, byte data)
            : base(type, data)
        {
        }

        public override List<Material> GetTextures()
        {
            throw new NotImplementedException();
        }
    }
}
