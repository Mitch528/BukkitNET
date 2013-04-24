using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CreatureTypeInfoAttribute : Attribute
    {

        private string name;
        private Type entityType;
        private short typeId;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Type EntityType
        {
            get
            {
                return entityType;
            }
        }

        public short CreatureTypeId
        {
            get
            {
                return typeId;
            }
        }

        public CreatureTypeInfoAttribute(string name, Type entityType, int typeId)
        {
            this.name = name;
            this.entityType = entityType;
            this.typeId = (short)typeId;
        }

    }
}
