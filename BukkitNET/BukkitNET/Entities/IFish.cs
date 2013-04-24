using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IFish : IProjectile
    {

        double GetBiteChance();

        void SetBiteChance(double chance);

    }
}
