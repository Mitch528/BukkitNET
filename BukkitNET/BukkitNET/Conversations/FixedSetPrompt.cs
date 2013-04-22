using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Conversations
{
    public abstract class FixedSetPrompt : ValidatingPrompt
    {

        protected List<string> fixedSet;

        protected FixedSetPrompt(params string[] fixedSet)
            : base()
        {
            this.fixedSet = new List<string>(fixedSet);
        }

        private FixedSetPrompt() { }

        protected override bool IsInputValid(ConversationContext context, String input)
        {
            return fixedSet.Contains(input);
        }

        protected string FormatFixedSet()
        {
            return "[" + string.Join(", ", fixedSet) + "]";
        }

    }
}
