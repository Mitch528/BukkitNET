using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public abstract class StringPrompt : IPrompt
    {
        public abstract string GetPromptText(ConversationContext context);

        public bool BlocksForInput(ConversationContext context)
        {
            return true;
        }

        public abstract IPrompt AcceptInput(ConversationContext context, string input);

        public abstract object Clone();
    }
}
