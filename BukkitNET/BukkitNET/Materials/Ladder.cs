using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Ladder : SimpleAttachableMaterialData
    {

        public Ladder()
            : base(Material.Ladder)
        {
        }

        public Ladder(int type, BlockFace direction)
            : base(type, direction)
        {
        }

        public Ladder(Material type, BlockFace direction)
            : base(type, direction)
        {
        }

        public Ladder(int type)
            : base(type)
        {
        }

        public Ladder(Material type)
            : base(type)
        {
        }

        public Ladder(int type, byte data)
            : base(type, data)
        {
        }

        public Ladder(Material type, byte data)
            : base(type, data)
        {
        }

        public override BlockFace GetAttachedFace()
        {

            byte data = Data;

            switch (data)
            {
                case 0x2:
                    return BlockFace.South;

                case 0x3:
                    return BlockFace.North;

                case 0x4:
                    return BlockFace.East;

                case 0x5:
                    return BlockFace.West;
            }

            return default(BlockFace);

        }

        public new void SetFacingDirection(BlockFace face)
        {
            byte data = (byte)0x0;

            switch (face)
            {
                case BlockFace.South:
                    data = 0x2;
                    break;

                case BlockFace.North:
                    data = 0x3;
                    break;

                case BlockFace.East:
                    data = 0x4;
                    break;

                case BlockFace.West:
                    data = 0x5;
                    break;
            }

            Data = data;

        }

    }
}
