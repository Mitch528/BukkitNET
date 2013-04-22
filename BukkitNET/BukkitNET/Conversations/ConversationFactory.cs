using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;
using BukkitNET.Plugin;

namespace BukkitNET.Conversations
{

    public class ConversationFactory
    {

        protected IPlugin plugin;
        protected bool isModal;
        protected bool localEchoEnabled;
        protected IConversationPrefix prefix;
        protected IPrompt firstPrompt;
        protected Dictionary<object, object> initialSessionData;
        protected string playerOnlyMessage;
        protected List<IConversationCanceller> cancellers;

        public ConversationFactory(IPlugin plugin)
        {
            this.plugin = plugin;
            isModal = true;
            localEchoEnabled = true;
            prefix = new NullConversationPrefix();
            firstPrompt = null;
            initialSessionData = new Dictionary<object, object>();
            playerOnlyMessage = null;
            cancellers = new List<IConversationCanceller>();
        }

        public ConversationFactory WithModality(bool modal)
        {
            isModal = modal;
            return this;
        }

        public ConversationFactory WithLocalEcho(bool localEchoEnabled)
        {
            this.localEchoEnabled = localEchoEnabled;
            return this;
        }

        public ConversationFactory WithPrefix(IConversationPrefix prefix)
        {
            this.prefix = prefix;
            return this;
        }

        public ConversationFactory WithTimeout(int timeoutSeconds)
        {
            return WithConversationCanceller(new InactivityConversationCanceller(plugin, timeoutSeconds));
        }

        public ConversationFactory WithFirstPrompt(IPrompt firstPrompt)
        {
            this.firstPrompt = firstPrompt;
            return this;
        }

        public ConversationFactory WithInitialSessionData(Dictionary<object, object> initialSessionData)
        {
            this.initialSessionData = initialSessionData;
            return this;
        }

        public ConversationFactory WithEscapeSequence(string escapeSequence)
        {
            return WithConversationCanceller(new ExactMatchConversationCanceller(escapeSequence));
        }

        public ConversationFactory WithConversationCanceller(IConversationCanceller canceller)
        {
            cancellers.Add(canceller);
            return this;
        }

        public ConversationFactory ThatExcludesNonPlayersWithMessage(string playerOnlyMessage)
        {
            this.playerOnlyMessage = playerOnlyMessage;
            return this;
        }

        public Conversation BuildConversation(IConversable forWhom)
        {
            if (playerOnlyMessage != null && !(forWhom is IPlayer))
            {
                return new Conversation(plugin, forWhom, new NotPlayerMessagePrompt());
            }

            Dictionary<object, object> copiedInitialSessionData = new Dictionary<object, object>();

            foreach (var initData in initialSessionData)
            {
                copiedInitialSessionData.Add(initData.Key, initData.Value);
            }

            Conversation conversation = new Conversation(plugin, forWhom, firstPrompt, copiedInitialSessionData);
            conversation.IsModal = isModal;
            conversation.IsLocalEchoEnabled = localEchoEnabled;
            conversation.Prefix = prefix;

            foreach (IConversationCanceller canceller in cancellers)
            {
                conversation.AddConversationCanceller((IConversationCanceller)canceller.Clone());
            }

            return conversation;
        }

    }

}
