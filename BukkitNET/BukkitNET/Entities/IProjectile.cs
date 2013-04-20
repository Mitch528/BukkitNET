using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IProjectile : IEntity
    {

        ILivingEntity GetShooter();

        void SetShooter(ILivingEntity shooter);

        bool DoesBounce();

        void SetBounce(bool doesBounce);

    }
}
