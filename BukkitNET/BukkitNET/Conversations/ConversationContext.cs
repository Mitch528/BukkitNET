using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Conversations
{
    public class ConversationContext
    {

        private IConversable forWhom;
        private Dictionary<object, object> sessionData;
        private IPlugin plugin;

        public IPlugin Plugin
        {
            get
            {
                return plugin;
            }
        }

        public IConversable ForWhom
        {
            get
            {
                return forWhom;
            }
        }

        public ConversationContext(IPlugin plugin, IConversable forWhom, Dictionary<object, object> initialSessionData)
        {
            this.plugin = plugin;
            this.forWhom = forWhom;
            this.sessionData = initialSessionData;
        }

        public object GetSessionData(object key)
        {
            return sessionData[key];
        }

        public void SetSessionData(object key, object value)
        {
            sessionData.Add(key, value);
        }

    }
}
