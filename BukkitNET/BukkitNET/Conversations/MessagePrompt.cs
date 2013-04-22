using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public abstract class MessagePrompt : IPrompt
    {

        public MessagePrompt()
            : base()
        {
        }

        public abstract object Clone();

        public abstract string GetPromptText(ConversationContext context);

        public bool BlocksForInput(ConversationContext context)
        {
            return false;
        }

        public IPrompt AcceptInput(ConversationContext context, string input)
        {
            return GetNextPrompt(context);
        }

        protected abstract IPrompt GetNextPrompt(ConversationContext context);

    }
}
