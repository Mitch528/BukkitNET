using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Events;

namespace BukkitNET.Plugin
{
    public abstract class EventExecutor
    {
        public abstract void Execute(IListener listener, Event evt);
    }
}
