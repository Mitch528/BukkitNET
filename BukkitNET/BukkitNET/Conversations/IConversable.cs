using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public interface IConversable
    {

        bool IsConversing();

        void AcceptConversationInput(string input);

        bool BeginConversation(Conversation conversation);

        void AbandonConversation(Conversation conversation);

        void AbandonConversation(Conversation conversation, ConversationAbandonedEvent details);

        void SendRawMessage(string message);

    }
}
