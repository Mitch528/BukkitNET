using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Maps
{

    public sealed class MapCursor
    {

        private byte x, y;
        private byte direction, type;
        private bool visible;

        public byte X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public byte Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public byte Direction
        {
            get
            {
                return direction;
            }
            set
            {
                if (direction < 0 || direction > 15)
                {
                    throw new ArgumentException("Direction must be in the range 0-15");
                }
                direction = direction;
            }
        }

        public CursorType Type
        {
            get
            {
                return (CursorType)type;
            }
            set
            {
                type = (byte)value;
            }
        }


        public byte RawType
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public bool IsVisible
        {
            get
            {
                return visible;
            }
        }

        public MapCursor(byte x, byte y, byte direction, byte type, bool visible)
        {
            this.x = x;
            this.y = y;
            this.Direction = direction;
            this.RawType = type;
            this.visible = visible;
        }

        public enum CursorType : byte
        {
            WhitePointer = 0,
            GreenPointer = 1,
            RedPointer = 2,
            BluePointer = 3,
            WhiteCross = 4,
        }

    }

}
