using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Block
{
    public interface ICreatureSpawner : IBlockState
    {

        EntityType GetSpawnedType();

        void SetCreatureTypeByName(string creatureType);

        string GetCreatureTypeName();

        int GetDelay();

        void SetDelay(int delay);

    }
}
