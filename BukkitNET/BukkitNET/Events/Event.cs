using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Events
{
    public abstract class Event
    {

        private string name;
        private bool async;

        public bool IsAsynchronous
        {
            get
            {
                return async;
            }
        }

        protected Event()
            : this(false)
        {
        }

        protected Event(bool isAsync)
        {
            async = isAsync;
        }

        public string GetEventName()
        {
            if (string.IsNullOrEmpty(name))
            {
                name = GetType().Name;
            }
            return name;
        }

        public abstract HandlerList GetHandlers();

        public enum Result
        {
            Deny,
            Default,
            Allow
        }

    }
}
