using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Scoreboard
{
    public interface IObjective
    {

        string GetName();

        string GetDisplayName();

        void SetDisplayName(string displayName);

        string GetCriteria();

        bool IsModifiable();

        IScoreboard GetScoreboard();

        void Unregister();

        void SetDisplaySlot(DisplaySlot slot);

        DisplaySlot GetDisplaySlot();

        IScore GetScore(OfflinePlayer player);

    }
}
