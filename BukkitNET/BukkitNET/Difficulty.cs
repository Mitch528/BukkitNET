using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET
{
    public enum Difficulty
    {

        /// <summary>
        /// Players regain health over time, hostile maps don't spawn, the hunger bar does not deplete.
        /// </summary>
        Peaceful = 0,

        /// <summary>
        /// Hostile mobs spawn, enemies deal less damage than on normal difficulty, the hunger bar does deplete and starving deals up to 5 hearts of damage. (Default value)
        /// </summary>
        Easy = 1,

        /// <summary>
        /// Hostile mobs spawn, enemies deal normal amounts of damage, the hunger bar does deplete and starving deals up to 9.5 hearts of damage.
        /// </summary>
        Normal = 2,

        /// <summary>
        /// Hostile mobs spawn, enemies deal greater damage than on normal difficulty, the hunger bar does deplete and starving can kill players.
        /// </summary>
        Hard = 3

    }

    public static class Difficult
    {
        public static Difficulty setDifficulty(this Difficulty diff)
        {
        }
    }
}
