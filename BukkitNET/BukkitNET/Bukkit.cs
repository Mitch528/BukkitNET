using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BukkitNET.Commands;
using BukkitNET.Entities;
using BukkitNET.Events.InventoryEvents;
using BukkitNET.Help;
using BukkitNET.Inventory;
using BukkitNET.Maps;
using BukkitNET.Plugin;
using BukkitNET.Plugin.Messaging;
using BukkitNET.Scheduler;
using BukkitNET.Scoreboard;

namespace BukkitNET
{
    public sealed class Bukkit
    {

        public const string BROADCAST_CHANNEL_ADMINISTRATIVE = "bukkit.broadcast.admin";
        public const string BROADCAST_CHANNEL_USERS = "bukkit.broadcast.user";

        private static IServer server;

        public static IServer Server
        {
            get
            {
                return server;
            }
            set
            {
                if (Bukkit.server != null)
                {
                    throw new Exception("Cannot redefine singleton Server");
                }

                Bukkit.server = server;
                server.GetLogger().Info("This server is running " + Bukkit.Name + " version " + Bukkit.Version + " (Implementing API version " + Server.BukkitVersion + ")");
            }
        }

        public static string Name
        {
            get
            {
                return server.GetName();
            }
        }

        public static string Verison
        {
            get
            {
                return server.GetVersion();
            }
        }

        public static string BukkitVersion
        {
            get
            {
                return server.GetBukkitVersion();
            }
        }

        public static IPlayer[] OnlinePlayers
        {
            get
            {
                return server.GetOnlinePlayers();
            }
        }

        public static int MaxPlayers
        {
            get
            {
                return server.GetMaxPlayers();
            }
        }

        public static int Port
        {
            get
            {
                return server.GetPort();
            }
        }

        public static int ViewDistance
        {
            get
            {
                return server.GetViewDistance();
            }
        }

        public static string Ip
        {
            get
            {
                return server.GetIp();
            }
        }

        public static string ServerName
        {
            get
            {
                return server.GetServerName();
            }
        }

        public static string ServerId
        {
            get
            {
                return server.GetServerId();
            }
        }

        public static string WorldType
        {
            get
            {
                return server.GetWorldType();
            }
        }

        public static bool GenerateStructures
        {
            get
            {
                return server.GetGenerateStructures();
            }
        }

        public static bool AllowNether
        {
            get
            {
                return server.GetAllowNether();
            }
        }

        public static bool HasWhitelist
        {
            get
            {
                return server.HasWhitelist();
            }
        }

        public static string UpdateFolder
        {
            get
            {
                return server.GetUpdateFolder();
            }
        }

        public static IPluginManager PluginManager
        {
            get
            {
                return server.GetPluginManager();
            }
        }

        public static IBukkitScheduler Scheduler
        {
            get
            {
                return server.GetScheduler();
            }
        }

        public static IServicesManager ServicesManager
        {
            get
            {
                return server.GetServicesManager();
            }
        }

        public static List<IWorld> Worlds
        {
            get
            {
                return server.GetWorlds();
            }
        }

        public static Logger Logger
        {
            get
            {
                return server.GetLogger();
            }
        }

        public static Dictionary<string, string[]> CommandAliases
        {
            get
            {
                return server.GetCommandAliases();
            }
        }

        public static int SpawnRadius
        {
            get
            {
                return server.GetSpawnRadius();
            }
            set
            {
                server.SetSpawnRadius(value);
            }
        }

        public static bool OnlineMode
        {
            get
            {
                return server.GetOnlineMode();
            }
        }

        public static bool AllowFlight
        {
            get
            {
                return server.GetAllowFlight();
            }
        }

        public static bool IsHardcore
        {
            get
            {
                return server.IsHardcore();
            }
        }

        public static HashSet<string> IPBans
        {
            get
            {
                return server.GetIPBans();
            }
        }

        public static HashSet<OfflinePlayer> BannedPlayers
        {
            get
            {
                return server.GetBannedPlayers();
            }
        }

        public bool Whitelist
        {
            set
            {
                server.SetWhitelist(value);
            }
        }

        public static HashSet<OfflinePlayer> WhitelistedPlayers
        {
            get
            {
                return server.GetWhitelistedPlayers();
            }
        }

        public static IConsoleCommandSender ConsoleSender
        {
            get
            {
                return server.GetConsoleSender();
            }
        }

        public static HashSet<OfflinePlayer> Operators
        {
            get
            {
                return server.GetOperators();
            }
        }

        public static FileInfo WorldContainer
        {
            get
            {
                return server.GetWorldContainer();
            }
        }

        public static IMessenger Messenger
        {
            get
            {
                return server.GetMessenger();
            }
        }

        public static bool AllowEnd
        {
            get
            {
                return server.GetAllowEnd();
            }
        }

        public static FileInfo UpdateFolderFile
        {
            get
            {
                return server.GetUpdateFolderFile();
            }
        }

        public static long ConnectionThrottle
        {
            get
            {
                return server.GetConnectionThrottle();
            }
        }

        public static int TicksPerAnimalSpawns
        {
            get
            {
                return server.GetTicksPerAnimalSpawns();
            }
        }

        public static int TicksPerMonsterSpawns
        {
            get
            {
                return server.GetTicksPerMonsterSpawns();
            }
        }

        public static bool UseExactLoginLocation
        {
            get
            {
                return server.UseExactLoginLocation();
            }
        }

        public static GameMode DefaultGameMode
        {
            get
            {
                return server.GetDefaultGameMode();
            }
        }

        public static OfflinePlayer[] OfflinePlayers
        {
            get
            {
                return server.GetOfflinePlayers();
            }
        }

        public static IHelpMap HelpMap
        {
            get
            {
                return server.GetHelpMap();
            }
        }

        public static int MonsterSpawnLimit
        {
            get
            {
                return server.GetMonsterSpawnLimit();
            }
        }

        public static int AnimalSpawnLimit
        {
            get
            {
                return server.GetAnimalSpawnLimit();
            }
        }

        public static int WaterAnimalSpawnLimit
        {
            get
            {
                return server.GetWaterAnimalSpawnLimit();
            }
        }

        public static int AmbientSpawnLimit
        {
            get
            {
                return server.GetAmbientSpawnLimit();
            }
        }

        public static bool IsPrimaryThread
        {
            get
            {
                return server.IsPrimaryThread();
            }
        }

        public static string Motd
        {
            get
            {
                return server.GetMotd();
            }
        }

        public static string ShutdownMessage
        {
            get
            {
                return server.GetShutdownMessage();
            }
        }

        public static WarningState WarningState
        {
            get
            {
                return server.GetWarningState();
            }
        }

        public static IItemFactory ItemFactory
        {
            get
            {
                return server.GetItemFactory();
            }
        }

        public static IScoreboardManager ScoreboardManager
        {
            get
            {
                return server.GetScoreboardManager();
            }
        }

        private Bukkit() { }

        public static int BroadcastMessage(string message)
        {
            return server.BroadcastMessage(message);
        }

        public static IPlayer GetPlayer(string name)
        {
            return server.GetPlayer(name);
        }

        public static List<IPlayer> MatchPlayer(string name)
        {
            return server.MatchPlayer(name);
        }

        public static IWorld CreateWorld(WorldCreator options)
        {
            return server.CreateWorld(options);
        }

        public static bool UnloadWorld(string name, bool save)
        {
            return server.UnloadWorld(name, save);
        }

        public static bool UnloadWorld(IWorld world, bool save)
        {
            return server.UnloadWorld(world, save);
        }

        public static IWorld GetWorld(string name)
        {
            return server.GetWorld(name);
        }

        public static IWorld GetWorld(Guid uid)
        {
            return server.GetWorld(uid);
        }

        public static IMapView GetMap(short id)
        {
            return server.GetMap(id);
        }

        public static IMapView CreateMap(IWorld world)
        {
            return server.CreateMap(world);
        }

        public static void Reload()
        {
            server.Reload();
        }

        public static PluginCommand GetPluginCommand(string name)
        {
            return server.GetPluginCommand(name);
        }

        public static void SavePlayers()
        {
            server.SavePlayers();
        }

        public static bool DispatchCommand(ICommandSender sender, string commandLine)
        {
            return server.DispatchCommand(sender, commandLine);
        }

        public static void ConfigureDbConfig(ServerConfig config)
        {
            server.ConfigureDbConfig(config);
        }

        public static bool AddRecipe(IRecipe recipe)
        {
            return server.AddRecipe(recipe);
        }

        public static List<IRecipe> GetRecipesFor(ItemStack result)
        {
            return server.GetRecipesFor(result);
        }

        public static IEnumerable<IRecipe> GetRecipeNumerable()
        {
            return server.RecipeNumerable();
        }

        public static void ClearRecipes()
        {
            server.ClearRecipes();
        }

        public static void ResetRecipes()
        {
            server.ResetRecipes();
        }

        public static void Shutdown()
        {
            server.Shutdown();
        }

        public static int Broadcast(string message, string permission)
        {
            return server.Broadcast(message, permission);
        }

        public static OfflinePlayer GetOfflinePlayer(string name)
        {
            return server.GetOfflinePlayer(name);
        }

        public static IPlayer GetPlayerExact(string name)
        {
            return server.GetPlayerExact(name);
        }

        public static void BanIP(string address)
        {
            server.BanIP(address);
        }

        public static void UnbanIP(string address)
        {
            server.UnbanIP(address);
        }

        public static void ReloadWhitelist()
        {
            server.ReloadWhitelist();
        }

        public static IInventory CreateInventory(IInventoryHolder owner, InventoryType type)
        {
            server.CreateInventory(owner, type);
        }

        public static IInventory CreateInventory(IInventoryHolder owner, int size)
        {
            server.CreateInventory(owner, size);
        }

        public static IInventory CreateInventory(IInventoryHolder owner, int size, string title)
        {
            return server.CreateInventory(owner, size, title);
        }



    }
}
