using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Commands;

namespace BukkitNET.Help
{
    public interface IHelpTopicFactory<T> where T : Command
    {

        HelpTopic CreateTopic(T command);

    }
}
