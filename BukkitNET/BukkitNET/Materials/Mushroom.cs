using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Mushroom : MaterialData
    {

        private const byte SHROOM_NONE = 0;
        private const byte SHROOM_STEM = 10;
        private const byte NORTH_LIMIT = 4;
        private const byte SOUTH_LIMIT = 6;
        private const byte EAST_WEST_LIMIT = 3;
        private const byte EAST_REMAINDER = 0;
        private const byte WEST_REMAINDER = 1;
        private const byte NORTH_SOUTH_MOD = 3;
        private const byte EAST_WEST_MOD = 1;

        public Mushroom(int type)
            : base(type)
        {
        }

        public Mushroom(Material type)
            : base(type)
        {
        }

        public Mushroom(int type, byte data)
            : base(type, data)
        {
        }

        public Mushroom(Material type, byte data)
            : base(type, data)
        {
        }

        public bool IsStem()
        {
            return Data == SHROOM_STEM;
        }

        public void SetStem()
        {
            Data = ((byte)10);
        }

        public bool IsFacePainted(BlockFace face)
        {
            byte data = Data;

            if (data == SHROOM_NONE || data == SHROOM_STEM)
            {
                return false;
            }

            switch (face)
            {
                case BlockFace.West:
                    return data < NORTH_LIMIT;
                case BlockFace.East:
                    return data > SOUTH_LIMIT;
                case BlockFace.North:
                    return data % EAST_WEST_LIMIT == EAST_REMAINDER;
                case BlockFace.South:
                    return data % EAST_WEST_LIMIT == WEST_REMAINDER;
                case BlockFace.Up:
                    return true;
                default:
                    return false;
            }
        }


        public void SetFacePainted(BlockFace face, bool painted)
        {
            if (painted == IsFacePainted(face))
            {
                return;
            }

            byte data = Data;

            if (data == SHROOM_STEM)
            {
                data = 5;
            }

            switch (face)
            {
                case BlockFace.West:
                    if (painted)
                    {
                        data -= NORTH_SOUTH_MOD;
                    }
                    else
                    {
                        data += NORTH_SOUTH_MOD;
                    }

                    break;
                case BlockFace.East:
                    if (painted)
                    {
                        data += NORTH_SOUTH_MOD;
                    }
                    else
                    {
                        data -= NORTH_SOUTH_MOD;
                    }

                    break;
                case BlockFace.North:
                    if (painted)
                    {
                        data += EAST_WEST_MOD;
                    }
                    else
                    {
                        data -= EAST_WEST_MOD;
                    }

                    break;
                case BlockFace.South:
                    if (painted)
                    {
                        data -= EAST_WEST_MOD;
                    }
                    else
                    {
                        data += EAST_WEST_MOD;
                    }

                    break;
                case BlockFace.Up:
                    if (!painted)
                    {
                        data = 0;
                    }

                    break;
                default:
                    throw new ArgumentException("Can't paint that face of a mushroom!");
            }

            Data = data;
        }

        public HashSet<BlockFace> GetPaintedFaces()
        {

            HashSet<BlockFace> faces = new HashSet<BlockFace>();

            if (IsFacePainted(BlockFace.West))
            {
                faces.Add(BlockFace.West);
            }

            if (IsFacePainted(BlockFace.North))
            {
                faces.Add(BlockFace.North);
            }

            if (IsFacePainted(BlockFace.South))
            {
                faces.Add(BlockFace.South);
            }

            if (IsFacePainted(BlockFace.East))
            {
                faces.Add(BlockFace.East);
            }

            if (IsFacePainted(BlockFace.Up))
            {
                faces.Add(BlockFace.Up);
            }

            return faces;
        }

        public override string ToString()
        {
            return MaterialHelper.GetMaterial(TypeId).ToString() + (IsStem() ? "{STEM}" : GetPaintedFaces().ToString());
        }



    }
}
