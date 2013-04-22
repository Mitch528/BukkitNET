using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public interface IConversationPrefix
    {

        string GetPrefix(ConversationContext context);

    }
}
