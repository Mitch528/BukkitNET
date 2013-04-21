using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PermissionDefaultInfoAttribute : Attribute
    {

        private string[] names;

        public string[] Names
        {
            get
            {
                return names;
            }
        }

        public PermissionDefaultInfoAttribute(params string[] names)
        {
            this.names = names;
        }

    }
}
