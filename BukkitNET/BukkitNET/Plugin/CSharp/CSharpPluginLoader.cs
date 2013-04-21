using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using BukkitNET.Attributes;
using BukkitNET.Events;

namespace BukkitNET.Plugin.CSharp
{
    public class CSharpPluginLoader : IPluginLoader
    {

        private bool extended;
        private bool warn;

        private Regex _regex = new Regex("\\.dll", RegexOptions.Compiled);

        public CSharpPluginLoader()
        {
            extended = GetType() != typeof(CSharpPluginLoader);
        }

        public IPlugin LoadPlugin(FileInfo file)
        {

            Debug.Assert(file != null, "File cannot be null");

            if (!file.Exists)
            {
                throw new FileNotFoundException(file.FullName + " does not exist");
            }

            FileInfo dataFolder = new FileInfo(Directory.GetParent(file.FullName), description.Name);

            if (dataFolder.Exists && !Directory.Exists(dataFolder.FullName))
            {
                throw new Exception(String.Format(
                    "Projected datafolder: '{0}' for {1} ({2}) exists and is not a directory",
                    dataFolder,
                    description.Name,
                    file
                ));
            }

            var assm = SimplePluginManager.PluginProxy.LoadPlugin(file.FullName);

            var types = assm.GetTypes();
            var plugs = types.Where(p => p.IsAssignableFrom(typeof(IPlugin)));

            int count = plugs.Count();

            if (count > 1)
                throw new Exception("You cannot inherit IPlugin twice!");
            else if (count == 0)
                throw new Exception("Plugin must inherit IPlugin!");

            Type type = types.FirstOrDefault();

            if (type == null)
                throw new NullReferenceException();

            var plugin = (CSharpPlugin)Activator.CreateInstance(type);

            plugin.GetType().GetMethod("Initialize", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(plugin, new object[] { this, null, dataFolder, file, assm });

            return plugin;

        }

        public PluginInfo GetPluginDescription(FileInfo file)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Type, HashSet<RegisteredListener>> CreateRegisteredListener(IListener listener, IPlugin plugin)
        {

            Debug.Assert(plugin != null, "Plugin can not be null");
            Debug.Assert(listener != null, "Listener can not be null");

            var ret = new Dictionary<Type, HashSet<RegisteredListener>>();

            bool useTimings = Bukkit.Server.GetPluginManager().UseTimings();

            MethodInfo[] infos = listener.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (MethodInfo info in infos)
            {

                var attribs = info.GetCustomAttributes(false);

                var eventHandlers = attribs.OfType<EventHandlerAttribute>().ToList();

                int count = eventHandlers.Count;

                if (count > 1 || count == 0)
                    continue;

                var handler = eventHandlers.SingleOrDefault();

                if (handler == null)
                    continue;

                var paramsInfos = info.GetParameters().ToList();

                if (paramsInfos.Count != 1)
                {
                    plugin.GetLogger().Severe(plugin.Description.FullName + " attempted to register an invalid EventHandler method signature \"" + info.Name + "\" in " + listener.GetType().Name);
                    continue;
                }

                if (paramsInfos[0].GetType() != typeof(Event))
                {
                    plugin.GetLogger().Severe(plugin.Description.FullName + " attempted to register an invalid EventHandler method signature \"" + info.Name + "\" in " + listener.GetType().Name);
                    continue;
                }

                Type type = paramsInfos[0].GetType();

                HashSet<RegisteredListener> eventSet = ret[type];

                if (eventSet == null)
                {

                    eventSet = new HashSet<RegisteredListener>();

                    ret.Add(type, eventSet);

                }

                if (type.GetCustomAttributes(typeof(ObsoleteAttribute), false).ToList().Any())
                {

                    plugin.GetLogger().Log(
                            Level.WARNING,
                            String.Format(
                                    "\"{0}\" has registered a listener for {1} on method \"{2}\", but the event is Deprecated." +
                                    " please notify the authors: {3}",
                                    plugin.Description.getFullName(),
                                    type.Name,
                                    info.Name,
                                    plugin.PluginDescription.Authors));

                }

                EventExecutor ee = new PluginEventExecutor(type, info);

                if (useTimings)
                {
                    eventSet.Add(new TimedRegisteredListener(listener, ee, handler.Priority, plugin, handler.IgnoreCancelled));
                }
                else
                {
                    eventSet.Add(new RegisteredListener(listener, ee, handler.Priority, plugin, handler.IgnoreCancelled));
                }

            }

            return ret;

        }

        public void EnablePlugin(IPlugin plugin)
        {

            Debug.Assert(plugin is CSharpPlugin, "Plugin is not associated with this PluginLoader");

            if (!plugin.IsEnabled())
            {
                plugin.GetLogger().Info("Enabling " + plugin.PluginDescription.FullName());

                CSharpPlugin cPlugin = (CSharpPlugin)plugin;

                string pluginName = jPlugin.PluginDescription.Name();

                if (!loaders0.containsKey(pluginName))
                {
                    loaders0.put(pluginName, (PluginClassLoader)cPlugin.getClassLoader());
                }

                try
                {
                    cPlugin.SetEnabled(true);
                }
                catch (Exception ex)
                {
                    Bukkit.Server.GetLogger().Log(Level.SEVERE, "Error occurred while enabling " + plugin.PluginDescription.FullName + " (Is it up to date?)", ex);
                }

                Bukkit.Server.GetPluginManager().CallEvent(new PluginEnableEvent(plugin));
            }

        }

        public void DisablePlugin(IPlugin plugin)
        {
            
            Debug.Assert(plugin is CSharpPlugin, "Plugin is not associated with this PluginLoader");

            if (plugin.IsEnabled())
            {
                String message = String.Format("Disabling {0}", plugin.PluginDescription.FullName);
                plugin.GetLogger().Info(message);

                Bukkit.Server.GetPluginManager().CallEvent(new PluginDisableEvent(plugin));

                var cPlugin = (CSharpPlugin)plugin;

                try
                {
                    cPlugin.SetEnabled(false);
                }
                catch (Exception ex)
                {
                    Bukkit.GetLogger().Log(Level.SEVERE, "Error occurred while disabling " + plugin.PluginDescription.FullName + " (Is it up to date?)", ex);
                }

                loaders0.remove(jPlugin.getDescription().getName());

                if (cloader is PluginClassLoader)
                {
                    PluginClassLoader loader = (PluginClassLoader)cloader;
                    HashSet<String> names = loader.extended ? loader.getClasses() : loader.getClasses0();

                    foreach (String name in names)
                    {
                        if (extended)
                        {
                            RemoveClass(name);
                        }
                        else
                        {
                            RemoveClass0(name);
                        }
                    }
                }
            }
        }
    }
}
