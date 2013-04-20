using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Generator
{
    public abstract class ChunkGenerator
    {

        public interface IBiomeGrid
        {

            Biome GetBiome(int x, int z);
        
            void SetBiome(int x, int z, Biome bio);
        
        }
        public short[][] GenerateExtBlockSections(IWorld world, Random random, int x, int z, IBiomeGrid biomes)
        {
            return null;
        }

        public byte[][] GenerateBlockSections(IWorld world, Random random, int x, int z, IBiomeGrid biomes)
        {
            return null;
        }

        public bool CanSpawn(IWorld world, int x, int z)
        {
            IBlock highest = world.GetBlockAt(x, world.GetHighestBlockYAt(x, z), z);

            switch (world.GetEnvironment())
            {
                case Environment.Nether:
                    return true;
                case Environment.TheEnd:
                    return highest.GetType() != Material.Air && highest.GetType() != Material.Water && highest.GetType() != Material.Lava;
                case Environment.Normal:
                default:
                    return highest.GetType() == Material.Sand || highest.GetType() == Material.Gravel;
            }
        }

        public List<BlockPopulator> GetDefaultPopulators(IWorld world)
        {
            return new List<BlockPopulator>();
        }

        public Location GetFixedSpawnLocation(IWorld world, Random random)
        {
            return null;
        }

    }
}
