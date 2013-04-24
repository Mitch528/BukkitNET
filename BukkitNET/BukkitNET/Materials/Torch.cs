using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Torch : SimpleAttachableMaterialData
    {

        public Torch()
            : base(Material.Torch)
        {
        }

        public Torch(int type, BlockFace direction)
            : base(type, direction)
        {
        }

        public Torch(Material type, BlockFace direction)
            : base(type, direction)
        {
        }

        public Torch(int type)
            : base(type)
        {
        }

        public Torch(Material type)
            : base(type)
        {
        }

        public Torch(int type, byte data)
            : base(type, data)
        {
        }

        public Torch(Material type, byte data)
            : base(type, data)
        {
        }

        public override BlockFace GetAttachedFace()
        {
            byte data = Data;

            switch (data)
            {
                case 0x1:
                    return BlockFace.West;

                case 0x2:
                    return BlockFace.East;

                case 0x3:
                    return BlockFace.North;

                case 0x4:
                    return BlockFace.South;

                case 0x5:
                default:
                    return BlockFace.Down;
            }
        }

        public new void SetFacingDirection(BlockFace face)
        {
            byte data;

            switch (face)
            {
                case BlockFace.East:
                    data = 0x1;
                    break;

                case BlockFace.West:
                    data = 0x2;
                    break;

                case BlockFace.South:
                    data = 0x3;
                    break;

                case BlockFace.North:
                    data = 0x4;
                    break;

                case BlockFace.Up:
                default:
                    data = 0x5;
                    break;
            }

            Data = data;
        }

    }
}
