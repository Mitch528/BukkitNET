using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Extensions;

namespace BukkitNET.Block
{

    public enum BlockFace
    {

        [BlockFaceInfo(0, 0, -1)]
        North,

        [BlockFaceInfo(1, 0, 0)]
        South,

        [BlockFaceInfo(0, 0, 1)]
        East,

        [BlockFaceInfo(-1, 0, 0)]
        West,

        [BlockFaceInfo(0, 1, 0)]
        Up,

        [BlockFaceInfo(0, -1, 0)]
        Down,

        [BlockFaceInfo(BlockFace.North, BlockFace.East)]
        NorthEast,

        [BlockFaceInfo(BlockFace.North, BlockFace.West)]
        NorthWest,

        [BlockFaceInfo(BlockFace.South, BlockFace.East)]
        SouthEast,

        [BlockFaceInfo(BlockFace.South, BlockFace.West)]
        SouthWest,

        [BlockFaceInfo(BlockFace.West, BlockFace.NorthWest)]
        WestNorthWest,

        [BlockFaceInfo(BlockFace.North, BlockFace.NorthWest)]
        NorthNorthWest,

        [BlockFaceInfo(BlockFace.NorthWest, BlockFace.NorthEast)]
        NorthNorthEast,

        [BlockFaceInfo(BlockFace.East, BlockFace.NorthEast)]
        EastNorthEast,

        [BlockFaceInfo(BlockFace.East, BlockFace.SouthEast)]
        EastSouthEast,

        [BlockFaceInfo(BlockFace.South, BlockFace.SouthEast)]
        SouthSouthEast,

        [BlockFaceInfo(BlockFace.SouthEast, BlockFace.SouthWest)]
        SouthSouthWest,

        [BlockFaceInfo(BlockFace.West, BlockFace.SouthWest)]
        WestSouthWest,

        [BlockFaceInfo(0, 0, 0)]
        Self

    }

    public static class BlockFaceExtensions
    {

        public static int GetModX(this BlockFace blockFace)
        {
            return GetAttribute(blockFace).ModX;
        }

        public static int GetModY(this BlockFace blockFace)
        {
            return GetAttribute(blockFace).ModY;
        }

        public static int GetModZ(this BlockFace blockFace)
        {
            return GetAttribute(blockFace).ModZ;
        }

        public static BlockFace GetOppositeFace(this BlockFace blockFace)
        {

            switch (blockFace)
            {

                case BlockFace.North:
                    return BlockFace.South;

                case BlockFace.South:
                    return BlockFace.North;

                case BlockFace.East:
                    return BlockFace.West;

                case BlockFace.West:
                    return BlockFace.East;

                case BlockFace.Up:
                    return BlockFace.Down;

                case BlockFace.Down:
                    return BlockFace.Up;

                case BlockFace.NorthEast:
                    return BlockFace.SouthWest;

                case BlockFace.NorthWest:
                    return BlockFace.SouthEast;

                case BlockFace.SouthEast:
                    return BlockFace.NorthWest;

                case BlockFace.SouthWest:
                    return BlockFace.NorthEast;

                case BlockFace.WestNorthWest:
                    return BlockFace.EastSouthEast;

                case BlockFace.NorthNorthWest:
                    return BlockFace.SouthSouthEast;

                case BlockFace.NorthNorthEast:
                    return BlockFace.SouthSouthWest;

                case BlockFace.EastNorthEast:
                    return BlockFace.WestSouthWest;

                case BlockFace.EastSouthEast:
                    return BlockFace.WestNorthWest;

                case BlockFace.SouthSouthEast:
                    return BlockFace.NorthNorthWest;

                case BlockFace.SouthSouthWest:
                    return BlockFace.NorthNorthEast;

                case BlockFace.WestSouthWest:
                    return BlockFace.EastNorthEast;

                case BlockFace.Self:
                    return BlockFace.Self;
            }

            return BlockFace.Self;

        }

        private static BlockFaceInfoAttribute GetAttribute(BlockFace blockFace)
        {
            return blockFace.GetAttribute<BlockFaceInfoAttribute>();
        }

    }

}
