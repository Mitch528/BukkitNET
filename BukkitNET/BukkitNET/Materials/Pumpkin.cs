using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Pumpkin : MaterialData, IDirectional
    {

        public Pumpkin()
            : base(Material.Pumpkin)
        {
        }

        public Pumpkin(int type)
            : base(type)
        {
        }

        public Pumpkin(Material type)
            : base(type)
        {
        }

        public Pumpkin(int type, byte data)
            : base(type, data)
        {
        }

        public Pumpkin(Material type, byte data)
            : base(type, data)
        {
        }

        public void SetFacingDirection(BlockFace face)
        {

            byte data;

            switch (face)
            {
                case BlockFace.North:
                    data = 0x0;
                    break;

                case BlockFace.East:
                    data = 0x1;
                    break;

                case BlockFace.South:
                    data = 0x2;
                    break;

                case BlockFace.West:
                default:
                    data = 0x3;
                    break;
            }

            Data = data;

        }

        public BlockFace GetFacing()
        {

            byte data = Data;

            switch (data)
            {
                case 0x0:
                    return BlockFace.North;

                case 0x1:
                    return BlockFace.East;

                case 0x2:
                    return BlockFace.South;

                case 0x3:
                default:
                    return BlockFace.East;
            }

        }

        public bool IsLit()
        {
            return ItemType == Material.JackOLantern;
        }

        public override string ToString()
        {
            return base.ToString() + " facing " + GetFacing() + " " + (IsLit() ? "" : "NOT ") + "LIT";
        }



    }
}
