using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IBoat : IVehicle
    {

        double GetMaxSpeed();

        void SetMaxSpeed(double speed);

        double GetOccupiedDeceleration();

        void SetOccupiedDeceleration(double rate);

        double GetUnoccupiedDeceleration();

        void SetUnoccupiedDeceleration(double rate);

        bool GetWorkOnLand();

        void SetWorkOnLand(bool workOnLand);

    }
}
