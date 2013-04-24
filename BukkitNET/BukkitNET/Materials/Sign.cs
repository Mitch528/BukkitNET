using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Sign : MaterialData, IAttachable
    {

        public bool IsWallSign
        {
            get
            {
                return ItemType == Material.WallSign;
            }
        }

        public Sign()
            : base(Material.SignPost)
        {
        }

        public Sign(int type)
            : base(type)
        {
        }

        public Sign(Material type)
            : base(type)
        {
        }

        public Sign(int type, byte data)
            : base(type, data)
        {
        }

        public Sign(Material type, byte data)
            : base(type, data)
        {
        }

        public void SetFacingDirection(BlockFace face)
        {

            byte data;

            if (IsWallSign)
            {
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
            }
            else
            {
                switch (face)
                {
                    case BlockFace.South:
                        data = 0x0;
                        break;

                    case BlockFace.SouthSouthWest:
                        data = 0x1;
                        break;

                    case BlockFace.SouthWest:
                        data = 0x2;
                        break;

                    case BlockFace.WestSouthWest:
                        data = 0x3;
                        break;

                    case BlockFace.West:
                        data = 0x4;
                        break;

                    case BlockFace.WestNorthWest:
                        data = 0x5;
                        break;

                    case BlockFace.NorthWest:
                        data = 0x6;
                        break;

                    case BlockFace.NorthNorthWest:
                        data = 0x7;
                        break;

                    case BlockFace.North:
                        data = 0x8;
                        break;

                    case BlockFace.NorthNorthEast:
                        data = 0x9;
                        break;

                    case BlockFace.NorthEast:
                        data = 0xA;
                        break;

                    case BlockFace.EastNorthEast:
                        data = 0xB;
                        break;

                    case BlockFace.East:
                        data = 0xC;
                        break;

                    case BlockFace.EastSouthEast:
                        data = 0xD;
                        break;

                    case BlockFace.SouthSouthEast:
                        data = 0xF;
                        break;

                    case BlockFace.SouthEast:
                    default:
                        data = 0xE;
                        break;
                }
            }

            Data = data;

        }

        public BlockFace GetFacing()
        {

            byte data = Data;

            if (!IsWallSign)
            {
                switch (data)
                {
                    case 0x0:
                        return BlockFace.South;

                    case 0x1:
                        return BlockFace.SouthSouthWest;

                    case 0x2:
                        return BlockFace.SouthWest;

                    case 0x3:
                        return BlockFace.WestSouthWest;

                    case 0x4:
                        return BlockFace.West;

                    case 0x5:
                        return BlockFace.WestNorthWest;

                    case 0x6:
                        return BlockFace.NorthWest;

                    case 0x7:
                        return BlockFace.NorthNorthWest;

                    case 0x8:
                        return BlockFace.North;

                    case 0x9:
                        return BlockFace.NorthNorthEast;

                    case 0xA:
                        return BlockFace.NorthEast;

                    case 0xB:
                        return BlockFace.EastNorthEast;

                    case 0xC:
                        return BlockFace.East;

                    case 0xD:
                        return BlockFace.EastSouthEast;

                    case 0xE:
                        return BlockFace.SouthEast;

                    case 0xF:
                        return BlockFace.SouthSouthEast;
                }

                return default(BlockFace);
            }
            else
            {
                return GetAttachedFace().GetOppositeFace();
            }

        }

        public BlockFace GetAttachedFace()
        {

            if (IsWallSign)
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
            else
            {
                return BlockFace.Down;
            }

        }

        public override string ToString()
        {
            return base.ToString() + " facing " + GetFacing();
        }

    }
}
