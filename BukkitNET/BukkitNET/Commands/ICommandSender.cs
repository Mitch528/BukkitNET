using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Permissions;

namespace BukkitNET.Commands
{
    public interface ICommandSender : IPermissible
    {

        void SendMessage(string message);
        
        void SendMessage(string[] messages);

        IServer GetServer();

        string GetName();

    }
}
