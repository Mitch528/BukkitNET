using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BukkitNET.Conversations
{
    public abstract class RegexPrompt : ValidatingPrompt
    {

        private Regex regex;

        protected RegexPrompt(string regex)
            : this(new Regex(regex, RegexOptions.Compiled))
        {
        }

        protected RegexPrompt(Regex regex)
        {
            this.regex = regex;
        }

        private RegexPrompt()
        {
        }

        protected override bool IsInputValid(ConversationContext context, string input)
        {
            return regex.Matches(input).Count > 0;
        }

    }
}
