using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ToneInfoAttribute : Attribute
    {

        private bool sharpable;
        private byte id;

        public const byte TONES_COUNT = 12;

        public bool IsSharpable
        {
            get
            {
                return sharpable;
            }
        }

        public byte Id
        {
            get
            {
                return id;
            }
        }

        public ToneInfoAttribute(int id, bool sharpable)
        {
            this.id = (byte)(id % TONES_COUNT);
            this.sharpable = sharpable;
        }


    }
}
