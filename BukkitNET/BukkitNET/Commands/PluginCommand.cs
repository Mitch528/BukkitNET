using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Commands
{
    public sealed class PluginCommand : Command, IPluginIdentifiableCommand
    {

        private IPlugin owningPlugin;
        private ICommandExecutor executor;
        private ITabCompleter completer;

        public ICommandExecutor Executor
        {
            get
            {
                return executor;
            }
            set
            {
                executor = value == null ? (ICommandExecutor)owningPlugin : value;
            }
        }

        public ITabCompleter TabCompleter
        {
            get
            {
                return completer;
            }
            set
            {
                completer = value;
            }
        }



        private PluginCommand(string name, IPlugin owner)
            : this(name)
        {
            this.executor = (ICommandExecutor)owner;
            this.owningPlugin = owner;
            this.usageMessage = "";
        }

        public PluginCommand(string name)
            : base(name)
        {
        }

        public PluginCommand(string name, string description, string usageMessage, List<string> aliases)
            : base(name, description, usageMessage, aliases)
        {
        }

        public override bool Execute(ICommandSender sender, string commandLabel, string[] args)
        {

            bool success = false;

            if (!owningPlugin.IsEnabled())
            {
                return false;
            }

            if (!TestPermission(sender))
            {
                return true;
            }

            try
            {
                success = executor.OnCommand(sender, this, commandLabel, args);
            }
            catch (Exception ex)
            {
                throw new CommandException("Unhandled exception executing command '" + commandLabel + "' in plugin " + owningPlugin.GetPluginInfo().FullName, ex);
            }

            if (!success && usageMessage.Length > 0)
            {
                foreach (string line in usageMessage.Replace("<command>", commandLabel).Split('\n'))
                {
                    sender.SendMessage(line);
                }
            }

            return success;

        }


        public IPlugin GetPlugin()
        {
            return owningPlugin;
        }

        public List<String> TabComplete(ICommandSender sender, string alias, string[] args)
        {
            Debug.Assert(sender != null, "Sender cannot be null");
            Debug.Assert(args != null, "Arguments cannot be null");
            Debug.Assert(alias != null, "Alias cannot be null");

            List<string> completions = null;
            try
            {
                if (completer != null)
                {
                    completions = completer.OnTabComplete(sender, this, alias, args);
                }
                if (completions == null && executor is ITabCompleter)
                {
                    completions = ((ITabCompleter)executor).OnTabComplete(sender, this, alias, args);
                }
            }
            catch (Exception ex)
            {
                var message = new StringBuilder();
                message.Append("Unhandled exception during tab completion for command '/").Append(alias).Append(' ');
                foreach (String arg in args)
                {
                    message.Append(arg).Append(' ');
                }
                message.Remove(message.Length - 1, message.Length).Append("' in plugin ").Append(owningPlugin.GetPluginInfo().FullName);
                throw new CommandException(message.ToString(), ex);
            }

            if (completions == null)
            {
                return base.TabComplete(sender, alias, args);
            }
            return completions;
        }

    }
}
