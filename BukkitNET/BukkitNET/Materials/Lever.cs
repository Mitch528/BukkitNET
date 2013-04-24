using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Lever : SimpleAttachableMaterialData, IRedstone
    {

        public Lever()
            : base(Material.Lever)
        {
        }

        public Lever(int type, BlockFace direction)
            : base(type, direction)
        {
        }

        public Lever(Material type, BlockFace direction)
            : base(type, direction)
        {
        }

        public Lever(int type)
            : base(type)
        {
        }

        public Lever(Material type)
            : base(type)
        {
        }

        public Lever(int type, byte data)
            : base(type, data)
        {
        }

        public Lever(Material type, byte data)
            : base(type, data)
        {
        }

        public override BlockFace GetAttachedFace()
        {

            byte data = (byte)(Data & 0x7);

            switch (data)
            {
                case 0x1:
                    return BlockFace.West;

                case 0x2:
                    return BlockFace.East;

                case 0x3:
                    return BlockFace.North;

                case 0x4:
                    return BlockFace.South;

                case 0x5:
                case 0x6:
                    return BlockFace.Down;

                case 0x0:
                case 0x7:
                    return BlockFace.Up;

            }

            return default(BlockFace);

        }

        public bool IsPowered()
        {
            return (Data & 0x8) == 0x8;
        }

        public void SetPowered(bool isPowered)
        {
            Data = ((byte)(isPowered ? (Data | 0x8) : (Data & ~0x8)));
        }

        public new void SetFacingDirection(BlockFace face)
        {
            byte data = (byte)(Data & 0x8);
            BlockFace attach = GetAttachedFace();

            if (attach == BlockFace.Down)
            {
                switch (face)
                {
                    case BlockFace.South:
                    case BlockFace.North:
                        data |= 0x5;
                        break;

                    case BlockFace.East:
                    case BlockFace.West:
                        data |= 0x6;
                        break;
                }
            }
            else if (attach == BlockFace.Up)
            {
                switch (face)
                {
                    case BlockFace.South:
                    case BlockFace.North:
                        data |= 0x7;
                        break;

                    case BlockFace.East:
                    case BlockFace.West:
                        data |= 0x0;
                        break;
                }
            }
            else
            {
                switch (face)
                {
                    case BlockFace.East:
                        data |= 0x1;
                        break;

                    case BlockFace.West:
                        data |= 0x2;
                        break;

                    case BlockFace.South:
                        data |= 0x3;
                        break;

                    case BlockFace.North:
                        data |= 0x4;
                        break;
                }
            }
            Data = data;
        }

        public override string ToString()
        {
            return base.ToString() + " facing " + GetFacing() + " " + (IsPowered() ? "" : "NOT ") + "POWERED";
        }

    }
}
