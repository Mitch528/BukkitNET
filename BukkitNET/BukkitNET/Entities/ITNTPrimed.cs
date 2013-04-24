using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface ITNTPrimed : IExplosive
    {

        void SetFuseTicks(int fuseTicks);

        int GetFuseTicks();

        IEntity GetSource();

    }
}
