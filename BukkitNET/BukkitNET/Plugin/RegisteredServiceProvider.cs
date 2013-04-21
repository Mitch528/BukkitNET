using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Plugin
{
    public class RegisteredServiceProvider<T> : IComparable<RegisteredServiceProvider<T>>
    {

        private Type service;
        private IPlugin plugin;
        private T provider;
        private ServicePriority priority;

        public Type GetService
        {
            get
            {
                return service;
            }
        }

        public IPlugin Plugin
        {
            get
            {
                return plugin;
            }
        }

        public T Provider
        {
            get
            {
                return provider;
            }
        }

        public ServicePriority Priority
        {
            get
            {
                return priority;
            }
        }

        public int CompareTo(RegisteredServiceProvider<T> other)
        {

            if ((int)priority == (int)other.priority)
            {
                return 0;
            }
            else
            {
                return (int)priority < (int)other.priority ? 1 : -1;
            }

        }

    }
}
