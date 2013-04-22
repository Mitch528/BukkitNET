using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Conversations
{
    public class InactivityConversationCanceller : IConversationCanceller
    {

        protected IPlugin plugin;
        protected int timeoutSeconds;
        protected Conversation conversation;
        private int taskId = -1;

        public InactivityConversationCanceller(IPlugin plugin, int timeoutSeconds)
        {
            this.plugin = plugin;
            this.timeoutSeconds = timeoutSeconds;
        }

        public void SetConversation(Conversation conversation)
        {
            this.conversation = conversation;
            StartTimer();
        }

        private void StartTimer()
        {
            taskId = plugin.GetServer().GetScheduler().ScheduleSyncDelayedTask(plugin, () =>
            {
                if (conversation.State == Conversation.ConversationState.Unstarted)
                {
                    StartTimer();
                }
                else if (conversation.State == Conversation.ConversationState.Started)
                {
                    Cancelling(conversation);
                    conversation.Abandon(new ConversationAbandonedEventArgs(conversation, this));
                }
            }
            , timeoutSeconds * 20);
        }

        private void StopTimer()
        {
            if (taskId != -1)
            {
                plugin.GetServer().GetScheduler().CancelTask(taskId);
                taskId = -1;
            }
        }

        protected void Cancelling(Conversation conversation)
        {

        }

        public object Clone()
        {
            return new InactivityConversationCanceller(plugin, timeoutSeconds);
        }

        public bool CancelBasedOnInput(ConversationContext context, string input)
        {
            StopTimer();
            StartTimer();
            return false;
        }

    }
}
