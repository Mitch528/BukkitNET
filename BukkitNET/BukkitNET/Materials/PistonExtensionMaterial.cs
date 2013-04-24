using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class PistonExtensionMaterial : MaterialData, IAttachable
    {

        public bool IsSticky
        {
            get
            {
                return (Data & 8) == 8;
            }
            set
            {
                Data = (byte)(value ? (Data | 0x8) : (Data & ~0x8));
            }
        }

        public PistonExtensionMaterial(int type) : base(type)
        {
        }

        public PistonExtensionMaterial(Material type) : base(type)
        {
        }

        public PistonExtensionMaterial(int type, byte data) : base(type, data)
        {
        }

        public PistonExtensionMaterial(Material type, byte data) : base(type, data)
        {
        }

        public void SetFacingDirection(BlockFace face)
        {
            byte data = (byte)(Data & 0x8);

            switch (face)
            {
                case BlockFace.Up:
                    data |= 1;
                    break;
                case BlockFace.North:
                    data |= 2;
                    break;
                case BlockFace.South:
                    data |= 3;
                    break;
                case BlockFace.West:
                    data |= 4;
                    break;
                case BlockFace.East:
                    data |= 5;
                    break;
            }
            Data = data;
        }

        public BlockFace GetFacing()
        {
            byte dir = (byte)(Data & 7);

            switch (dir)
            {
                case 0:
                    return BlockFace.Down;
                case 1:
                    return BlockFace.Up;
                case 2:
                    return BlockFace.North;
                case 3:
                    return BlockFace.South;
                case 4:
                    return BlockFace.West;
                case 5:
                    return BlockFace.East;
                default:
                    return BlockFace.Self;
            }
        }

        public BlockFace GetAttachedFace()
        {
            return GetFacing().GetOppositeFace();
        }

    }
}
