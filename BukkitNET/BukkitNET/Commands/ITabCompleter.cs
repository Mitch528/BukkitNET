using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Commands
{
    public interface ITabCompleter
    {

        List<string> OnTabComplete(ICommandSender sender, Command command, string alias, string[] args);

    }
}
