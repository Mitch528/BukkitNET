using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface ICreeper : IMonster
    {

        bool IsPowered();

        void SetPowered(bool value);

    }
}
