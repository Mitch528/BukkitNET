using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET
{

    public enum CoalType
    {

        Coal = 0x0,
        Charcoal = 0x1

    }

    public static class CoalTypeHelper
    {

        public static CoalType GetByData(byte data)
        {
            return (CoalType)data;
        }

    }

}
