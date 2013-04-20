using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;
using BukkitNET.Entities;

namespace BukkitNET
{
    public interface IChunk
    {

        int GetX();

        int GetZ();

        IWorld GetWorld();

        IBlock GetBlock(int x, int y, int z);

        IChunkSnapshot GetChunkSnapshot();

        IChunkSnapshot GetChunkSnapshot(bool includeMaxblocky, bool includeBiome, bool includeBiomeTempRain);

        IEntity[] GetEntities();

        IBlockState[] GetTileEntities();

        bool IsLoaded();

        bool Load(bool generate);

        bool Load();

        bool Unload(bool save, bool safe);

        bool Unload(bool save);

        bool Unload();

    }
}
