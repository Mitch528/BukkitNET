using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Diode : MaterialData, IDirectional
    {

        public int Delay
        {
            get
            {
                return (Data >> 2) + 1;
            }
            set
            {
                if (value > 4)
                {
                    value = 4;
                }
                if (value < 1)
                {
                    value = 1;
                }
                byte newData = (byte)(Data & 0x3);

                Data = ((byte)(newData | ((value - 1) << 2)));
            }
        }

        public Diode()
            : base(Material.DiodeBlockOn)
        {
        }

        public Diode(int type)
            : base(type)
        {
        }

        public Diode(Material type)
            : base(type)
        {
        }

        public Diode(int type, byte data)
            : base(type, data)
        {
        }

        public Diode(Material type, byte data)
            : base(type, data)
        {
        }

        public void SetDelay(int delay)
        {
            if (delay > 4)
            {
                delay = 4;
            }
            if (delay < 1)
            {
                delay = 1;
            }
            byte newData = (byte)(Data & 0x3);

            Data = ((byte)(newData | ((delay - 1) << 2)));
        }


        public void SetFacingDirection(BlockFace face)
        {
            int delay = Delay;
            byte data;

            switch (face)
            {
                case BlockFace.East:
                    data = 0x1;
                    break;

                case BlockFace.South:
                    data = 0x2;
                    break;

                case BlockFace.West:
                    data = 0x3;
                    break;

                case BlockFace.North:
                default:
                    data = 0x0;
                    break;
            }

            Data = data;
            Delay = delay;
        }

        public BlockFace GetFacing()
        {

            byte data = (byte)(Data & 0x3);

            switch (data)
            {
                case 0x0:
                default:
                    return BlockFace.North;

                case 0x1:
                    return BlockFace.East;

                case 0x2:
                    return BlockFace.South;

                case 0x3:
                    return BlockFace.West;
            }

        }

        public override string ToString()
        {
            return base.ToString() + " facing " + GetFacing() + " with " + Delay + " ticks delay";
        }

    }
}
