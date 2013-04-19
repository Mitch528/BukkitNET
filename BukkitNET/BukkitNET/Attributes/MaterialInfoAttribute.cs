using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BukkitNET.Materials;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class MaterialInfoAttribute : Attribute
    {

        private int id;
        private ConstructorInfo ctor;
        private int maxStack;
        private short durability;

        public int Id
        {
            get
            {
                return id;
            }
        }

        public int MaxStackSize
        {
            get
            {
                return maxStack;
            }
        }

        public int MaxDurability
        {
            get
            {
                return durability;
            }
        }

        public ConstructorInfo ConstructorInfo
        {
            get
            {
                return ctor;
            }
        }

        public MaterialInfoAttribute(int id)
            : this(id, 64)
        {
        }

        public MaterialInfoAttribute(int id, int stack)
            : this(id, stack, typeof(MaterialData))
        {
        }

        public MaterialInfoAttribute(int id, int stack, int durability)
            : this(id, stack, durability, typeof(MaterialData))
        {
        }

        public MaterialInfoAttribute(int id, Type data)
            : this(id, 64, data)
        {
        }

        public MaterialInfoAttribute(int id, int stack, Type data)
            : this(id, stack, 0, data)
        {
        }

        public MaterialInfoAttribute(int id, int stack, int durability, Type data)
        {

            if (!data.IsAssignableFrom(typeof(MaterialData)))
            {
                throw new ArgumentException("data must inherit MaterialData!");
            }

            this.id = id;
            this.durability = (short)durability;
            this.maxStack = stack;
            this.ctor = data.GetConstructor(new[] { typeof(int), typeof(byte) });

        }

    }
}
