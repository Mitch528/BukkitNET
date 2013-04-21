using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Plugin.Messaging
{
    public sealed class PluginMessageListenerRegistration
    {

        private IMessenger messenger;
        private IPlugin plugin;
        private string channel;
        private IPluginMessageListener listener;

        public string Channel
        {
            get
            {
                return channel;
            }
        }

        public IPluginMessageListener Listener
        {
            get
            {
                return listener;
            }
        }

        public IPlugin Plugin
        {
            get
            {
                return plugin;
            }
        }

        public bool IsValid
        {
            get
            {
                return messenger.IsRegistrationValid(this);
            }
        }

        public PluginMessageListenerRegistration(IMessenger messenger, IPlugin plugin, String channel, IPluginMessageListener listener)
        {
            if (messenger == null)
            {
                throw new ArgumentException("Messenger cannot be null!");
            }
            if (plugin == null)
            {
                throw new ArgumentException("Plugin cannot be null!");
            }
            if (channel == null)
            {
                throw new ArgumentException("Channel cannot be null!");
            }
            if (listener == null)
            {
                throw new ArgumentException("Listener cannot be null!");
            }

            this.messenger = messenger;
            this.plugin = plugin;
            this.channel = channel;
            this.listener = listener;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }
            PluginMessageListenerRegistration other = (PluginMessageListenerRegistration)obj;
            if (this.messenger != other.messenger && (this.messenger == null || !this.messenger.Equals(other.messenger)))
            {
                return false;
            }
            if (this.plugin != other.plugin && (this.plugin == null || !this.plugin.Equals(other.plugin)))
            {
                return false;
            }
            if ((this.channel == null) ? (other.channel != null) : !this.channel.Equals(other.channel))
            {
                return false;
            }
            if (this.listener != other.listener && (this.listener == null || !this.listener.Equals(other.listener)))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 53 * hash + (this.messenger != null ? this.messenger.GetHashCode() : 0);
            hash = 53 * hash + (this.plugin != null ? this.plugin.GetHashCode() : 0);
            hash = 53 * hash + (this.channel != null ? this.channel.GetHashCode() : 0);
            hash = 53 * hash + (this.listener != null ? this.listener.GetHashCode() : 0);
            return hash;
        }

    }
}
