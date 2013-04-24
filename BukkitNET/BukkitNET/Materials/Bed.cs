using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public abstract class Bed : MaterialData, IDirectional
    {

        protected Bed()
            : base(Material.BedBlock)
        {
        }

        protected Bed(BlockFace direction)
            : this()
        {
            SetFacingDirection(direction);
        }

        protected Bed(int type)
            : base(type)
        {
        }

        protected Bed(Material type)
            : base(type)
        {
        }

        protected Bed(int type, byte data)
            : base(type, data)
        {
        }

        protected Bed(Material type, byte data)
            : base(type, data)
        {
        }

        public bool IsHeadOfBed()
        {
            return (Data & 0x8) == 0x8;
        }

        public void SetHeadOfBed(bool isHeadOfBed)
        {
            Data = ((byte)(isHeadOfBed ? (Data | 0x8) : (Data & ~0x8)));
        }

        public void SetFacingDirection(BlockFace face)
        {

            byte data;

            switch (face)
            {
                case BlockFace.South:
                    data = 0x0;
                    break;

                case BlockFace.West:
                    data = 0x1;
                    break;

                case BlockFace.North:
                    data = 0x2;
                    break;

                case BlockFace.East:

                default:
                    data = 0x3;

                    break;

            }

            if (IsHeadOfBed())
            {
                data |= 0x8;
            }

            Data = data;

        }

        public BlockFace GetFacing()
        {

            byte data = (byte)(Data & 0x7);

            switch (data)
            {
                case 0x0:
                    return BlockFace.South;

                case 0x1:
                    return BlockFace.West;

                case 0x2:
                    return BlockFace.North;

                case 0x3:
                default:
                    return BlockFace.East;
            }

        }

        public override string ToString()
        {
            return (IsHeadOfBed() ? "HEAD" : "FOOT") + " of " + base.ToString() + " facing " + GetFacing();
        }

        public Bed Clone()
        {
            return (Bed)base.Clone();
        }

    }
}
