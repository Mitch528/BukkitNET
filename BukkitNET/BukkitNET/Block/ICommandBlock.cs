using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Block
{
    public interface ICommandBlock : IBlockState
    {

        string GetCommnand();

        void SetCommand(string command);

        string GetName();

        void SetName(string name);

    }
}
