using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Configuration.Serialization;
using BukkitNET.Entities;
using BukkitNET.Permissions;

namespace BukkitNET
{
    public interface OfflinePlayer : IServerOperator, IAnimalTamer, IConfigurationSerializable 
    {

        bool IsOnline();

        string GetName();

        bool IsBanned();

        void SetBanned(bool banned);

        bool IsWhitelisted(bool value);

        IPlayer GetPlayer();

        long GetFirstPlayed();

        long GetLastPlayed();

        bool HasPlayedBefore();

        Location GetBedSpawnLocation();

    }
}
