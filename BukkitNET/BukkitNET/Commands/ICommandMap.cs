using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Commands
{
    public interface ICommandMap
    {

        void RegisterAll(string fallbackPrefix, List<Command> commands);

        bool Register(string label, string fallbackPrefix, Command command);

        bool Register(string fallbackPrefix, Command command);

        bool Dispatch(ICommandSender sender, string cmdLine);

        void ClearCommands();

        Command GetCommand(string name);

        List<String> TabComplete(ICommandSender sender, string cmdLine);

    }
}
