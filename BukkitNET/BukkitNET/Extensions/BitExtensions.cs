using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Extensions
{
    public static class BitExtensions
    {

        public static int SingleToInt32Bits(this float value)
        {
            return BitConverter.ToInt32(BitConverter.GetBytes(value), 0);
        }

    }
}
