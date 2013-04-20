using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class InventoryTypeInfoAttribute : Attribute
    {

        private int size;
        private string title;

        public InventoryTypeInfoAttribute(int defaultSize, string defaultTitle)
        {
            size = defaultSize;
            title = defaultTitle;
        }

    }
}
