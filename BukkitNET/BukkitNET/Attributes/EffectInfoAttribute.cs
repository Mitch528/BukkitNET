using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EffectInfoAttribute : Attribute
    {

        private int id;
        private EffectType type;
        private Type data;

        public int Id
        {
            get
            {
                return id;
            }
        }

        public EffectType Type
        {
            get
            {
                return type;
            }
        }

        public Type Data
        {
            get
            {
                return data;
            }
        }

        public EffectInfoAttribute(int id, EffectType type)
            : this(id, type, null)
        {
        }

        public EffectInfoAttribute(int id, EffectType type, Type data)
        {
            this.id = id;
            this.type = type;
            this.data = data;
        }



    }
}
