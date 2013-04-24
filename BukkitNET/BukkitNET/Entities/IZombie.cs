using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IZombie : IMonster
    {

        bool IsBaby();

        void SetBaby(bool flag);

        bool IsVillager();

        void SetVillager(bool flag);

    }
}
