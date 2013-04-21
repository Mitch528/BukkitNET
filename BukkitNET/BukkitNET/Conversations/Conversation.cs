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

        private Prompt firstPrompt;
        private bool abandoned;
        protected Prompt currentPrompt;
        protected ConversationContext context;
        protected bool modal;
        protected bool localEchoEnabled;
        protected ConversationPrefix prefix;
        protected List<ConversationCanceller> cancellers;
        protected List<ConversationAbandonedListener> abandonedListeners;

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

        public ConversationPrefix Prefix
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

        public Conversation(IPlugin plugin, IConversable forWhom, Prompt firstPrompt)
            : this(plugin, forWhom, firstPrompt, new Dictionary<object, object>())
        {
        }

        public Conversation(IPlugin plugin, IConversable forWhom, Prompt firstPrompt, Dictionary<Object, Object> initialSessionData)
        {
            this.firstPrompt = firstPrompt;
            this.context = new ConversationContext(plugin, forWhom, initialSessionData);
            this.modal = true;
            this.localEchoEnabled = true;
            this.prefix = new NullConversationPrefix();
            this.cancellers = new List<ConversationCanceller>();
            this.abandonedListeners = new ArrayList<ConversationAbandonedListener>();
        }

        public IConversable GetForWhom()
        {
            return context.GetForWhom();
        }

        public void AddConversationCanceller(ConversationCanceller canceller)
        {
            canceller.setConversation(this);
            this.cancellers.Add(canceller);
        }

        public void Begin()
        {

            if (currentPrompt == null)
            {
                abandoned = false;
                currentPrompt = firstPrompt;
                context.GetForWhom().beginConversation(this);
            }

        }

        public void AcceptInput(string input)
        {

            if (currentPrompt != null)
            {

                if (localEchoEnabled)
                {
                    context.GetForWhom().SendRawMessage(prefix.GetPrefix(context) + input);
                }

                foreach (ConversationCanceller canceller in cancellers)
                {
                    if (canceller.cancelBasedOnInput(context, input))
                    {
                        Abandon(new ConversationAbandonedEvent(this, canceller));
                        return;
                    }
                }

                currentPrompt = currentPrompt.AcceptInput(context, input);
                OutputNextPrompt();
            }

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddConversationAbandonedListener(ConversationAbandonedListener listener)
        {
            abandonedListeners.Add(listener);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void RemoveConversationAbandonedListener(ConversationAbandonedListener listener)
        {
            abandonedListeners.Remove(listener);
        }

        public void Abandon()
        {
            Abandon(new ConversationAbandonedEvent(this, new ManuallyAbandonedConversationCanceller()));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Abandon(ConversationAbandonedEvent details)
        {
            if (!abandoned)
            {
                abandoned = true;
                currentPrompt = null;
                context.GetForWhom().abandonConversation(this);
                foreach (ConversationAbandonedListener listener in abandonedListeners)
                {
                    listener.ConversationAbandoned(details);
                }
            }
        }

        public void OutputNextPrompt()
        {
            if (currentPrompt == null)
            {
                Abandon(new ConversationAbandonedEvent(this));
            }
            else
            {
                context.GetForWhom().sendRawMessage(prefix.GetPrefix(context) + currentPrompt.GetPromptText(context));
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
