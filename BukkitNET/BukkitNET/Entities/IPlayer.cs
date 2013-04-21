using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using BukkitNET.Commands;
using BukkitNET.Conversations;
using BukkitNET.Plugin.Messaging;

namespace BukkitNET.Entities
{
    public interface IPlayer : IHumanEntity, IConversable, ICommandSender, OfflinePlayer, IPluginMessageRecipient
    {

        string GetName();

        string GetDisplayName();

        void SetDisplayName(string name);

        string GetPlayerListName();

        void SetPlayerListName(string name);

        void SetCompassTarget(Location loc);

        Location GetCompassTarget();

        IPAddress GetAddress();

        void SendRawMessage(string message);

        void KickPlayer(string message);

        void Chat(string message);

        bool PerformCommand(string command);

        bool IsSneaking();

        void SetSneaking(bool sneak);

        bool IsSprinting();

        void SetSprinting(bool sprinting);

        void SaveData();

        void LoadData();

        void SetSleepingIgnored(bool isSleeping);

        bool IsSleepingIgnored();

        void PlayNote(Location loc, byte instrument, byte note);

        void PlayNote(Location loc, Instrument instrument, Note note);

        void PlaySound(Location location, Sound sound, float volume, float pitch);

        void PlayEffect(Location loc, Effect effect, int data);

        void PlayEffect<T>(Location loc, Effect effect, T data);

        void SendBlockChange(Location loc, Material material, byte data);

        bool SendChunkChange(Location loc, int sx, int sy, int sz, byte[] data);

        void SendBlockChange(Location loc, int material, byte data);

        void SendMap(MapView map);

        void AwardAchievement(Achievement achievement);

        void IncrementStatistic(Statistic statistic);

        void IncrementStatistic(Statistic statistic, int amount);

        void IncrementStatistic(Statistic statistic, Material material);

        void IncrementStatistic(Statistic statistic, Material material, int amount);

        void SetPlayerTime(long time, bool relative);

        long GetPlayerTime();

        long GetPlayerTimeOffset();

        bool IsPlayerTimeRelative();

        void ResetPlayerTime();

        void SetPlayerWeather(WeatherType type);

        WeatherType GetPlayerWeather();

        void ResetPlayerWeather();

        void GiveExp(int amount);

        void GiveExpLevels(int amount);

        float GetExp();

        void SetExp(float exp);

        int GetLevel();

        void SetLevel(int level);

        int GetTotalExperience();

        void SetTotalExperience(int exp);

        float GetExhaustion();

        void SetExhaustion(float value);

        float GetSaturation();

        void SetSaturation(float value);

        int GetFoodLevel();

        void SetFoodLevel(int value);

        void SetBedSpawnLocation(Location location);

        void SetBedSpawnLocation(Location location, bool force);

        bool GetAllowFlight();

        void SetAllowFlight(bool flight);

        void HidePlayer(IPlayer player);

        void ShowPlayer(IPlayer player);

        bool CanSee(IPlayer player);

        bool IsFlying();

        void SetFlying(bool value);

        void SetFlySpeed(float value);

        void SetWalkSpeed(float value);

        float GetFlySpeed();

        float GetWalkSpeed();

        void SetTexturePack(string url);

        Scoreboard GetScoreboard();

        void SetScoreboard(Scoreboard scoreboard);

    }
}
