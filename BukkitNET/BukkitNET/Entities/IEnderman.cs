using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Materials;

namespace BukkitNET.Entities
{
    public interface IEnderman : IMonster
    {

        MaterialData GetCarriedMaterial();

        void SetCarriedMaterial(MaterialData material);

    }
}
