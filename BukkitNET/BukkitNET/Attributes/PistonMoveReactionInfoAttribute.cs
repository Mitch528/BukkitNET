using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PistonMoveReactionInfoAttribute : Attribute
    {

        private int id;

        public int Id
        {
            get
            {
                return id;
            }
        }

        public PistonMoveReactionInfoAttribute(int id)
        {
            this.id = id;
        }


    }
}
