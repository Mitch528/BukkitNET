using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public abstract class NumericPrompt : ValidatingPrompt
    {

        protected NumericPrompt()
            : base()
        {
        }

        protected override bool IsInputValid(ConversationContext context, string input)
        {

            int inTry;

            return int.TryParse(input, out inTry) && IsNumberValid(context, inTry);

        }

        protected bool IsNumberValid(ConversationContext context, int input)
        {
            return true;
        }

        protected override IPrompt AcceptValidatedInput(ConversationContext context, string input)
        {
            try
            {
                return AcceptValidatedInput(context, int.Parse(input));
            }
            catch (Exception e)
            {
                return AcceptValidatedInput(context, 0);
            }
        }

        protected abstract IPrompt AcceptValidatedInput(ConversationContext context, int input);

        protected new string GetFailedValidationText(ConversationContext context, string invalidInput)
        {
            int tryNum;
            if (int.TryParse(invalidInput, out tryNum))
            {
                return GetFailedValidationText(context, tryNum);
            }
            else
            {
                return GetInputNotNumericText(context, invalidInput);
            }
        }

        protected string GetInputNotNumericText(ConversationContext context, string invalidInput)
        {
            return null;
        }

        protected string GetFailedValidationText(ConversationContext context, int invalidInput)
        {
            return null;
        }

    }
}
