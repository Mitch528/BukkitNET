using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EntityEffectInfoAttribute : Attribute
    {

        private byte data;

        public byte Data
        {
            get
            {
                return data;
            }
        }

        public EntityEffectInfoAttribute(int data)
        {
            this.data = (byte)data;
        }

    }
}
