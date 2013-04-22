using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Commands
{
    public interface ICommandExecutor
    {

        bool OnCommand(ICommandSender sender, Command command, string label, string[] args);

    }
}
