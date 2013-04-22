using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class WorldTypeInfoAttribute : Attribute
    {

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public WorldTypeInfoAttribute(string name)
        {
            this.name = name;
        }

    }
}
