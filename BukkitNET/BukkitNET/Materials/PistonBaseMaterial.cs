using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class PistonBaseMaterial : MaterialData, IDirectional, IRedstone
    {

        public PistonBaseMaterial(int type)
            : base(type)
        {
        }

        public PistonBaseMaterial(Material type)
            : base(type)
        {
        }

        public PistonBaseMaterial(int type, byte data)
            : base(type, data)
        {
        }

        public PistonBaseMaterial(Material type, byte data)
            : base(type, data)
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

        public bool IsPowered()
        {
            return (Data & 0x8) == 0x8;
        }

        public void SetPowered(bool powered)
        {
            Data = ((byte)(powered ? (Data | 0x8) : (Data & ~0x8)));
        }

        public bool IsSticky()
        {
            return this.ItemType == Material.PistonStickyBase;
        }

    }
}
