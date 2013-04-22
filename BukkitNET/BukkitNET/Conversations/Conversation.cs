using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Conversations
{
    public class Conversation
    {

        private IPrompt firstPrompt;
        private bool abandoned;
        protected IPrompt currentPrompt;
        protected ConversationContext context;
        protected bool modal;
        protected bool localEchoEnabled;
        protected IConversationPrefix prefix;
        protected List<IConversationCanceller> cancellers;

        public event ConversationAbandonedHandler ConversationAbandoned;

        public bool IsModal
        {
            get
            {
                return modal;
            }
            set
            {
                modal = value;
            }
        }

        public bool IsLocalEchoEnabled
        {
            get
            {
                return localEchoEnabled;
            }
            set
            {
                localEchoEnabled = value;
            }
        }

        public IConversationPrefix Prefix
        {
            get
            {
                return prefix;
            }
            set
            {
                prefix = value;
            }
        }

        public ConversationContext Context
        {
            get
            {
                return context;
            }
        }

        public ConversationState State
        {
            get
            {
                if (currentPrompt != null)
                {
                    return ConversationState.Started;
                }
                else if (abandoned)
                {
                    return ConversationState.Abandoned;
                }
                else
                {
                    return ConversationState.Unstarted;
                }
            }
        }

        public Conversation(IPlugin plugin, IConversable forWhom, IPrompt firstPrompt)
            : this(plugin, forWhom, firstPrompt, new Dictionary<object, object>())
        {
        }

        public Conversation(IPlugin plugin, IConversable forWhom, IPrompt firstPrompt, Dictionary<Object, Object> initialSessionData)
        {
            this.firstPrompt = firstPrompt;
            this.context = new ConversationContext(plugin, forWhom, initialSessionData);
            this.modal = true;
            this.localEchoEnabled = true;
            this.prefix = new NullConversationPrefix();
            this.cancellers = new List<IConversationCanceller>();
        }

        public IConversable GetForWhom()
        {
            return context.ForWhom;
        }

        public void AddConversationCanceller(IConversationCanceller canceller)
        {
            canceller.SetConversation(this);
            this.cancellers.Add(canceller);
        }

        public void Begin()
        {

            if (currentPrompt == null)
            {
                abandoned = false;
                currentPrompt = firstPrompt;
                context.ForWhom.BeginConversation(this);
            }

        }

        public void AcceptInput(string input)
        {

            if (currentPrompt != null)
            {

                if (localEchoEnabled)
                {
                    context.ForWhom.SendRawMessage(prefix.GetPrefix(context) + input);
                }

                foreach (IConversationCanceller canceller in cancellers)
                {
                    if (canceller.CancelBasedOnInput(context, input))
                    {
                        Abandon(new ConversationAbandonedEventArgs(this, canceller));
                        return;
                    }
                }

                currentPrompt = currentPrompt.AcceptInput(context, input);
                OutputNextPrompt();
            }

        }

        public void Abandon()
        {
            Abandon(new ConversationAbandonedEventArgs(this, new ManuallyAbandonedConversationCanceller()));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Abandon(ConversationAbandonedEventArgs details)
        {
            if (!abandoned)
            {
                abandoned = true;
                currentPrompt = null;
                context.ForWhom.AbandonConversation(this);
            }
        }

        public void OutputNextPrompt()
        {
            if (currentPrompt == null)
            {
                Abandon(new ConversationAbandonedEventArgs(this));
            }
            else
            {
                context.ForWhom.SendRawMessage(prefix.GetPrefix(context) + currentPrompt.GetPromptText(context));
                if (!currentPrompt.BlocksForInput(context))
                {
                    currentPrompt = currentPrompt.AcceptInput(context, null);
                    OutputNextPrompt();
                }
            }
        }

        public enum ConversationState
        {
            Unstarted,
            Started,
            Abandoned
        }

    }
}
