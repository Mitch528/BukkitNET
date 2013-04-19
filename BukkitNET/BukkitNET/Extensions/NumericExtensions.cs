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
    }
}
