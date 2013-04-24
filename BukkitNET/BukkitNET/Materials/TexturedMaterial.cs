using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public abstract class TexturedMaterial : MaterialData
    {

        protected TexturedMaterial(int type) : base(type)
        {
        }

        protected TexturedMaterial(Material type) : base(type)
        {
        }

        protected TexturedMaterial(int type, byte data) : base(type, data)
        {
        }

        protected TexturedMaterial(Material type, byte data) : base(type, data)
        {
        }

        public abstract List<Material> GetTextures();

        public Material GetMaterial()
        {
            int n = GetTextureIndex();
            if (n > GetTextures().Count - 1)
            {
                n = 0;
            }

            return GetTextures()[n];
        }

        public void SetMaterial(Material material)
        {
            if (GetTextures().Contains(material))
            {
                SetTextureIndex(GetTextures().IndexOf(material));
            }
            else
            {
                SetTextureIndex(0x0);
            }
        }

        protected int GetTextureIndex()
        {
            return Data;
        }

        protected void SetTextureIndex(int idx)
        {
            Data = ((byte)idx);
        }

        public override string ToString()
        {
            return GetMaterial() + " " + base.ToString();
        }

    }
}
