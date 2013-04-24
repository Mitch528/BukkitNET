using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class TrapDoor : SimpleAttachableMaterialData, IOpenable
    {

        public bool IsInverted
        {
            get
            {
                return ((Data & 0x8) != 0);
            }
            set
            {

                int dat = Data & 0x7;
                if (value)
                {
                    dat |= 0x8;
                }
                Data = ((byte)dat);

            }
        }

        public TrapDoor()
            : base(Material.TrapDoor)
        {
        }

        public TrapDoor(int type, BlockFace direction)
            : base(type, direction)
        {
        }

        public TrapDoor(Material type, BlockFace direction)
            : base(type, direction)
        {
        }

        public TrapDoor(int type)
            : base(type)
        {
        }

        public TrapDoor(Material type)
            : base(type)
        {
        }

        public TrapDoor(int type, byte data)
            : base(type, data)
        {
        }

        public TrapDoor(Material type, byte data)
            : base(type, data)
        {
        }

        public override BlockFace GetAttachedFace()
        {

            byte data = (byte)(Data & 0x3);

            switch (data)
            {
                case 0x0:
                    return BlockFace.South;

                case 0x1:
                    return BlockFace.North;

                case 0x2:
                    return BlockFace.East;

                case 0x3:
                    return BlockFace.West;
            }

            return default(BlockFace);

        }

        public new void SetFacingDirection(BlockFace face)
        {
            byte data = (byte)(Data & 0xC);

            switch (face)
            {
                case BlockFace.South:
                    data |= 0x1;
                    break;
                case BlockFace.West:
                    data |= 0x2;
                    break;
                case BlockFace.East:
                    data |= 0x3;
                    break;
            }

            Data = data;
        }

        public bool IsOpen()
        {
            return ((Data & 0x4) == 0x4);
        }

        public void SetOpen(bool isOpen)
        {

            byte data = Data;

            if (isOpen)
            {
                data |= 0x4;
            }
            else
            {
                data &= (byte)(Data & ~0x4);
            }

            Data = data;

        }

        public override string ToString()
        {
            return (IsOpen() ? "OPEN " : "CLOSED ") + base.ToString() + " with hinges set " + GetAttachedFace() + (IsInverted ? " inverted" : "");
        }

    }
}
