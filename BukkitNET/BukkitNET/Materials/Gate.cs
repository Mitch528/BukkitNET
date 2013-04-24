using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Gate : MaterialData, IDirectional, IOpenable
    {

        private const byte OPEN_BIT = 0x4;
        private const byte DIR_BIT = 0x3;
        private const byte GATE_SOUTH = 0x0;
        private const byte GATE_WEST = 0x1;
        private const byte GATE_NORTH = 0x2;
        private const byte GATE_EAST = 0x3;

        public Gate()
            : base(Material.FenceGate)
        {
        }

        public Gate(int type)
            : base(type)
        {
        }

        public Gate(Material type)
            : base(type)
        {
        }

        public Gate(int type, byte data)
            : base(type, data)
        {
        }

        public Gate(Material type, byte data)
            : base(type, data)
        {
        }

        public void SetFacingDirection(BlockFace face)
        {

            byte data = (byte)(Data & ~DIR_BIT);

            switch (face)
            {
                default:
                case BlockFace.East:
                    data |= GATE_SOUTH;
                    break;
                case BlockFace.South:
                    data |= GATE_WEST;
                    break;
                case BlockFace.West:
                    data |= GATE_NORTH;
                    break;
                case BlockFace.North:
                    data |= GATE_EAST;
                    break;
            }

            Data = data;

        }

        public BlockFace GetFacing()
        {

            switch (Data & DIR_BIT)
            {
                case GATE_SOUTH:
                    return BlockFace.East;
                case GATE_WEST:
                    return BlockFace.South;
                case GATE_NORTH:
                    return BlockFace.West;
                case GATE_EAST:
                    return BlockFace.North;
            }

            return BlockFace.East;

        }

        public bool IsOpen()
        {
            return (Data & OPEN_BIT) > 0;
        }

        public void SetOpen(bool isOpen)
        {
            byte data = Data;

            if (isOpen)
            {
                data |= OPEN_BIT;
            }
            else
            {
                data = (byte)(Data & ~OPEN_BIT);
            }

            Data = data;
        }

    }
}
