using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Plugin.Messaging
{
    public interface IPluginMessageListener
    {

        void OnPluginMessageReceived(String channel, IPlayer player, byte[] message);

    }
}
