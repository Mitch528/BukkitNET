using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Commands
{
    public interface IPluginIdentifiableCommand
    {

        IPlugin GetPlugin();

    }
}
