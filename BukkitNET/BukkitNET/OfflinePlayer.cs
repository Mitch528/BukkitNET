using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Configuration.Serialization;

namespace BukkitNET
{
    public interface OfflinePlayer : ServerOperator, AnimalTamer, ConfigurationSerializable 
    {

        bool IsOnline();

        string GetName();

        bool IsBanned();

        void SetBanned(bool banned);

        bool IsWhitelisted(bool value);

        Player GetPlayer();

        long GetFirstPlayed();

        long GetLastPlayed();

        bool HasPlayedBefore();

        Location GetBedSpawnLocation();

    }
}
