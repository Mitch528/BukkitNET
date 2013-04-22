using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Extensions
{
    public static class NumericExtensions
    {

        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }

        //http://stackoverflow.com/questions/677373/generate-random-values-in-c-sharp
        public static Int64 NextInt64(this Random rnd)
        {
            var buffer = new byte[sizeof(Int64)];
            rnd.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }

    }
}
