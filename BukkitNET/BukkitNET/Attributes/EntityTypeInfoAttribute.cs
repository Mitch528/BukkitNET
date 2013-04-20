using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EntityTypeInfoAttribute : Attribute
    {

        private string name;
        private Type type;
        private short typeId;
        private bool independent, living;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Type Type
        {
            get
            {
                return type;
            }
        }

        public short TId
        {
            get
            {
                return typeId;
            }
        }

        public bool Independent
        {
            get
            {
                return independent;
            }
        }

        public bool Living
        {
            get
            {
                return living;
            }
        }

        public EntityTypeInfoAttribute(string name, Type type, int typeId)
            : this(name, type, typeId, true)
        {
        }

        public EntityTypeInfoAttribute(string name, Type type, int typeId, bool independent)
        {
            this.name = name;
            this.type = type;
            this.typeId = (short)typeId;
            this.independent = independent;
            if (type != null)
            {
                this.living = typeof(ILivingEntity).IsAssignableFrom(type);
            }
        }

    }
}
