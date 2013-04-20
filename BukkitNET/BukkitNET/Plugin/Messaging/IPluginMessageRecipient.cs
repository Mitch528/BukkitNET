using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Plugin.Messaging
{
    public interface IPluginMessageRecipient
    {

        void SendPluginMessage(IPlugin source, string channel, byte[] message);

        HashSet<String> GetListeningPluginChannels();

    }
}
