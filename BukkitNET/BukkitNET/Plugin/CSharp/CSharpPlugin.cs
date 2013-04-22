using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using BukkitNET.Commands;
using BukkitNET.Configuration.File;
using BukkitNET.Generator;

namespace BukkitNET.Plugin.CSharp
{
    public abstract class CSharpPlugin : PluginBase
    {

        private bool isEnabled = false;
        private bool initialized = false;
        private IPluginLoader loader = null;
        private IServer server = null;
        private FileInfo file = null;
        private PluginInfo pinfo = null;
        private FileInfo dataFolder = null;
        private bool naggable = true;
        private FileConfiguration newConfig = null;
        private FileInfo configFile = null;
        private PluginLogger logger = null;

        private Assembly assembly;

        public FileInfo DataFolder
        {
            get
            {
                return dataFolder;
            }
        }

        public IPluginLoader PluginLoader
        {
            get
            {
                return loader;
            }
        }

        public IServer Server
        {
            get
            {
                return server;
            }
        }

        protected FileInfo File
        {
            get
            {
                return file;
            }
        }

        public FileConfiguration Config
        {
            get
            {

                if (newConfig == null)
                {
                    ReloadConfig();
                }

                return newConfig;

            }
        }

        public bool IsInitialized
        {
            get
            {
                return initialized;
            }
        }

        public override void ReloadConfig()
        {

            newConfig = JsonConfiguration.LoadConfiguration(configFile);

            FileStream fs = GetResource("config.json");

            if (fs != null)
            {

                JsonConfiguration jc = JsonConfiguration.LoadConfiguration(fs);

                newConfig.SetDefaults(jc);


            }

        }

        public override void SaveConfig()
        {
            GetConfig().Save(configFile);
        }

        public override void SaveDefaultConfig()
        {
            GetConfig().Save("config.json");
        }

        public override void SaveResource(string resourcePath, bool replace)
        {

            if (string.IsNullOrEmpty(resourcePath))
            {
                throw new ArgumentException("ResourcePath cannot be null or empty");
            }

            FileStream fs = GetResource(resourcePath);

            if (fs == null)
            {
                throw new ArgumentException("The embedded resource '" + resourcePath + "' cannot be found in " + file);
            }

            FileInfo outFile = new FileInfo(Path.Combine(dataFolder.FullName, resourcePath));

            int lastIndex = resourcePath.LastIndexOf('/');
            DirectoryInfo outDir = new DirectoryInfo(Path.Combine(dataFolder.FullName, resourcePath.Substring(0, lastIndex >= 0 ? lastIndex : 0)));

            if (!outDir.Exists)
            {
                outDir.Create();
            }

            if (!outFile.Exists || replace)
            {

                using (StreamReader reader = new StreamReader(fs))
                {
                    using (StreamWriter writer = new StreamWriter(outFile.FullName))
                    {
                        writer.Write(reader.ReadToEnd());
                    }

                }

            }


        }

        public override FileStream GetResource(string filename)
        {
            return new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
        }

        public void SetEnabled(bool enabled)
        {
            if (isEnabled != enabled)
            {

                isEnabled = enabled;

                if (isEnabled)
                {
                    OnEnable();
                }
                else
                {
                    OnDisable();
                }

            }
        }

        protected void Initialize(IPluginLoader loader, FileInfo dataFolder, FileInfo file, Assembly assm)
        {

            if (!initialized)
            {

                this.initialized = true;
                this.loader = loader;
                this.server = server;
                this.file = file;
                this.dataFolder = dataFolder;
                this.assembly = assm;
                this.configFile = new FileInfo(Path.Combine(dataFolder.FullName, "config.yml"));
                this.logger = new PluginLogger(this);
                ServerConfig db = new ServerConfig();

                if (!dataFolder.Exists)
                    dataFolder.Create();

            }

        }

        public bool OnCommand(ICommandSender sender, Command command, string label, string[] args)
        {
            return false;
        }

        public List<String> OnTabComplete(ICommandSender sender, Command command, string alias, string[] args)
        {
            return null;
        }

        public PluginCommand GetCommand(string name)
        {
            string alias = name.ToLower();
            PluginCommand command = server.GetPluginCommand(alias);

            if ((command != null) && (command.GetPlugin() != this))
            {
                command = server.GetPluginCommand(description.Name.ToLower() + ":" + alias);
            }

            if ((command != null) && (command.GetPlugin() == this))
            {
                return command;
            }
            else
            {
                return null;
            }
        }

        public override ChunkGenerator GetDefaultWorldGenerator(string worldName, string id)
        {
            server.GetLogger().Severe("Plugin " + description.FullName + " does not contain any generators that may be used in the default world!");
            return null;
        }

        public override bool IsNaggable()
        {
            return naggable;
        }

        public override void SetNaggable(bool canNag)
        {
            naggable = canNag;
        }

        public override Logger GetLogger()
        {
            return logger;
        }

        public override string ToString()
        {
            return pinfo.FullName;
        }

    }
}
