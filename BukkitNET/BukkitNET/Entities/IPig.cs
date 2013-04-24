using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IPig : IAnimals, IVehicle
    {

        bool HasSaddle();

        void SetSaddle(bool saddled);

    }
}
