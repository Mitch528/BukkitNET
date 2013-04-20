using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class BlockFaceInfoAttribute : Attribute
    {

        private int modX;
        private int modY;
        private int modZ;

        public int ModX
        {
            get
            {
                return modX;
            }
        }

        public int ModY
        {
            get
            {
                return modY;
            }
        }

        public int ModZ
        {
            get
            {
                return modZ;
            }
        }

        public BlockFaceInfoAttribute(int modX, int modY, int modZ)
        {
            this.modX = modX;
            this.modY = modY;
            this.modZ = modZ;
        }

        public BlockFaceInfoAttribute(BlockFace face1, BlockFace face2)
        {
            this.modX = face1.GetModX() + face2.GetModX();
            this.modY = face1.GetModY() + face2.GetModY();
            this.modZ = face1.GetModZ() + face2.GetModZ();
        }

    }
}
