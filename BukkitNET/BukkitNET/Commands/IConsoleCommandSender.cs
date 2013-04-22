using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Conversations;

namespace BukkitNET.Commands
{
    public interface IConsoleCommandSender : ICommandSender, IConversable
    {
    }
}
