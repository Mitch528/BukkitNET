using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public class ManuallyAbandonedConversationCanceller : IConversationCanceller
    {
        public object Clone()
        {
            throw new NotImplementedException();
        }

        public void SetConversation(Conversation conversation)
        {
            throw new NotImplementedException();
        }

        public bool CancelBasedOnInput(ConversationContext context, string input)
        {
            throw new NotImplementedException();
        }
    }
}
