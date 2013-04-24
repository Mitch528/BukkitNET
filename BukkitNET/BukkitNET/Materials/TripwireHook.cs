using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class TripwireHook : SimpleAttachableMaterialData, IRedstone
    {

        public bool IsConnected
        {
            get
            {
                return (Data & 0x4) != 0;
            }
            set
            {
                int dat = Data & (0x8 | 0x3);
                if (value)
                {
                    dat |= 0x4;
                }
                Data = ((byte)dat);
            }
        }

        public bool IsActivated
        {
            get
            {
                return (Data & 0x8) != 0;
            }
            set
            {

                int dat = Data & (0x4 | 0x3);
                if (value)
                {
                    dat |= 0x8;
                }
                Data = ((byte)dat);

            }
        }

        public TripwireHook()
            : base(Material.TripwireHook)
        {
        }

        public TripwireHook(int type, BlockFace direction)
            : base(type, direction)
        {
        }

        public TripwireHook(Material type, BlockFace direction)
            : base(type, direction)
        {
        }

        public TripwireHook(int type)
            : base(type)
        {
        }

        public TripwireHook(Material type)
            : base(type)
        {
        }

        public TripwireHook(int type, byte data)
            : base(type, data)
        {
        }

        public TripwireHook(Material type, byte data)
            : base(type, data)
        {
        }

        public override BlockFace GetAttachedFace()
        {

            switch (Data & 0x3)
            {
                case 0:
                    return BlockFace.North;
                case 1:
                    return BlockFace.East;
                case 2:
                    return BlockFace.South;
                case 3:
                    return BlockFace.West;
            }
            return default(BlockFace);

        }

        public bool IsPowered()
        {
            return IsActivated;
        }

        public new void SetFacingDirection(BlockFace face)
        {
            int dat = Data & 0xC;
            switch (face)
            {
                case BlockFace.West:
                    dat |= 0x1;
                    break;
                case BlockFace.North:
                    dat |= 0x2;
                    break;
                case BlockFace.East:
                    dat |= 0x3;
                    break;
                case BlockFace.South:
                default:
                    break;
            }
            Data = ((byte)dat);
        }

        public override string ToString()
        {
            return base.ToString() + " facing " + GetFacing() + (IsActivated ? " Activated" : "") + (IsConnected ? " Connected" : "");
        }

    }
}
