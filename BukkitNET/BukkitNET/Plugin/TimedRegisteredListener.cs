using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Events;

namespace BukkitNET.Plugin
{
    public class TimedRegisteredListener : RegisteredListener
    {

        public TimedRegisteredListener(IListener listener, EventExecutor executor, EventPriority priority, IPlugin plugin, bool ignoreCancelled)
            : base(listener, executor, priority, plugin, ignoreCancelled)
        {
        }

        private int count;
        private long totalTime;
        private Event evt;
        private bool multiple = false;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public long TotalTime
        {
            get
            {
                return totalTime;
            }
        }

        public Event Event
        {
            get
            {
                return evt;
            }
        }

        public bool HasMultiple
        {
            get
            {
                return multiple;
            }
        }

        public new void CallEvent(Event evt)
        {
            if (evt.IsAsynchronous)
            {
                base.CallEvent(evt);
                return;
            }
            count++;
            if (this.evt == null)
            {
                this.evt = evt;
            }
            else if (!(this.evt.GetType() == evt.GetType()))
            {
                multiple = true;
            }

            long start = DateTime.Now.Ticks;
            base.CallEvent(evt);
            totalTime += DateTime.Now.Ticks - start;
        }

        public void Reset()
        {
            count = 0;
            totalTime = 0;
        }


    }

}


