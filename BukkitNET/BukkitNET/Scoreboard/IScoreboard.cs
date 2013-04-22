using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Scoreboard
{
    public interface IScoreboard
    {

        IObjective RegisterNewObjective(string name, string criteria);

        IObjective GetObjective(string name);

        HashSet<IObjective> GetObjectivesByCriteria(string criteria);

        HashSet<IObjective> GetObjectives();

        IObjective GetObjective(DisplaySlot slot);

        HashSet<IScore> GetScores(OfflinePlayer player);

        void ResetScores(OfflinePlayer player);

        ITeam GetPlayerTeam(OfflinePlayer player);

        ITeam GetTeam(string teamName);

        HashSet<ITeam> GetTeams();

        ITeam RegisterNewTeam(string name);

        HashSet<OfflinePlayer> GetPlayers();

        void ClearSlot(DisplaySlot slot);

    }
}
