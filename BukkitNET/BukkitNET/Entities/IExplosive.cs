using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IExplosive : IEntity
    {

        void SetYield(float yield);

        float GetYield();

        void SetIsIncendiary(bool isIncendiary);

        bool IsIncendiary();

    }
}
