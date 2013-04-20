using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Generator
{
    public abstract class BlockPopulator
    {

        public abstract void Populate(IWorld world, Random random, IChunk source);

    }
}
