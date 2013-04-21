using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Events;
namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class EventHandlerAttribute : Attribute
    {

        private EventPriority priority;

        private bool ignore;

        public EventPriority Priority
        {
            get
            {
                return priority;
            }
        }

        public bool IgnoreCancelled
        {
            get
            {
                return ignore;
            }
        }

        public EventHandlerAttribute(EventPriority priority) : this(priority, false)
        {
        }

        public EventHandlerAttribute(bool ignore) : this(EventPriority.Normal, ignore)
        {
        }

        public EventHandlerAttribute(EventPriority priority, bool ignore)
        {
            this.priority = priority;
            this.ignore = ignore;
        }

    }
}
