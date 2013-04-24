using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Vine : MaterialData
    {

        private static int VINE_NORTH = 0x4;
        private static int VINE_EAST = 0x8;
        private static int VINE_WEST = 0x2;
        private static int VINE_SOUTH = 0x1;

        List<BlockFace> possibleFaces = new List<BlockFace>()
        {
            BlockFace.West, BlockFace.North, BlockFace.South, BlockFace.East
        };

        public Vine()
            : base(Material.Vine)
        {
        }

        public Vine(params BlockFace[] faces)
            : this(new List<BlockFace>(faces))
        {
        }

        public Vine(List<BlockFace> faces)
            : this(0)
        {

            for (int i = 0; i < faces.Count; i++)
            {

                var face = faces[i];

                if (!possibleFaces.Contains(face))
                    faces.Remove(face);

            }

            byte data = 0;

            if (faces.Contains(BlockFace.West))
            {
                data |= (byte)VINE_WEST;
            }

            if (faces.Contains(BlockFace.North))
            {
                data |= (byte)VINE_NORTH;
            }

            if (faces.Contains(BlockFace.South))
            {
                data |= (byte)VINE_SOUTH;
            }

            if (faces.Contains(BlockFace.East))
            {
                data |= (byte)VINE_EAST;
            }

            Data = data;

        }

        public Vine(int type)
            : base(type)
        {
        }

        public Vine(Material type)
            : base(type)
        {
        }

        public Vine(int type, byte data)
            : base(type, data)
        {
        }

        public Vine(Material type, byte data)
            : base(type, data)
        {
        }

        public bool IsOnFace(BlockFace face)
        {
            switch (face)
            {
                case BlockFace.West:
                    return (Data & VINE_WEST) == VINE_WEST;
                case BlockFace.North:
                    return (Data & VINE_NORTH) == VINE_NORTH;
                case BlockFace.South:
                    return (Data & VINE_SOUTH) == VINE_SOUTH;
                case BlockFace.East:
                    return (Data & VINE_EAST) == VINE_EAST;
                case BlockFace.NorthEast:
                    return IsOnFace(BlockFace.East) && IsOnFace(BlockFace.North);
                case BlockFace.NorthWest:
                    return IsOnFace(BlockFace.West) && IsOnFace(BlockFace.North);
                case BlockFace.SouthEast:
                    return IsOnFace(BlockFace.East) && IsOnFace(BlockFace.South);
                case BlockFace.SouthWest:
                    return IsOnFace(BlockFace.West) && IsOnFace(BlockFace.South);
                case BlockFace.Up:
                    return true;
                default:
                    return false;
            }
        }

        public void PutOnFace(BlockFace face)
        {
            switch (face)
            {
                case BlockFace.West:
                    Data = ((byte)(Data | VINE_WEST));
                    break;
                case BlockFace.North:
                    Data = ((byte)(Data | VINE_NORTH));
                    break;
                case BlockFace.South:
                    Data = ((byte)(Data | VINE_SOUTH));
                    break;
                case BlockFace.East:
                    Data = ((byte)(Data | VINE_EAST));
                    break;
                case BlockFace.NorthWest:
                    PutOnFace(BlockFace.West);
                    PutOnFace(BlockFace.North);
                    break;
                case BlockFace.SouthWest:
                    PutOnFace(BlockFace.West);
                    PutOnFace(BlockFace.South);
                    break;
                case BlockFace.NorthEast:
                    PutOnFace(BlockFace.East);
                    PutOnFace(BlockFace.North);
                    break;
                case BlockFace.SouthEast:
                    PutOnFace(BlockFace.East);
                    PutOnFace(BlockFace.South);
                    break;
                case BlockFace.Up:
                    break;
                default:
                    throw new ArgumentException("Vines can't go on face " + face.ToString());
            }
        }

        public void RemoveFromFace(BlockFace face)
        {
            switch (face)
            {
                case BlockFace.West:
                    Data = ((byte)(Data & ~VINE_WEST));
                    break;
                case BlockFace.North:
                    Data = ((byte)(Data & ~VINE_NORTH));
                    break;
                case BlockFace.South:
                    Data = ((byte)(Data & ~VINE_SOUTH));
                    break;
                case BlockFace.East:
                    Data = ((byte)(Data & ~VINE_EAST));
                    break;
                case BlockFace.NorthWest:
                    RemoveFromFace(BlockFace.West);
                    RemoveFromFace(BlockFace.North);
                    break;
                case BlockFace.SouthWest:
                    RemoveFromFace(BlockFace.West);
                    RemoveFromFace(BlockFace.South);
                    break;
                case BlockFace.NorthEast:
                    RemoveFromFace(BlockFace.East);
                    RemoveFromFace(BlockFace.North);
                    break;
                case BlockFace.SouthEast:
                    RemoveFromFace(BlockFace.East);
                    RemoveFromFace(BlockFace.South);
                    break;
                case BlockFace.Up:
                    break;
                default:
                    throw new ArgumentException("Vines can't go on face " + face.ToString());
            }
        }

        public override string ToString()
        {
            return "VINE";
        }

    }
}
