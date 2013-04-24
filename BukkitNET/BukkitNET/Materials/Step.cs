using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public class Step : TexturedMaterial
    {

        private static readonly List<Material> textures = new List<Material>();

        public bool IsInverted
        {
            get
            {
                return ((Data & 0x8) != 0);
            }
            set
            {

                int dat = Data & 0x7;
                if (value)
                {
                    dat |= 0x8;
                }
                Data = ((byte)dat);

            }
        }

        public int TextureIndex
        {
            get
            {
                return Data & 0x7;
            }
            set
            {
                Data = ((byte)((Data & 0x8) | value));
            }
        }


        static Step()
        {
            textures.Add(Material.Stone);
            textures.Add(Material.Sandstone);
            textures.Add(Material.Wood);
            textures.Add(Material.CobbleStone);
            textures.Add(Material.Brick);
            textures.Add(Material.SmoothBrick);
        }

        public Step()
            : base(Material.Step)
        {
        }

        public Step(int type)
            : base(type)
        {
        }

        public Step(Material type)
            : base(((textures.Contains(type)) ? Material.Step : type))
        {
            if (textures.Contains(type))
            {
                SetMaterial(type);
            }
        }

        public Step(int type, byte data)
            : base(type, data)
        {
        }

        public Step(Material type, byte data)
            : base(type, data)
        {
        }

        public override List<Material> GetTextures()
        {
            return textures;
        }

        public override string ToString()
        {
            return base.ToString() + (IsInverted ? "inverted" : "");
        }

    }
}
