using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ChatColorInfoAttribute : Attribute
    {

        private int intCode;
        private char code;
        private bool isFormat;
        private string toString;

        private const char COLOR_CHAR = '\u00A7';

        public char Character
        {
            get
            {
                return code;
            }
        }

        public bool IsFormat
        {
            get
            {
                return isFormat;
            }
        }

        public int IntCode
        {
            get
            {
                return intCode;
            }
        }

        public ChatColorInfoAttribute(char code, int intCode)
            : this(code, intCode, false)
        {
        }

        public ChatColorInfoAttribute(char code, int intCode, bool isFormat)
        {
            this.code = code;
            this.intCode = intCode;
            this.isFormat = isFormat;
            this.toString = new String(new char[] { COLOR_CHAR, code });
        }

        public override string ToString()
        {
            return toString;
        }

    }
}
