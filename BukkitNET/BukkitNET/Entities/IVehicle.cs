using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Util;

namespace BukkitNET.Entities
{
    public interface IVehicle : IEntity
    {

        new Vector GetVelocity();

        new void SetVelocity(Vector vel);

    }
}
