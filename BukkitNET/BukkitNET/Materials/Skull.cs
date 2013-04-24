using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Skull : MaterialData, IDirectional
    {

        public Skull()
            : base(Material.Skull)
        {
        }

        public Skull(BlockFace direction)
            : this()
        {
            SetFacingDirection(direction);
        }

        public Skull(int type)
            : base(type)
        {
        }

        public Skull(Material type)
            : base(type)
        {
        }

        public Skull(int type, byte data)
            : base(type, data)
        {
        }

        public Skull(Material type, byte data)
            : base(type, data)
        {
        }

        public void SetFacingDirection(BlockFace face)
        {

            int data;

            switch (face)
            {
                case BlockFace.Self:
                default:
                    data = 0x1;
                    break;

                case BlockFace.North:
                    data = 0x2;
                    break;

                case BlockFace.East:
                    data = 0x4;
                    break;

                case BlockFace.South:
                    data = 0x3;
                    break;

                case  BlockFace.West:
                    data = 0x5;

                    break;

            }

            Data = ((byte)data);

        }

        public BlockFace GetFacing()
        {

            int data = Data;

            switch (data)
            {
                case 0x1:
                default:
                    return BlockFace.Self;

                case 0x2:
                    return BlockFace.North;

                case 0x3:
                    return BlockFace.South;

                case 0x4:
                    return BlockFace.East;

                case 0x5:
                    return BlockFace.West;
            }

        }

        public override string ToString()
        {
            return base.ToString() + " facing " + GetFacing();
        }

    }
}
