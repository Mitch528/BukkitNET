using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Scoreboard
{
    public interface IScoreboardManager
    {

        IScoreboard GetMainScoreboard();

        IScoreboard GetNewScoreboard();

    }
}
