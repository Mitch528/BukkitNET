using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Block
{
    public interface ISign : IBlockState
    {

        string[] GetLines();

        string GetLine(int index);

        void SetLine(int index, string line);

    }
}
