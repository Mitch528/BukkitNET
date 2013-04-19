using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BukkitNET.Configuration.File;

namespace BukkitNET.Plugin
{
    public interface IPlugin
    {

        DirectoryInfo getDataFolder();

        PluginInfo PluginDescription();

        FileConfiguration getConfig();

        //public InputSt



        void OnEnable();

        void OnDisable();

        void SaveConfig();

        void SaveDefaultConfig();

    }
}
