using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;
using BukkitNET.Plugin;

namespace BukkitNET.Conversations
{
    public abstract class PlayerNamePrompt : ValidatingPrompt
    {

        private IPlugin plugin;

        protected PlayerNamePrompt(IPlugin plugin)
            : base()
        {
            this.plugin = plugin;
        }

        protected override bool IsInputValid(ConversationContext context, string input)
        {
            return plugin.GetServer().GetPlayer(input) != null;
        }

        protected override IPrompt AcceptValidatedInput(ConversationContext context, string input)
        {
            return AcceptValidatedInput(context, plugin.GetServer().GetPlayer(input));
        }

        protected abstract IPrompt AcceptValidatedInput(ConversationContext context, IPlayer input);

    }
}
