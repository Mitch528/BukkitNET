using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET
{

    public enum GameMode
    {

        Creative = 1,
        Survival = 0,
        Adventure = 2

    }

    public static class GameModeHelper
    {

        public static GameMode GetByName(string name)
        {

            var n = Enum.GetNames(typeof(GameMode)).SingleOrDefault(p => p == name);

            if (n != null)
                return n;

            return default(GameMode);

        }

    }

}
