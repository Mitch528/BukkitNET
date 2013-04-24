using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Door : MaterialData, IDirectional, IOpenable
    {

        public Door()
            : base(Material.WoodenDoor)
        {
        }

        public Door(int type)
            : base(type)
        {
        }

        public Door(Material type)
            : base(type)
        {
        }

        public Door(int type, byte data)
            : base(type, data)
        {
        }

        public Door(Material type, byte data)
            : base(type, data)
        {
        }

        public void SetFacingDirection(BlockFace face)
        {

            byte data = (byte)(Data & 0x12);
            switch (face)
            {
                case BlockFace.North:
                    data |= 0x1;
                    break;

                case BlockFace.East:
                    data |= 0x2;
                    break;

                case BlockFace.South:
                    data |= 0x3;
                    break;
            }
            Data = (data);

        }

        public BlockFace GetFacing()
        {
            byte data = (byte)(Data & 0x3);
            switch (data)
            {
                case 0:
                    return BlockFace.West;

                case 1:
                    return BlockFace.North;

                case 2:
                    return BlockFace.East;

                case 3:
                    return BlockFace.South;
            }
            return default(BlockFace);
        }

        public bool IsOpen()
        {
            return ((Data & 0x4) == 0x4);
        }

        public void SetOpen(bool isOpen)
        {
            Data = ((byte)(isOpen ? (Data | 0x4) : (Data & ~0x4)));
        }


        public void SetTopHalf(bool isTopHalf)
        {
            Data = ((byte)(isTopHalf ? (Data | 0x8) : (Data & ~0x8)));
        }

        public bool IsTopHalf()
        {
            return ((Data & 0x8) == 0x8);
        }

        public BlockFace GetHingeCorner()
        {
            byte d = Data;

            if ((d & 0x3) == 0x3)
            {
                return BlockFace.NorthWest;
            }
            else if ((d & 0x1) == 0x1)
            {
                return BlockFace.SouthEast;
            }
            else if ((d & 0x2) == 0x2)
            {
                return BlockFace.SouthWest;
            }

            return BlockFace.NorthEast;
        }

        public override string ToString()
        {
            return (IsTopHalf() ? "TOP" : "BOTTOM") + " half of " + base.ToString();
        }



    }
}
