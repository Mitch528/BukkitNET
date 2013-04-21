using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BukkitNET.Events;

namespace BukkitNET.Plugin
{
    public class PluginEventExecutor : EventExecutor
    {

        private Type eventType;

        private MethodInfo methodInfo;

        public PluginEventExecutor(Type eventType, MethodInfo mInfo)
        {
            this.eventType = eventType;
            this.methodInfo = mInfo;
        }

        public override void Execute(IListener listener, Event evt)
        {

            if (evt.GetType().IsAssignableFrom(eventType))
            {
                methodInfo.Invoke(listener, new object[] { evt });
            }

        }

    }
}
