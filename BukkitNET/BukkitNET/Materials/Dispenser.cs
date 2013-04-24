using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Dispenser : FurnaceAndDispenser
    {

        public Dispenser()
            : base(Material.Dispenser)
        {
        }

        public Dispenser(BlockFace direction)
            : this()
        {
            SetFacingDirection(direction);
        }

        public Dispenser(int type)
            : base(type)
        {
        }

        public Dispenser(Material type)
            : base(type)
        {
        }

        public Dispenser(int type, byte data)
            : base(type, data)
        {
        }

        public Dispenser(Material type, byte data)
            : base(type, data)
        {
        }

        public new void SetFacingDirection(BlockFace face)
        {
            byte data;

            switch (face)
            {
                case BlockFace.Down:
                    data = 0x0;
                    break;

                case BlockFace.Up:
                    data = 0x1;
                    break;

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


            Data = data;

        }

        public new BlockFace GetFacing()
        {
            int data = Data & 0x7;

            switch (data)
            {
                case 0x0:
                    return BlockFace.Down;

                case 0x1:
                    return BlockFace.Up;

                case 0x2:
                    return BlockFace.North;

                case 0x3:
                    return BlockFace.South;

                case 0x4:
                    return BlockFace.West;

                case 0x5:
                default:
                    return BlockFace.East;
            }
        }

    }
}
