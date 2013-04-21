using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Events
{
    public class HandlerList
    {

        private volatile RegisteredListener[] handlers = null;

        private readonly Dictionary<EventPriority, List<RegisteredListener>> handlerslots;

        private static List<HandlerList> allLists = new List<HandlerList>();

        public static List<HandlerList> HandlerLists
        {
            get
            {
                return allLists;
            }
        }

        public static void BakeAll()
        {
            lock (allLists)
            {
                foreach (HandlerList h in allLists)
                {
                    h.Bake();
                }
            }
        }

        public static void UnregisterAll()
        {
            lock (allLists)
            {
                foreach (HandlerList h in allLists)
                {
                    lock (h)
                    {
                        foreach (List<RegisteredListener> list in h.handlerslots.Values)
                        {
                            list.Clear();
                        }
                        h.handlers = null;
                    }
                }
            }
        }

        public static void UnregisterAll(IPlugin plugin)
        {
            lock (allLists)
            {
                foreach (HandlerList h in allLists)
                {
                    h.Unregister(plugin);
                }
            }
        }

        public static void UnregisterAll(IListener listener)
        {
            lock (allLists)
            {
                foreach (HandlerList h in allLists)
                {
                    h.Unregister(listener);
                }
            }
        }

        public HandlerList()
        {
            handlerslots = new Dictionary<EventPriority, List<RegisteredListener>>();
            foreach (EventPriority o in Enum.GetValues(typeof(EventPriority)))
            {
                handlerslots.Add(o, new List<RegisteredListener>());
            }
            lock (allLists)
            {
                allLists.Add(this);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Register(RegisteredListener listener)
        {
            if (handlerslots[listener.Priority].Contains(listener))
                throw new Exception("This listener is already registered to priority " + listener.Priority.ToString());
            handlers = null;
            handlerslots[listener.Priority].Add(listener);
        }

        public void RegisterAll(Collection<RegisteredListener> listeners)
        {
            foreach (RegisteredListener listener in listeners)
            {
                Register(listener);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Unregister(RegisteredListener listener)
        {
            if (handlerslots[listener.Priority].Remove(listener))
            {
                handlers = null;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Unregister(IPlugin plugin)
        {
            bool changed = false;
            foreach (List<RegisteredListener> list in handlerslots.Values)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Plugin.Equals(plugin))
                    {
                        list.Remove(list[i]);
                        changed = true;
                    }
                }
            }
            if (changed) handlers = null;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Unregister(IListener listener)
        {
            bool changed = false;
            foreach (List<RegisteredListener> list in handlerslots.Values)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Listener.Equals(listener))
                    {
                        list.Remove(list[i]);
                        changed = true;
                    }
                }
            }
            if (changed) handlers = null;
        }

        public void Bake()
        {
            lock (this)
            {
                if (handlers != null) return;
                List<RegisteredListener> entries = new List<RegisteredListener>();
                foreach (var entry in handlerslots)
                {
                    entries.AddRange(entry.Value);
                }
                handlers = entries.ToArray();
            }
        }

        public RegisteredListener[] GetRegisteredListeners()
        {
            RegisteredListener[] handlers;
            while ((handlers = this.handlers) == null) Bake();
            return handlers;
        }

        public static List<RegisteredListener> GetRegisteredListeners(IPlugin plugin)
        {
            List<RegisteredListener> listeners = new List<RegisteredListener>();
            lock (allLists)
            {
                foreach (HandlerList h in allLists)
                {
                    lock (h)
                    {
                        foreach (List<RegisteredListener> list in h.handlerslots.Values)
                        {
                            foreach (RegisteredListener listener in list)
                            {
                                if (listener.Plugin.Equals(plugin))
                                {
                                    listeners.Add(listener);
                                }
                            }
                        }
                    }
                }
            }
            return listeners;
        }

    }
}
