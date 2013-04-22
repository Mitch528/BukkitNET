using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Commands;
using BukkitNET.Extensions;
using BukkitNET.Generator;
using BukkitNET.Plugin;

namespace BukkitNET
{
    public class WorldCreator
    {

        private string name;
        private long seed;
        private Environment environment = Environment.Normal;
        private ChunkGenerator generator = null;
        private WorldType type = WorldType.Normal;
        private bool generateStructures = true;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public long Seed
        {
            get
            {
                return seed;
            }
            set
            {
                seed = value;
            }
        }

        public WorldType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public bool WillGenerateStructures
        {
            get
            {
                return generateStructures;
            }
            set
            {
                generateStructures = value;
            }
        }

        public Environment Environment
        {
            get
            {
                return environment;
            }
            set
            {
                environment = value;
            }
        }

        public WorldCreator(string name)
        {
            if (name == null)
            {
                throw new ArgumentException("World name cannot be null");
            }

            this.name = name;
            this.seed = (new Random()).NextInt64();
        }

        public WorldCreator Copy(IWorld world)
        {
            if (world == null)
            {
                throw new ArgumentException("World cannot be null");
            }

            seed = world.GetSeed();
            environment = world.GetEnvironment();
            generator = world.GetGenerator();

            return this;
        }

        public WorldCreator Copy(WorldCreator creator)
        {
            if (creator == null)
            {
                throw new ArgumentException("Creator cannot be null");
            }

            seed = creator.seed();
            environment = creator.environment();
            generator = creator.generator();

            return this;
        }

        public ChunkGenerator GetGenerator()
        {
            return generator;
        }

        public WorldCreator SetGenerator(ChunkGenerator generator)
        {
            this.generator = generator;
            return this;
        }

        public WorldCreator SetGenerator(string generator)
        {
            this.generator = GetGeneratorForName(name, generator, Bukkit.ConsoleSender);

            return this;
        }

        public WorldCreator SetGenerator(string generator, ICommandSender output)
        {
            this.generator = GetGeneratorForName(name, generator, output);

            return this;
        }

        public IWorld CreateWorld()
        {
            return Bukkit.CreateWorld(this);
        }

        public static WorldCreator CreateFromName(string name)
        {
            return new WorldCreator(name);
        }

        public static ChunkGenerator GetGeneratorForName(string world, string name, ICommandSender output)
        {
            ChunkGenerator result = null;

            if (world == null)
            {
                throw new ArgumentException("World name must be specified");
            }

            if (output == null)
            {
                output = Bukkit.ConsoleSender;
            }

            if (name != null)
            {
                string[] split = name.Split(':');
                string id = (split.Length > 1) ? split[1] : null;
                IPlugin plugin = Bukkit.PluginManager.GetPlugin(split[0]);

                if (plugin == null)
                {
                    output.SendMessage("Could not set generator for world '" + world + "': Plugin '" + split[0] + "' does not exist");
                }
                else if (!plugin.IsEnabled())
                {
                    output.SendMessage("Could not set generator for world '" + world + "': Plugin '" + plugin.GetPluginInfo().FullName + "' is not enabled");
                }
                else
                {
                    result = plugin.GetDefaultWorldGenerator(world, id);
                }
            }

            return result;
        }

    }
}
