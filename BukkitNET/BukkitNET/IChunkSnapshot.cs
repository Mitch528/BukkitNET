using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET
{
    public interface IChunkSnapshot
    {

        int GetX();

        int GetZ();

        string GetWorldName();

        int GetBlockTypeId(int x, int y, int z);

        int GetBlockData(int x, int y, int z);

        int GetBlockSkyLigh(int x, int y, int z);

        int GetBlockEmittedLight(int x, int y, int z);

        int GetHighestBlockYAt(int x, int z);

        Biome GetBiome(int x, int z);

        double GetRawBiomeTemperature(int x, int z);

        double GetRawBiomeRainfall(int x, int z);

        long GetCaptureFullTime();

        bool IsSectionEmpty(int sy);

    }
}
