using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class StatisticInfoAttribute : Attribute
    {

        private int id;
        private bool isBlock;
        private bool isSubstat;

        public int Id
        {
            get
            {
                return id;
            }
        }

        public bool IsBlock
        {
            get
            {
                return isBlock && isSubstat;
            }
        }

        public bool IsSubstatistic
        {
            get
            {
                return isSubstat;
            }
        }

        public StatisticInfoAttribute(int id)
            : this(id, false, false)
        {
        }

        public StatisticInfoAttribute(int id, bool isBlock)
            : this(id, true, isBlock)
        {
        }

        public StatisticInfoAttribute(int id, bool isSubstat, bool isBlock)
        {
            this.id = id;
            this.isSubstat = isSubstat;
            this.isBlock = isBlock;
        }

    }
}
