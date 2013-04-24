using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface ICreature : ILivingEntity
    {

        void SetTarget(ILivingEntity target);

        ILivingEntity GetTarget();

    }
}
