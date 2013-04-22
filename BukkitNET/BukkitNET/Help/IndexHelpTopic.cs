using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BukkitNET.Commands;
using BukkitNET.Entities;
using BukkitNET.Util;

namespace BukkitNET.Help
{
    public class IndexHelpTopic : HelpTopic
    {

        protected String permission;
        protected String preamble;
        protected Collection<HelpTopic> allTopics;

        public IndexHelpTopic(string name, string shortText, string permission, Collection<HelpTopic> topics)
            : this(name, shortText, permission, topics, null)
        {
        }

        public IndexHelpTopic(string name, string shortText, string permission, Collection<HelpTopic> topics, string preamble)
        {
            this.name = name;
            this.shortText = shortText;
            this.permission = permission;
            this.preamble = preamble;
            SetTopicsCollection(topics);
        }

        protected void SetTopicsCollection(Collection<HelpTopic> topics)
        {
            this.allTopics = topics;
        }

        public override bool CanSee(ICommandSender player)
        {
            if (player is IConsoleCommandSender)
            {
                return true;
            }
            if (permission == null)
            {
                return true;
            }
            return player.HasPermission(permission);
        }

        public String GetFullText(ICommandSender sender)
        {
            StringBuilder sb = new StringBuilder();

            if (preamble != null)
            {
                sb.Append(BuildPreamble(sender));
                sb.Append("\n");
            }

            foreach (HelpTopic topic in allTopics)
            {
                if (topic.CanSee(sender))
                {
                    String lineStr = BuildIndexLine(sender, topic).replace("\n", ". ");
                    if (sender is IPlayer && lineStr.Length > ChatPaginator.GUARANTEED_NO_WRAP_CHAT_PAGE_WIDTH)
                    {
                        sb.Append(lineStr.Substring(0, ChatPaginator.GUARANTEED_NO_WRAP_CHAT_PAGE_WIDTH - 3));
                        sb.Append("...");
                    }
                    else
                    {
                        sb.Append(lineStr);
                    }
                    sb.Append("\n");
                }
            }
            return sb.ToString();
        }

        protected String BuildPreamble(ICommandSender sender)
        {
            return ChatColor.GRAY + preamble;
        }

        protected String BuildIndexLine(ICommandSender sender, HelpTopic topic)
        {
            StringBuilder line = new StringBuilder();
            line.Append(ChatColor.GOLD);
            line.Append(topic.Name);
            line.Append(": ");
            line.Append(ChatColor.WHITE);
            line.Append(topic.ShortText);
            return line.ToString();
        }

    }
}
