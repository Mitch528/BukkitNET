using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Conversations
{
    public abstract class PluginNameConversationPrefix : IConversationPrefix
    {

        protected String separator;
        protected ChatColor prefixColor;
        protected IPlugin plugin;

        private String cachedPrefix;

        protected PluginNameConversationPrefix(IPlugin plugin)
            : this(plugin, " > ", ChatColor.LightPurple)
        {
        }

        protected PluginNameConversationPrefix(IPlugin plugin, string separator, ChatColor prefixColor)
        {
            this.separator = separator;
            this.prefixColor = prefixColor;
            this.plugin = plugin;

            cachedPrefix = prefixColor + plugin.GetPluginInfo().Name + separator + ChatColor.White;
        }

        public string GetPrefix(ConversationContext context)
        {
            return cachedPrefix;
        }
    }
}
