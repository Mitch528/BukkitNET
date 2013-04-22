using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{

    public delegate void ConversationAbandonedHandler(object sender, ConversationAbandonedEventArgs e);

    public class ConversationAbandonedEventArgs : EventArgs
    {

        private ConversationContext context;
        private IConversationCanceller canceller;

        public ConversationContext Context
        {
            get
            {
                return context;
            }
        }

        public IConversationCanceller Canceller
        {
            get
            {
                return canceller;
            }
        }

        public bool GracefulExit
        {
            get
            {
                return canceller == null;
            }
        }

        public ConversationAbandonedEventArgs(Conversation conversation)
            : this(conversation, null)
        {
        }

        public ConversationAbandonedEventArgs(Conversation conversation, IConversationCanceller canceller)
        {
            this.context = conversation.Context;
            this.canceller = canceller;
        }



    }


    public class NotPlayerMessagePrompt : MessagePrompt
    {
        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public string GetPromptText(ConversationContext context)
        {
            return playerOnlyMessage;
        }

        protected IPrompt GetNextPrompt(ConversationContext context)
        {
            return Prompt.END_OF_CONVERSATION;
        }
    }

}
