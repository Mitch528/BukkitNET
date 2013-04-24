using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public abstract class Button : SimpleAttachableMaterialData, IRedstone
    {

        protected Button()
            : base(Material.StoneButton)
        {
        }

        protected Button(int type, BlockFace direction)
            : base(type, direction)
        {
        }

        protected Button(Material type, BlockFace direction)
            : base(type, direction)
        {
        }

        protected Button(int type)
            : base(type)
        {
        }

        protected Button(Material type)
            : base(type)
        {
        }

        protected Button(int type, byte data)
            : base(type, data)
        {
        }

        protected Button(Material type, byte data)
            : base(type, data)
        {
        }

        public bool IsPowered()
        {
            return (Data & 0x8) == 0x8;
        }

        public void SetPowered(bool powered)
        {
            Data = ((byte)(powered ? (Data | 0x8) : (Data & ~0x8)));
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
            }

            return default(BlockFace);
        }

        public void SetFacingDirection(BlockFace face)
        {
            byte data = (byte)(Data & 0x8);

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

            Data = data;
        }

        public override string ToString()
        {
            return base.ToString() + " " + (IsPowered() ? "" : "NOT ") + "POWERED";
        }

    }
}
