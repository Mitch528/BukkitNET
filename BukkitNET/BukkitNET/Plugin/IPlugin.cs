using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BukkitNET.Configuration.File;
using BukkitNET.Generator;

namespace BukkitNET.Plugin
{
    public interface IPlugin
    {

        DirectoryInfo GetDataFolder();

        PluginInfo GetPluginInfo();

        FileConfiguration GetConfig();

        FileStream GetResource(string filename);

        IPluginLoader GetPluginLoader();

        ChunkGenerator GetDefaultWorldGenerator(string worldName, string id);

        IServer GetServer();

        void OnEnable();

        void OnDisable();

        void SaveConfig();

        void SaveDefaultConfig();

        void SaveResource(string resourcePath, bool replace);

        void ReloadConfig();

        bool IsEnabled();

        void OnLoad();

        bool IsNaggable();

        void SetNaggable(bool canNag);

        Logger GetLogger();

        string GetName();

    }
}
