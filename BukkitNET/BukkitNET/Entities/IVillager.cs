using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{

    public interface IVillager : IAgeable, INPC
    {

        Profression GetProfession();

        void SetProfression(Profression profression);

    }

    public enum Profression
    {

        Farmer = 0,
        Librarian = 1,
        Priest = 2,
        Blacksmith = 3,
        Butcher = 4

    }

}
