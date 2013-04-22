using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Extensions;

namespace BukkitNET
{

    public enum WorldType
    {

        [WorldTypeInfo("NORMAL")]
        Normal,

        [WorldTypeInfo("FLAT")]
        Flat,
        
        [WorldTypeInfo("DEFAULT_1_1")]
        Version1_1,
        
        [WorldTypeInfo("LARGEBIOMES")]
        LargeBiomes

    }

    public static class WorldTypeHelper
    {

        private static Dictionary<string, WorldType> BY_NAME = new Dictionary<string, WorldType>();

        static WorldTypeHelper()
        {
            foreach (WorldType type in Enum.GetValues(typeof(WorldType)))
            {
                BY_NAME.Add(type.GetAttribute<WorldTypeInfoAttribute>().Name, type);
            }
        }

        public static WorldType GetByName(string name)
        {
            return BY_NAME[name.ToUpper()];
        }

    }

}
