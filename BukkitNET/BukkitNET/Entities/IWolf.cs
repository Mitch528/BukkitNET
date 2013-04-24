using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IWolf : IAnimals, ITameable
    {

        bool IsAngry();

        void SetAngry(bool angry);

        bool IsSitting();

        void SetSitting(bool sitting);

        DyeColor GetCollarColor();

        void SetCollarColor(DyeColor color);

    }
}
