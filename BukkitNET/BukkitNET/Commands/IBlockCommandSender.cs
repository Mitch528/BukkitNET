using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Commands
{
    public interface IBlockCommandSender : ICommandSender
    {

        IBlock GetBlock();

    }
}
