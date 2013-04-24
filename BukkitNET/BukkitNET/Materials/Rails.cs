using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Rails : MaterialData
    {

        public bool IsOnSlope
        {
            get
            {
                byte d = GetConvertedData();

                return (d == 0x2 || d == 0x3 || d == 0x4 || d == 0x5);
            }
        }

        public bool IsCurve
        {
            get
            {
                byte d = GetConvertedData();

                return (d == 0x6 || d == 0x7 || d == 0x8 || d == 0x9);
            }
        }

        public Rails()
            : base(Material.Rails)
        {
        }

        public Rails(int type)
            : base(type)
        {
        }

        public Rails(Material type)
            : base(type)
        {
        }

        public Rails(int type, byte data)
            : base(type, data)
        {
        }

        public Rails(Material type, byte data)
            : base(type, data)
        {
        }

        public BlockFace GetDirection()
        {
            byte d = GetConvertedData();

            switch (d)
            {
                case 0x0:
                default:
                    return BlockFace.South;

                case 0x1:
                    return BlockFace.East;

                case 0x2:
                    return BlockFace.East;

                case 0x3:
                    return BlockFace.West;

                case 0x4:
                    return BlockFace.North;

                case 0x5:
                    return BlockFace.South;

                case 0x6:
                    return BlockFace.NorthWest;

                case 0x7:
                    return BlockFace.NorthEast;

                case 0x8:
                    return BlockFace.SouthEast;

                case 0x9:
                    return BlockFace.SouthWest;
            }
        }

        public void SetDirection(BlockFace face, bool isOnSlope)
        {
            switch (face)
            {
                case BlockFace.East:
                    Data = ((byte)(isOnSlope ? 0x2 : 0x1));
                    break;

                case BlockFace.West:
                    Data = ((byte)(isOnSlope ? 0x3 : 0x1));
                    break;

                case BlockFace.North:
                    Data = ((byte)(isOnSlope ? 0x4 : 0x0));
                    break;

                case BlockFace.South:
                    Data = ((byte)(isOnSlope ? 0x5 : 0x0));
                    break;

                case BlockFace.NorthWest:
                    Data = ((byte)0x6);
                    break;

                case BlockFace.NorthEast:
                    Data = ((byte)0x7);
                    break;

                case BlockFace.SouthEast:
                    Data = ((byte)0x8);
                    break;

                case BlockFace.SouthWest:
                    Data = ((byte)0x9);
                    break;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " facing " + GetDirection() + (IsCurve ? " on a curve" : (IsOnSlope ? " on a slope" : ""));
        }

        protected byte GetConvertedData()
        {
            return Data;
        }

    }
}
