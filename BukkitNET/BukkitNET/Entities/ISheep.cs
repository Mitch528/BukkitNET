using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Materials;

namespace BukkitNET.Entities
{
    public interface ISheep : IAnimals, IColorable
    {

        bool IsSheared();

        void SetSheared(bool flag);

    }
}
