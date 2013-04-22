using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public class ExactMatchConversationCanceller : IConversationCanceller
    {

        private string escapeSequence;


        public ExactMatchConversationCanceller(string escapeSequence)
        {
            this.escapeSequence = escapeSequence;
        }

        public object Clone()
        {
            return new ExactMatchConversationCanceller(escapeSequence);
        }

        public void SetConversation(Conversation conversation)
        {
        }

        public bool CancelBasedOnInput(ConversationContext context, string input)
        {
            return input.Equals(escapeSequence);
        }

    }
}
