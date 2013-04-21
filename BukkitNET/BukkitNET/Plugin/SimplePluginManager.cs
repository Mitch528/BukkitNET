using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using BukkitNET.Commands;
using BukkitNET.Events;
using BukkitNET.Permissions;

namespace BukkitNET.Plugin
{
    public class SimplePluginManager : IPluginManager
    {

        private Server server;
        private List<IPlugin> plugins = new List<IPlugin>();
        private Dictionary<String, IPlugin> lookupNames = new Dictionary<String, Plugin>();
        private static FileInfo updateDirectory = null;
        private SimpleCommandMap commandMap;
        private Dictionary<string, Permission> permissions = new Dictionary<string, Permission>();
        private Dictionary<bool, HashSet<Permission>> defaultPerms = new Dictionary<bool, HashSet<Permission>>();
        private Dictionary<string, Dictionary<WeakReference, WeakReference>> permSubs = new Dictionary<string, Dictionary<WeakReference, WeakReference>>();
        private Dictionary<bool, Dictionary<WeakReference, WeakReference>> defSubs = new Dictionary<bool, Dictionary<WeakReference, WeakReference>>();
        private bool useTimings = false;

        private static AppDomain pluginAppDomain = AppDomain.CreateDomain("BukkitNETPlugins");

        private static Type proxyType = typeof(PluginProxy);
        private static PluginProxy _proxy = (PluginProxy)pluginAppDomain.CreateInstanceAndUnwrap(proxyType.Assembly.FullName, proxyType.FullName);

        public static PluginProxy PluginProxy
        {
            get
            {
                return _proxy;
            }
        }

        public static AppDomain PluginAppDomain
        {
            get
            {
                return pluginAppDomain;
            }
        }

        public SimplePluginManager(Server instance, SimpleCommandMap commandMap)
        {
            server = instance;
            this.commandMap = commandMap;

            defaultPerms.Add(true, new HashSet<Permission>());
            defaultPerms.Add(false, new HashSet<Permission>());
        }

        public void RegisterInterface(Type loader)
        {
            IPluginLoader instance;

            if (typeof(IPluginLoader).IsAssignableFrom(loader))
            {
                instance = (IPluginLoader)Activator.CreateInstance(loader, server);
            }
            else
            {
                throw new Exception(String.Format("Class {0} does not implement interface IPluginLoader", loader.Name));
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public IPlugin GetPlugin(string name)
        {
            return plugins.SingleOrDefault(p => p.GetName().Equals(name));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public IPlugin[] GetPlugins()
        {
            return plugins.ToArray();
        }

        public bool IsPluginEnabled(string name)
        {
            return IsPluginEnabled(GetPlugin(name));
        }

        public bool IsPluginEnabled(IPlugin plugin)
        {
            if ((plugin != null) && (plugins.Contains(plugin)))
            {
                return plugin.IsEnabled();
            }
            else
            {
                return false;
            }
        }

        public IPlugin LoadPlugin(FileInfo file)
        {

            var assm = _proxy.LoadPlugin(file.FullName);
            var types = assm.GetTypes();
            var plugs = types.Where(p => p.IsAssignableFrom(typeof(IPlugin)));

            if (plugs.Count() > 1)
                throw new Exception("You cannot inherit IPlugin twice!");

            Type type = types.FirstOrDefault();

            if (type == null)
                throw new NullReferenceException();

            plugins.Add((IPlugin)Activator.CreateInstance(type));

        }

        public IPlugin[] LoadPlugins(DirectoryInfo directory)
        {

            List<IPlugin> result = new List<IPlugin>();

            if (!(server.GetUpdateFolder().Equals("")))
            {
                updateDirectory = new FileInfo(Path.Combine(directory.FullName, server.GetUpdateFolder()));
            }

            foreach (FileInfo fi in directory.GetFiles())
            {

                var plug = LoadPlugin(fi);

                if (plug == null)
                    continue;

                result.Add(plug);

            }



            return result.ToArray();

        }

        private void CheckUpdate(FileInfo file)
        {
            if (updateDirectory == null || !Directory.Exists(updateDirectory.FullName))
            {
                return;
            }

            FileInfo updateFile = new FileInfo(Path.Combine(updateDirectory.FullName, file.FullName));
            if (File.Exists(updateFile.FullName))
            {

                File.Copy(updateFile.FullName, file.FullName);

                updateFile.Delete();

            }

        }

        public void RegisterEvents(IListener listener, IPlugin plugin)
        {
            if (!plugin.IsEnabled())
            {
                throw new Exception("Plugin attempted to register " + listener + " while not enabled");
            }

            foreach (var entry in plugin.GetPluginLoader().CreateRegisteredListeners(listener, plugin))
            {
                GetEventListeners(GetRegistrationClass(entry.Key)).RegisterAll(entry.Value);
            }
        }

        public void RegisterEvent(Type evt, IListener listener, EventPriority priority, EventExecutor executor, IPlugin plugin)
        {
            RegisterEvent(evt, listener, priority, executor, plugin, false);
        }

        public void RegisterEvent(Type evt, IListener listener, EventPriority priority, EventExecutor executor, IPlugin plugin, bool ignoreCancelled)
        {

            Debug.Assert(listener != null, "Listener cannot be null");
            Debug.Assert(executor != null, "Executor cannot be null");
            Debug.Assert(plugin != null, "Plugin cannot be null");

            if (!plugin.IsEnabled())
            {
            }

            if (useTimings)
            {
                GetEventListeners(evt).Register(new TimedRegisteredListener(listener, executor, priority, plugin, ignoreCancelled));
            }
            else
            {
                GetEventListeners(evt).Register(new RegisteredListener(listener, executor, priority, plugin, ignoreCancelled));
            }

        }

        private HandlerList GetEventListeners(Type type)
        {
            try
            {
                MethodInfo method = GetRegistrationClass(type).GetMethod("GetHandlerList");
                return (HandlerList)method.Invoke(new HandlerList(), null);
            }
            catch (Exception e)
            {
                throw new IllegalPluginAccessException(e.toString());
            }
        }

        public void EnablePlugin(IPlugin plugin)
        {

            if (!plugin.IsEnabled())
            {
                List<Command> pluginCommands = PluginCommandJSONParser.parse(plugin);

                if (!pluginCommands.IsEmpty())
                {
                    commandMap.RegisterAll(plugin.PluginDescription.Name, pluginCommands);
                }

                try
                {
                    plugin.GetPluginLoader().enablePlugin(plugin);
                }
                catch (Exception ex)
                {
                    server.GetLogger().Log(Level.SEVERE, "Error occurred (in the plugin loader) while enabling " + plugin.PluginDescription.FullName + " (Is it up to date?)", ex);
                }

                HandlerList.BakeAll();
            }

        }

        public void CallEvent(Event evt)
        {
            if (evt.IsAsynchronous)
            {
                if (Thread.CurrentThread.Name != null && Thread.CurrentThread.Name.Equals("ServerThread"))
                {
                    throw new Exception(evt.GetEventName() + " cannot be triggered asynchronously from inside synchronized code.");
                }
                if (server.IsPrimaryThread())
                {
                    throw new Exception(evt.GetEventName() + " cannot be triggered asynchronously from primary server thread.");
                }
                FireEvent(evt);
            }
            else
            {
                lock (this)
                {
                    FireEvent(evt);
                }
            }
        }

        private void FireEvent(Event evt)
        {
            HandlerList handlers = evt.GetHandlers();
            RegisteredListener[] listeners = handlers.GetRegisteredListeners();

            foreach (RegisteredListener registration in listeners)
            {
                if (!registration.Plugin.IsEnabled())
                {
                    continue;
                }

                try
                {
                    registration.CallEvent(evt);
                }
                catch (Exception ex)
                {
                    IPlugin plugin = registration.Plugin;

                    if (plugin.IsNaggable())
                    {
                        plugin.SetNaggable(false);

                        server.GetLogger().Log(Level.SEVERE, String.Format(
                                "Nag author(s): '{0}' of '{1}' about the following: {2}",
                                plugin.PluginDescription.Authors,
                                plugin.PluginDescription.FullName,
                                ex.Message
                                ));
                    }

                }
            }
        }

        public void DisablePlugins()
        {
            IPlugin[] plugins = GetPlugins();
            for (int i = plugins.Length - 1; i >= 0; i--)
            {
                DisablePlugin(plugins[i]);
            }
        }

        public void DisablePlugin(IPlugin plugin)
        {
            if (plugin.IsEnabled())
            {
                try
                {
                    plugin.GetPluginLoader().DisablePlugin(plugin);
                }
                catch (Exception ex)
                {
                    server.GetLogger().Log(Level.SEVERE, "Error occurred (in the plugin loader) while disabling " + plugin.PluginDescrption.FullName + " (Is it up to date?)", ex);
                }

                try
                {
                    server.GetScheduler().CancelTasks(plugin);
                }
                catch (Exception ex)
                {
                    server.GetLogger().Log(Level.SEVERE, "Error occurred (in the plugin loader) while cancelling tasks for " + plugin.PluginDescrption.FullName + " (Is it up to date?)", ex);
                }

                try
                {
                    server.getServicesManager().unregisterAll(plugin);
                }
                catch (Exception ex)
                {
                    server.GetLogger().Log(Level.SEVERE, "Error occurred (in the plugin loader) while unregistering services for " + plugin.PluginDescrption.FullName + " (Is it up to date?)", ex);
                }

                try
                {
                    HandlerList.unregisterAll(plugin);
                }
                catch (Exception ex)
                {
                    server.GetLogger().Log(Level.SEVERE, "Error occurred (in the plugin loader) while unregistering events for " + plugin.PluginDescrption.FullName + " (Is it up to date?)", ex);
                }

                try
                {
                    server.GetMessenger().UnregisterIncomingPluginChannel(plugin);
                    server.GetMessenger().UnregisterOutgoingPluginChannel(plugin);
                }
                catch (Exception ex)
                {
                    server.GetLogger().Log(Level.SEVERE, "Error occurred (in the plugin loader) while unregistering plugin channels for " + plugin.PluginDescrption.FullName + " (Is it up to date?)", ex);
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ClearPlugins()
        {
            DisablePlugins();
            plugins.Clear();
            lookupNames.Clear();
            HandlerList.UnregisterAll();
            fileAssociations.Clear();
            permissions.Clear();
            defaultPerms[true].Clear();
            defaultPerms[false].Clear();
        }

        private Type GetRegistrationClass(Type type)
        {
            try
            {
                type.GetMethod("GetHandlerList");
                return type;
            }
            catch (Exception e)
            {
                if (type.BaseType != null
                        && type.BaseType != typeof(Event)
                        && typeof(Event).IsAssignableFrom(type.BaseType))
                {
                    return GetRegistrationClass(type.BaseType);
                }
                else
                {
                    throw new Exception("Unable to find handler list for event " + clazz.getName());
                }
            }
        }

        public Permission GetPermission(string name)
        {
            return permissions[name.ToLower()];
        }

        public void AddPermission(Permission perm)
        {

            string name = perm.Name.ToLower();

            if (permissions.ContainsKey(name))
            {
                throw new Exception("The permission " + name + " is already defined!");
            }

            permissions.Add(name, perm);
            CalculatePermissionDefault(perm);

        }

        public void RemovePermission(Permission perm)
        {
            RemovePermission(perm.Name);
        }

        public void RemovePermission(string name)
        {
            permissions.Remove(name);
        }

        public HashSet<Permission> GetDefaultPermissions(bool op)
        {
            return defaultPerms[op];
        }

        public void RecalculatePermissionDefaults(Permission perm)
        {

            if (permissions.ContainsValue(perm))
            {
                defaultPerms[true].Remove(perm);
                defaultPerms[false].Remove(perm);

                CalculatePermissionDefault(perm);
            }

        }

        private void CalculatePermissionDefault(Permission perm)
        {
            if ((perm.Default == PermissionDefault.Op) || (perm.Default == PermissionDefault.True))
            {
                defaultPerms[true].Add(perm);
                DirtyPermissibles(true);
            }
            if ((perm.Default == PermissionDefault.NotOP) || (perm.Default == PermissionDefault.True))
            {
                defaultPerms[false].Add(perm);
                DirtyPermissibles(false);
            }
        }

        private void DirtyPermissibles(bool op)
        {
            HashSet<IPermissible> permissibles = GetDefaultPermSubscriptions(op);

            foreach (IPermissible p in permissibles)
            {
                p.RecalculatePermissions();
            }
        }

        public void SubscribeToPermission(string permission, IPermissible permissible)
        {

            string name = permission.ToLower();
            Dictionary<WeakReference, WeakReference> map = permSubs[name];

            if (map == null)
            {
                map = new Dictionary<WeakReference, WeakReference>();
                permSubs.Add(name, map);
            }

            map.Add(new WeakReference(permissible), new WeakReference(true));

        }

        public void UnsubscribeFromPermission(string permission, IPermissible permissible)
        {
            string name = permission.ToLower();
            Dictionary<WeakReference, WeakReference> map = permSubs[name];

            if (map != null)
            {
                map.Remove(map.SingleOrDefault(p => (IPermissible)p.Value.Target == permissible).Value);

                if (!map.Any())
                {
                    permSubs.Remove(name);
                }
            }
        }

        public HashSet<IPermissible> GetPermissionSubscriptions(string permission)
        {

            string name = permission.ToLower();
            Dictionary<WeakReference, WeakReference> map = permSubs[name];

            if (map == null)
            {
                return new HashSet<IPermissible>();
            }
            else
            {

                HashSet<IPermissible> perms = new HashSet<IPermissible>();

                foreach (var m in map)
                {
                    perms.Add((IPermissible)m.Value.Target);
                }

                return perms;

            }

        }

        public void SubscribeToDefaultPerms(bool op, IPermissible permissible)
        {
            Dictionary<WeakReference, WeakReference> map = defSubs[op];

            if (map == null)
            {
                defSubs.Add(op, new Dictionary<WeakReference, WeakReference>());
            }

            map.Add(new WeakReference(permissible), new WeakReference(true));
        }

        public void UnsubscribeFromDefaultPerms(bool op, IPermissible permissible)
        {

            Dictionary<WeakReference, WeakReference> map = defSubs[op];

            if (map != null)
            {

                map.Remove(map.SingleOrDefault(p => (IPermissible)p.Value.Target == permissible).Value);

                if (!map.Any())
                {
                    defSubs.Remove(op);
                }
            }

        }

        public HashSet<IPermissible> GetDefaultPermSubscriptions(bool op)
        {

            Dictionary<WeakReference, WeakReference> map = defSubs[op];

            if (map == null)
            {
                return new HashSet<IPermissible>();
            }
            else
            {

                var result = new HashSet<IPermissible>();

                foreach (var entry in map)
                {
                    result.Add((IPermissible)entry.Value.Target);
                }

                return result;

            }

        }

        public HashSet<Permission> GetPermissions()
        {
            return new HashSet<Permission>(permissions.Values);
        }

        public bool UseTimings()
        {
            return useTimings;
        }

        public void UseTimings(bool use)
        {
            useTimings = use;
        }
    }
}
