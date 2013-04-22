using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Block
{
    public interface IDispenser : IBlockState, IContainerBlock
    {

        bool Dispense();

    }
}
