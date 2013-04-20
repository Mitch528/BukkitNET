using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Events.InventoryEvents;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InventoryPropertyInfoAttribute : Attribute
    {

        private int id;
        private InventoryType style;

        public InventoryType InventoryType
        {
            get
            {
                return style;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public InventoryPropertyInfoAttribute(int id, InventoryType appliesTo)
        {
            this.id = id;
            this.style = appliesTo;
        }

    }
}
