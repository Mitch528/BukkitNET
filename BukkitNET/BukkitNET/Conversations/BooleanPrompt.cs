using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public abstract class BooleanPrompt : ValidatingPrompt
    {

        protected BooleanPrompt()
            : base()
        {
        }

        protected override bool IsInputValid(ConversationContext context, string input)
        {
            string[] accepted = { "true", "false", "on", "off", "yes", "no" };
            return accepted.Contains(input.ToLower());
        }

        protected IPrompt AcceptValidatedInput(ConversationContext context, string input)
        {
            return AcceptValidatedInput(context, Convert.ToBoolean(input));
        }

        protected abstract IPrompt AcceptValidatedInput(ConversationContext context, bool input);

    }
}
