using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public interface IConversationCanceller : ICloneable
    {

        void SetConversation(Conversation conversation);

        bool CancelBasedOnInput(ConversationContext context,string input);

    }
}
