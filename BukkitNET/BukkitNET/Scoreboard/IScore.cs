using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Scoreboard
{
    public interface IScore
    {

        OfflinePlayer GetPlayer();

        IObjective GetObjective();

        int GetScore();

        void SetScore(int score);

        IScoreboard GetScoreboard();

    }
}
