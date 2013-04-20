using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnvironmentInfoAttribute : Attribute
    {

        private int id;

        public int Id
        {
            get
            {
                return id;
            }
        }

        public EnvironmentInfoAttribute(int id)
        {
            this.id = id;
        }

    }
}
