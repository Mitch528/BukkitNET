using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Events;

namespace BukkitNET.Plugin
{
    public class RegisteredListener
    {

        private IListener listener;
        private EventPriority priority;
        private IPlugin plugin;
        private EventExecutor executor;
        private bool ignoreCancelled;

        public IListener Listener
        {
            get
            {
                return listener;
            }
        }

        public IPlugin Plugin
        {
            get
            {
                return plugin;
            }
        }

        public EventPriority Priority
        {
            get
            {
                return priority;
            }
        }

        public bool IsIgnoringCancelled
        {
            get
            {
                return ignoreCancelled;
            }
        }

        public RegisteredListener(IListener listener, EventExecutor executor, EventPriority priority, IPlugin plugin, bool ignoreCancelled)
        {
            this.listener = listener;
            this.priority = priority;
            this.plugin = plugin;
            this.executor = executor;
            this.ignoreCancelled = ignoreCancelled;
        }

        public void CallEvent(Event evt)
        {
            if (evt is ICancellable)
            {
                if (((ICancellable)evt).IsCancelled() && ignoreCancelled)
                {
                    return;
                }
            }
            executor.Execute(listener, evt);
        }

    }
}
