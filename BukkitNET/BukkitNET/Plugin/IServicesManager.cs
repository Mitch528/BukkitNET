using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BukkitNET.Plugin
{
    public interface IServicesManager
    {

        T Register<T>(Type service, T provider, IPlugin plugin, ServicePriority priority);

        void UnregisterAll(IPlugin plugin);

        void Unregister(Type service, object provider);

        void Unregister(object provider);

        T Load<T>(Type service);

        RegisteredServiceProvider<T> GetRegistration<T>(Type service);

        List<RegisteredServiceProvider<T>> GetRegistrations<T>(IPlugin plugin);

        Collection<RegisteredServiceProvider<T>> GetRegistrations<T>(Type service);

        Collection<Type> GetKnownServices();

        bool IsProvidedFor(Type service);

    }
}
