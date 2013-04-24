using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IPigZombie : IZombie
    {

        int GetAnger();

        void SetAnger(int level);

        void SetAngry(bool angry);

        bool IsAngry();

    }
}
