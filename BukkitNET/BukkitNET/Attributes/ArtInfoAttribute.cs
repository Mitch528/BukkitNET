using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ArtInfoAttribute : Attribute
    {

        private int id;
        private int width;
        private int height;

        public int Id
        {
            get
            {
                return id;
            }
        }

        public int BlockWidth
        {
            get
            {
                return width;
            }
        }

        public int BlockHeight
        {
            get
            {
                return height;
            }
        }

        public ArtInfoAttribute(int id, int width, int height)
        {
            this.id = id;
            this.width = width;
            this.height = height;
        }

    }
}
