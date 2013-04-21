using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BukkitNET.Plugin
{
    public interface IPluginLoader
    {

        IPlugin LoadPlugin(FileInfo file);

        PluginInfo GetPluginDescription(FileInfo file);

        Dictionary<Type, HashSet<RegisteredListener>> CreateRegisteredListener(IListener listener, IPlugin plugin);

        void EnablePlugin(IPlugin plugin);

        void DisablePlugin(IPlugin plugin);

    }
}
