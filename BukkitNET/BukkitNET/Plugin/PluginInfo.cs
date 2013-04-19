using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Plugin
{
    public class PluginInfo
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public Version Version { get; set; }

        public Stage PluginStage { get; set; }

    }
}
