using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class CocoaPlant : MaterialData, IAttachable
    {

        public CocoaPlantSize Size
        {
            get
            {
                switch (Data & 0xC)
                {
                    case 0:
                        return CocoaPlantSize.Small;
                    case 4:
                        return CocoaPlantSize.Medium;
                    default:
                        return CocoaPlantSize.Large;
                }
            }
            set
            {

                int dat = Data & 0x3;
                switch (value)
                {
                    case CocoaPlantSize.Small:
                        break;
                    case CocoaPlantSize.Medium:
                        dat |= 0x4;
                        break;
                    case CocoaPlantSize.Large:
                        dat |= 0x8;
                        break;
                }

                Data = ((byte)dat);

            }
        }

        public CocoaPlant()
            : base(Material.Cocoa)
        {
        }

        public CocoaPlant(CocoaPlantSize sz, BlockFace dir)
            : this()
        {
            Size = sz;
            SetFacingDirection(dir);
        }

        public CocoaPlant(int type)
            : base(type)
        {
        }

        public CocoaPlant(Material type)
            : base(type)
        {
        }

        public CocoaPlant(int type, byte data)
            : base(type, data)
        {
        }

        public CocoaPlant(Material type, byte data)
            : base(type, data)
        {
        }

        public void SetFacingDirection(BlockFace face)
        {

            int dat = Data & 0xC;
            switch (face)
            {
                default:
                case BlockFace.South:
                    break;
                case BlockFace.West:
                    dat |= 0x1;
                    break;
                case BlockFace.North:
                    dat |= 0x2;
                    break;
                case BlockFace.East:
                    dat |= 0x3;
                    break;
            }
            Data = ((byte)dat);

        }

        public BlockFace GetFacing()
        {

            switch (Data & 0x3)
            {
                case 0:
                    return BlockFace.South;
                case 1:
                    return BlockFace.West;
                case 2:
                    return BlockFace.North;
                case 3:
                    return BlockFace.East;
            }

            return default(BlockFace);

        }

        public BlockFace GetAttachedFace()
        {
            return GetFacing().GetOppositeFace();
        }
    }

    public enum CocoaPlantSize
    {
        Small,
        Medium,
        Large
    }

}
