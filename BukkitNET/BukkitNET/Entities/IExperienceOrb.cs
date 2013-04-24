using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IExperienceOrb : IEntity
    {

        int GetExperience();

        void SetExperience(int value);

    }
}
