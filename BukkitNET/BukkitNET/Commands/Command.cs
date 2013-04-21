using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BukkitNET.Entities;
using BukkitNET.Permissions;
using BukkitNET.Util;

namespace BukkitNET.Commands
{
    public abstract class Command
    {

        private string name;
        private string nextLabel;
        private string label;
        private List<string> aliases;
        private List<string> activeAliases;
        private ICommandMap commandMap = null;
        protected string description = "";
        protected string usageMessage;
        private string permission;
        private string permissionMessage;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Permission
        {
            get
            {
                return permission;
            }
            set
            {
                permission = value;
            }
        }

        public string Label
        {
            get
            {
                return label;
            }
        }

        public bool IsRegistered
        {
            get
            {
                return (null != this.commandMap);
            }
        }

        public List<string> Aliases
        {
            get
            {
                return activeAliases;
            }
        }

        public string PermissionMessage
        {
            get
            {
                return permissionMessage;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public string Usage
        {
            get
            {
                return usageMessage;
            }
        }

        protected Command(string name)
            : this(name, "", "/" + name, new List<string>())
        {
        }

        protected Command(string name, string description, string usageMessage, List<string> aliases)
        {
            this.name = name;
            this.nextLabel = name;
            this.label = name;
            this.description = description;
            this.usageMessage = usageMessage;
            this.aliases = aliases;
            this.activeAliases = new List<String>(aliases);
        }

        public abstract bool Execute(ICommandSender sender, string commandLabel, string[] args);

        public List<string> TabComplete(ICommandSender sender, string alias, string[] args)
        {
            Debug.Assert(sender != null, "Sender cannot be null");
            Debug.Assert(args != null, "Arguments cannot be null");
            Debug.Assert(alias != null, "Alias cannot be null");

            if (!(sender is IPlayer) || args.Length == 0)
            {
                return new List<string>();
            }

            string lastWord = args[args.Length - 1];

            IPlayer senderPlayer = (IPlayer)sender;

            List<string> matchedPlayers = new List<string>();
            foreach (IPlayer player in sender.GetServer().GetOnlinePlayers())
            {
                string name = player.GetName();
                if (senderPlayer.CanSee(player) && StringUtil.StartsWithIgnoreCase(name, lastWord))
                {
                    matchedPlayers.Add(name);
                }
            }

            matchedPlayers.Sort(StringComparer.OrdinalIgnoreCase);
            return matchedPlayers;
        }

        public bool TestPermission(ICommandSender target)
        {

            if (TestPermissionSilent(target))
            {
                return true;
            }

            if (permissionMessage == null)
            {
                target.SendMessage(ChatColor.RED + "I'm sorry, but you do not have permission to perform this command. Please contact the server administrators if you believe that this is in error.");
            }
            else if (permissionMessage.Length != 0)
            {
                foreach (String line in permissionMessage.Replace("<permission>", permission).Split('\n'))
                {
                    target.SendMessage(line);
                }
            }

            return false;

        }

        public bool TestPermissionSilent(ICommandSender target)
        {
            if (string.IsNullOrEmpty(permission))
            {
                return true;
            }

            foreach (string p in permission.Split(';'))
            {
                if (target.HasPermission(p))
                {
                    return true;
                }
            }

            return false;
        }

        public bool SetLabel(string name)
        {
            this.nextLabel = name;
            if (!IsRegistered)
            {
                this.label = name;
                return true;
            }
            return false;
        }

        public bool Register(ICommandMap commandMap)
        {
            if (AllowChangesFrom(commandMap))
            {
                this.commandMap = commandMap;
                return true;
            }

            return false;
        }

        public bool Unregister(ICommandMap commandMap)
        {
            if (AllowChangesFrom(commandMap))
            {
                this.commandMap = null;
                this.activeAliases = new List<string>(this.aliases);
                this.label = this.nextLabel;
                return true;
            }

            return false;
        }

        private bool AllowChangesFrom(ICommandMap commandMap)
        {
            return (null == this.commandMap || this.commandMap == commandMap);
        }

        public Command SetAliases(List<string> aliases)
        {
            this.aliases = aliases;
            if (!IsRegistered)
            {
                this.activeAliases = new List<string>(aliases);
            }
            return this;
        }

        public Command SetDescription(string description)
        {
            this.description = description;
            return this;
        }

        public Command SetPermissionMessage(string permissionMessage)
        {
            this.permissionMessage = permissionMessage;
            return this;
        }

        public Command SetUsage(string usage)
        {
            this.usageMessage = usage;
            return this;
        }

        public static void BroadcastCommandMessage(ICommandSender source, String message)
        {
            BroadcastCommandMessage(source, message, true);
        }

        public static void BroadcastCommandMessage(ICommandSender source, String message, bool sendToSource)
        {
            string result = source.Name + ": " + message;

            if (source is IBlockCommandSender && ((IBlockCommandSender)source).GetBlock().GetWorld().GetGameRuleValue("commandBlockOutput").Equals("false", StringComparison.OrdinalIgnoreCase))
            {
                Bukkit.ConsoleSender.SendMessage(result);
                return;
            }

            HashSet<IPermissible> users = Bukkit.PluginManager.GetPermissionSubscriptions(Bukkit.BROADCAST_CHANNEL_ADMINISTRATIVE);
            String colored = ChatColor.GRAY + "" + ChatColor.ITALIC + "[" + result + "]";

            if (sendToSource && !(source is IConsoleCommandSender))
            {
                source.SendMessage(message);
            }

            foreach (IPermissible user in users)
            {
                var sender = user as ICommandSender;
                if (sender != null)
                {
                    ICommandSender target = sender;

                    if (target is IConsoleCommandSender)
                    {
                        target.SendMessage(result);
                    }
                    else if (target != source)
                    {
                        target.SendMessage(colored);
                    }
                }
            }
        }

        public override string ToString()
        {
            return GetType().Name + '(' + name + ')';
        }

    }
}
