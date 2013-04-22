using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Scoreboard
{
    public interface ITeam
    {

        string GetName();

        string GetDisplayName();

        void SetDisplayName(string displayName);

        string GetPrefix();

        void SetPrefix(string prefix);

        string GetSuffix();

        bool AllowFriendlyFire();

        void SetAllowFriendlyFire(bool enabled);

        bool CanSeeFriendlyInvisibles();

        HashSet<OfflinePlayer> GetPlayers();

        int GetSize();

        IScoreboard GetScoreboard();

        void AddPlayer(OfflinePlayer player);

        void RemovePlayer(OfflinePlayer player);

        void Unregister();

        bool HasPlayer(OfflinePlayer player);

    }
}
