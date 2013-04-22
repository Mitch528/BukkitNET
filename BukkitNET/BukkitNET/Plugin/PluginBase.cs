using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BukkitNET.Configuration.File;
using BukkitNET.Generator;

namespace BukkitNET.Plugin
{
    public abstract class PluginBase : MarshalByRefObject, IPlugin
    {

        public abstract DirectoryInfo GetDataFolder();
        public abstract PluginInfo GetPluginInfo();
        public abstract FileConfiguration GetConfig();
        public abstract FileStream GetResource(string filename);
        public abstract IPluginLoader GetPluginLoader();
        public abstract ChunkGenerator GetDefaultWorldGenerator(string worldName, string id);
        public abstract IServer GetServer();
        public abstract void OnEnable();
        public abstract void OnDisable();
        public abstract void SaveConfig();
        public abstract void SaveDefaultConfig();
        public abstract void SaveResource(string resourcePath, bool replace);
        public abstract void ReloadConfig();
        public abstract bool IsEnabled();
        public abstract void OnLoad();
        public abstract bool IsNaggable();
        public abstract void SetNaggable(bool canNag);
        public abstract Logger GetLogger();

        public override int GetHashCode()
        {
            return GetName().GetHashCode();
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (!(obj is IPlugin))
            {
                return false;
            }
            return GetName().Equals(((IPlugin)obj).GetName());
        }

        public string GetName()
        {
            return GetPluginInfo().Name;
        }
    }
}
