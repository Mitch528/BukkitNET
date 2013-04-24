using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{

    public interface IOcelot : IAnimals, ITameable
    {

        OcelotType GetCatType();

        void SetCatType(OcelotType type);

        bool IsSitting();

        void SetSitting(bool sitting);

    }

    public enum OcelotType
    {

        WildOcelot = 0,
        BlackCat = 1,
        RedCat = 2,
        SiameseCat = 3

    }

}
