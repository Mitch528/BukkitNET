using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class DirectionalContainer : MaterialData, IDirectional
    {

        public DirectionalContainer(int type)
            : base(type)
        {
        }

        public DirectionalContainer(Material type)
            : base(type)
        {
        }

        public DirectionalContainer(int type, byte data)
            : base(type, data)
        {
        }

        public DirectionalContainer(Material type, byte data)
            : base(type, data)
        {
        }

        public void SetFacingDirection(BlockFace face)
        {

            byte data;

            switch (face)
            {
                case BlockFace.North:
                    data = 0x2;
                    break;

                case BlockFace.South:
                    data = 0x3;
                    break;

                case BlockFace.West:
                    data = 0x4;
                    break;

                case BlockFace.East:
                default:
                    data = 0x5;
                    break;
            }

            Data = data;

        }

        public BlockFace GetFacing()
        {
            byte data = Data;

            switch (data)
            {
                case 0x2:
                    return BlockFace.North;

                case 0x3:
                    return BlockFace.South;

                case 0x4:
                    return BlockFace.West;

                case 0x5:
                default:
                    return BlockFace.East;

            }

        }

        public override string ToString()
        {
            return base.ToString() + " facing " + GetFacing();
        }

    }
}
