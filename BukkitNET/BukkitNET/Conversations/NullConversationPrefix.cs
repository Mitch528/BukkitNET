using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public class NullConversationPrefix : IConversationPrefix
    {
        public string GetPrefix(ConversationContext context)
        {
            return "";
        }
    }
}
