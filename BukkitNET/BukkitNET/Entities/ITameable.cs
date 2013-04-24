using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface ITameable
    {

        bool IsTamed();

        void SetTamed(bool tame);

        IAnimalTamer GetOwner();

        void SetOwner(IAnimalTamer tamer);

    }
}
