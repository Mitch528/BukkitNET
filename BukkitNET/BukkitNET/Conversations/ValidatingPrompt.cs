using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public abstract class ValidatingPrompt : IPrompt
    {

        protected ValidatingPrompt()
            : base()
        {
        }

        protected abstract bool IsInputValid(ConversationContext context, string input);
        protected abstract IPrompt AcceptValidatedInput(ConversationContext context, string input);

        public abstract string GetPromptText(ConversationContext context);

        public bool BlocksForInput(ConversationContext context)
        {
            return true;
        }

        public IPrompt AcceptInput(ConversationContext context, string input)
        {

            if (IsInputValid(context, input))
            {
                return AcceptValidatedInput(context, input);
            }
            else
            {
                String failPrompt = GetFailedValidationText(context, input);
                if (failPrompt != null)
                {
                    context.ForWhom.SendRawMessage(ChatColor.Red + failPrompt);
                }
                return this;
            }

        }

        protected string GetFailedValidationText(ConversationContext context, string invalidInput)
        {
            return null;
        }


        public abstract object Clone();
    }
}
