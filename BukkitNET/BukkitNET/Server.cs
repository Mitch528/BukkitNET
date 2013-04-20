using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BukkitNET.Entities;
using BukkitNET.Events.InventoryEvents;
using BukkitNET.Inventory;
using BukkitNET.Plugin.Messaging;

namespace BukkitNET
{
    public interface Server : IPluginMessageRecipient
    {

        string GetName();

        string GetVersion();

        string GetBukkitVersion();

        IPlayer[] GetOnlinePlayers();

        int GetMaxPlayers();

        int GetPort();

        int GetViewDistance();

        String GetIp();

        string GetServerName();

        string GetServerId();

        string GetWorldType();

        bool GetGenerateStructures();

        bool GetAllowEnd();

        bool GetAllowNether();

        bool HasWhitelist();

        void SetWhitelist(bool value);

        HashSet<OfflinePlayer> GetWhitelistedPlayers();

        void ReloadWhitelist();

        int BroadcastMessage(string message);

        string GetUpdateFolder();

        FileInfo GetUpdateFolderFile();

        long GetConnectionThrottle();

        int GetTicksPerAnimalSpawns();

        int GetTicksPerMonsterSpawns();

        IPlayer GetPlayer(string name);

        IPlayer GetPlayerExact(string name);

        List<IPlayer> MatchPlayer(string name);

        PluginManager GetPluginManager();

        ServicesManager GetServicesManager();

        List<IWorld> GetWorlds();

        IWorld CreateWorld(WorldCreator options);

        bool UnloadWorld(string name, bool save);

        bool UnloadWorld(IWorld world, bool save);

        IWorld GetWorld(string name);

        IWorld GetWorld(Guid uid);

        MapView GetMap(short id);

        MapView CreateMap(IWorld world);

        void Reload();

        Logger GetLogger();

        PluginCommand GetPluginCommand(string name);

        void SavePlayers();

        bool DispatchCommand(CommandSender sender, string commandLine);

        void ConfigureDbConfig(ServerConfig config);

        bool AddRecipe(Recipe recipe);

        List<Recipe> GetRecipesFor(ItemStack result);

        IEnumerable<Recipe> RecipeNumerable();

        void ClearRecipes();

        void ResetRecipes();

        Dictionary<string, string[]> GetCommandAliases();

        int GetSpawnRadius();

        void SetSpawnRadius(int value);

        bool GetOnlineMode();

        bool GetAllowFlight();

        bool IsHardcore();

        bool UseExactLoginLocation();

        void Shutdown();

        int Broadcast(String message, String permission);

        OfflinePlayer GetOfflinePlayer(string name);

        HashSet<string> GetIPBans();

        void BanIP(string address);

        void UnbanIP(string address);

        HashSet<OfflinePlayer> GetBannedPlayers();

        HashSet<OfflinePlayer> GetOperators();

        GameMode GetDefaultGameMode();

        void SetDefaultGameMode(GameMode mode);

        ConsoleCommandSender GetConsoleSender();

        FileInfo GetWorldContainer();

        OfflinePlayer[] GetOfflinePlayers();

        Messenger GetMessenger();

        HelpMap GetHelpMap();

        IInventory CreateInventory(InventoryHolder owner, InventoryType type);

        IInventory CreateInventory(InventoryHolder owner, int size);

        IInventory CreateInventory(InventoryHolder owner, int size, string title);

        int GetMonsterSpawnLimit();

        int GetAnimalSpawnLimit();

        int GetWaterAnimalSpawnLimit();

        int GetAmbientSpawnLimit();

        bool IsPrimaryThread();

        string GetMotd();

        string GetShutdownMessage();

        WarningState GetWarningState();

        ItemFactory GetItemFactory();

        ScoreboardManager GetScoreboardManager();

    }
}
