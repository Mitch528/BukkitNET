using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Util;

namespace BukkitNET.Entities
{
    public interface IMinecart : IVehicle
    {

        void SetDamage(int damage);

        int GetDamage();

        double GetMaxSpeed();

        void SetMaxSpeed(double speed);

        bool IsSlowWhenEmpty();

        void SetSlowWhenEmpty(bool slow);

        Vector GetFlyingVelocityMod();

        void SetFlyingVelocityMod(Vector flying);

        Vector GetDerailedVelocityMod();

        void SetDerailedVelocityMod(Vector derailed);

    }
}
