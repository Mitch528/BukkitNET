using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Util;

namespace BukkitNET.Entities
{
    public interface IFireball : IProjectile, IExplosive
    {

        void SetDirection(Vector direction);

        Vector GetDirection();

    }
}
