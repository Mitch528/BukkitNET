using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Plugin.Messaging
{
    public interface IMessenger
    {

        bool IsReservedChannel(string channel);

        void RegisterOutgoingPluginChannel(IPlugin plugin, string channel);

        void UnregisterOutgoingPluginChannel(IPlugin plugin, string channel);

        void UnregisterOutgoingPluginChannel(IPlugin plugin);

        PluginMessageListenerRegistration RegisterIncomingPluginChannel(IPlugin plugin, string channel, IPluginMessageListener listener);

        void UnregisterIncomingPluginChannel(IPlugin plugin, string channel, IPluginMessageListener listener);

        void UnregisterIncomingPluginChannel(IPlugin plugin, string channel);

        void UnregisterIncomingPluginChannel(IPlugin plugin);

        HashSet<string> GetOutgoingChannels();

        HashSet<String> GetOutgoingChannels(IPlugin plugin);

        HashSet<String> GetIncomingChannels();

        HashSet<String> GetIncomingChannels(IPlugin plugin);

        HashSet<PluginMessageListenerRegistration> GetIncomingChannelRegistrations(IPlugin plugin);

        HashSet<PluginMessageListenerRegistration> GetIncomingChannelRegistrations(string channel);

        HashSet<PluginMessageListenerRegistration> GetIncomingChannelRegistrations(IPlugin plugin, string channel);

        bool IsRegistrationValid(PluginMessageListenerRegistration registration);

        bool IsIncomingChannelRegistered(IPlugin plugin, string channel);

        bool IsOutgoingChannelRegistered(IPlugin plugin, string channel);

        void DispatchIncomingMessage(IPlayer source, string channel, byte[] message);



    }
}
