using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Block;
using BukkitNET.Entities;
using BukkitNET.Extensions;
using BukkitNET.Generator;
using BukkitNET.Inventory;
using BukkitNET.Metadata;
using BukkitNET.Plugin.Messaging;
using BukkitNET.Util;

namespace BukkitNET
{
    public interface IWorld : IPluginMessageRecipient, IMetadatable
    {

        IBlock GetBlockAt(int x, int y, int z);

        IBlock GetBlockAt(Location location);

        int GetBlockTypeIdAt(int x, int y, int z);

        int GetBlockTypeIdAt(Location location);

        int GetHighestBlockYAt(int x, int z);

        int GetHighestBlockYAt(Location location);

        IBlock GetHighestBlockAt(int x, int z);

        IBlock GetHighestBlockAt(Location location);

        IChunk GetChunkAt(int x, int z);

        IChunk GetChunkAt(Location location);

        IChunk GetChunkAt(IBlock block);

        bool IsChunkLoaded(IChunk chunk);

        IChunk[] GetLoadedChunks();

        void LoadChunk(IChunk chunk);

        bool IsChunkLoaded(int x, int z);

        bool IsChunkInUse(int x, int z);

        void LoadChunk(int x, int z);

        bool LoadChunk(int x, int z, bool generate);

        bool UnloadChunk(IChunk chunk);

        bool UnloadChunk(int x, int z);

        bool UnloadChunk(int x, int z, bool save);

        bool UnloadChunk(int x, int z, bool save, bool safe);

        bool UnloadChunkRequest(int x, int z);

        bool UnloadChunkRequest(int x, int z, bool safe);

        bool RegenerateChunk(int x, int z);

        bool RefreshChunk(int x, int z);

        IItem DropItem(Location location, ItemStack item);

        IItem DropItemNaturally(Location location, ItemStack item);

        IArrow SpawnArrow(Location location, Vector velocity, float speed, float spread);

        bool GenerateTree(Location location, TreeType type);

        bool GenerateTree(Location loc, TreeType type, IBlockChangeDelegate deleg);

        IEntity SpawnEntity(Location loc, EntityType type);

        ILightningStrike StrikeLightning(Location loc);

        ILightningStrike StrikeLightningEffect(Location loc);

        List<IEntity> GetEntities();

        List<ILivingEntity> GetLivingEntities();

        Collection<T> GetEntitiesByClass<T>(Type cls);

        Collection<IEntity> GetEntitiesByClasses(params Type[] classes);

        List<IPlayer> GetPlayers();

        string GetName();

        Guid GetUID();

        Location GetSpawnLocation();

        bool SetSpawnLocation(int x, int y, int z);

        long GetTime();

        void SetTime(long time);

        long GetFullTime();

        void SetFullTime(long time);

        bool HasStorm();

        void SetStorm(bool hasStorm);

        int GetWeatherDuration();

        void SetWeatherDuration(int duration);

        bool IsThundering();

        void SetThundering(bool thundering);

        int GetThunderDuration();

        void SetThunderDuration(int duration);

        bool CreateExplosion(double x, double y, double z, float power);

        bool CreateExplosion(double x, double y, double z, float power, bool setFire);

        bool CreateExplosion(double x, double y, double z, float power, bool setFire, bool breakBlocks);

        bool CreateExplosion(Location loc, float power);

        bool CreateExplosion(Location loc, float power, bool setFire);

        BukkitNET.Environment GetEnvironment();

        long GetSeed();

        bool GetPVP();

        void SetPVP(bool pvp);

        ChunkGenerator GetGenerator();

        void Save();

        List<BlockPopulator> GetPopulators();

        T Spawn<T>(Location location, Type type);

        IFallingBlock SpawnFallingBlock(Location location, Material material, byte data);

        IFallingBlock SpawnFallingBlock(Location location, int blockId, byte blockData);

        void PlayEffect(Location location, Effect effect, int data);

        void PlayEffect(Location location, Effect effect, int data, int radius);

        void PlayEffect<T>(Location location, Effect effect, T data);

        void PlayEffect<T>(Location location, Effect effect, T data, int radius);

        IChunkSnapshot GetEmptyChunkSnapshot(int x, int z, bool includeBiome, bool includeBiomeTempRain);

        void SetSpawnFlags(bool allowMonsters, bool allowAnimals);

        bool GetAllowAnimals();

        bool GetAllowMonsters();

        Biome GetBiome(int x, int z);

        void SetBiome(int x, int z, Biome bio);

        double GetTemperature(int x, int z);

        double GetHumidity(int x, int z);

        int GetMaxHeight();

        int GetSeaLevel();

        bool GetKeepSpawnInMemory();

        void SetKeepSpawnInMemory(bool keepLoaded);

        bool IsAutoSave();

        void SetAutoSave(bool value);

        void SetDifficulty(Difficulty difficulty);

        Difficulty GetDifficulty();

        DirectoryInfo GetWorldFolder();

        WorldType GetWorldType();

        bool CanGenerateStructures();

        long GetTicksPerAnimalSpawns();

        void SetTicksPerAnimalSpawns(int ticksPerAnimalSpawns);

        long GetTicksPerMonsterSpawns();

        void SetTicksPerMonsterSpawns(int ticksPerMonsterSpawns);

        int GetMonsterSpawnLimit();

        void SetMonsterSpawnLimit(int limit);

        int GetAnimalSpawnLimit();

        void SetAnimalSpawnLimit(int limit);

        int GetWaterAnimalSpawnLimit();

        void SetWaterAnimalSpawnLimit(int limit);

        int GetAmbientSpawnLimit();

        void SetAmbientSpawnLimit(int limit);

        void PlaySound(Location location, Sound sound, float volume, float pitch);

        string[] GetGameRules();

        string GetGameRuleValue(string rule);

        bool SetGameRuleValue(string rule, string value);

        bool IsGameRule(string rule);

    }

    public enum Environment
    {

        [EnvironmentInfo(0)]
        Normal,

        [EnvironmentInfo(-1)]
        Nether,

        [EnvironmentInfo(1)]
        TheEnd

    }

    public static class EnvironmentHelper
    {

        public static Environment GetEnvironment(int id)
        {

            var vals = Enum.GetValues(typeof(Environment));

            foreach (Environment env in vals)
            {

                var attrib = env.GetAttribute<EnvironmentInfoAttribute>();

                if (attrib.Id == id)
                {
                    return env;
                }

            }

        }

    }

}
