using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Stairs : MaterialData, IDirectional
    {

        public BlockFace AscendingDirection
        {
            get
            {

                byte data = Data;

                switch (data & 0x3)
                {
                    case 0x0:
                    default:
                        return BlockFace.East;

                    case 0x1:
                        return BlockFace.West;

                    case 0x2:
                        return BlockFace.South;

                    case 0x3:
                        return BlockFace.North;
                }

            }
        }

        public BlockFace DescendingDirection
        {
            get
            {
                return AscendingDirection.GetOppositeFace();
            }
        }

        public bool IsInverted
        {
            get
            {
                return ((Data & 0x4) != 0);
            }
            set
            {
                int dat = Data & 0x3;
                if (value)
                {
                    dat |= 0x4;
                }
                Data = ((byte)dat);
            }
        }

        public Stairs(int type)
            : base(type)
        {
        }

        public Stairs(Material type)
            : base(type)
        {
        }

        public Stairs(int type, byte data)
            : base(type, data)
        {
        }

        public Stairs(Material type, byte data)
            : base(type, data)
        {
        }

        public void SetFacingDirection(BlockFace face)
        {

            byte data;

            switch (face)
            {
                case BlockFace.North:
                    data = 0x3;
                    break;

                case BlockFace.South:
                    data = 0x2;
                    break;

                case BlockFace.East:
                default:
                    data = 0x0;
                    break;

                case BlockFace.West:
                    data = 0x1;
                    break;
            }

            Data = ((byte)((Data & 0xC) | data));

        }

        public BlockFace GetFacing()
        {
            return DescendingDirection;
        }

        public override string ToString()
        {
            return base.ToString() + " facing " + GetFacing() + (IsInverted ? " inverted" : "");
        }

    }
}
