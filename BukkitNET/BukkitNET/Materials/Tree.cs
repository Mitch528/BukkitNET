using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Tree : MaterialData
    {

        public TreeSpecies Species
        {
            get
            {
                return (TreeSpecies)((byte)(Data & 0x3));
            }
            set
            {
                Data = ((byte)((Data & 0xC) | (byte)value));
            }
        }

        public Tree()
            : base(Material.Log)
        {
        }

        public Tree(TreeSpecies species) : this()
        {
            Species = species;
        }

        public Tree(TreeSpecies species, BlockFace dir) : this()
        {
            Species = species;
            SetDirection(dir);
        }

        public Tree(int type)
            : base(type)
        {
        }

        public Tree(Material type)
            : base(type)
        {
        }

        public Tree(int type, byte data)
            : base(type, data)
        {
        }

        public Tree(Material type, byte data)
            : base(type, data)
        {
        }

        public BlockFace GetDirection()
        {
            switch ((Data >> 2) & 0x3)
            {
                case 0:
                default:
                    return BlockFace.Up;
                case 1:
                    return BlockFace.West;
                case 2:
                    return BlockFace.North;
                case 3:
                    return BlockFace.Self;
            }
        }

        public void SetDirection(BlockFace dir)
        {
            int dat;
            switch (dir)
            {
                case BlockFace.Up:
                case BlockFace.Down:
                default:
                    dat = 0;
                    break;
                case BlockFace.West:
                case BlockFace.East:
                    dat = 1;
                    break;
                case BlockFace.North:
                case BlockFace.South:
                    dat = 2;
                    break;
                case BlockFace.Self:
                    dat = 3;
                    break;
            }
            Data = ((byte)((Data & 0x3) | (dat << 2)));
        }

    }
}
