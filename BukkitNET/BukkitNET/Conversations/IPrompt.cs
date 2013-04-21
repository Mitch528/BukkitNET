using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public interface IPrompt : ICloneable
    {

        string GetPromptText(ConversationContext context);

        bool BlocksForInput(ConversationContext context);

        IPrompt AcceptInput(ConversationContext context, string input);

    }
}
