﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using BukkitNET.Extensions;
using BukkitNET.Util;

namespace BukkitNET.Commands
{
    public class SimpleCommandMap : ICommandMap
    {

        private static Regex PATTERN_ON_SPACE = new Regex(" ", RegexOptions.Compiled);
        protected Dictionary<string, Command> knownCommands = new Dictionary<string, Command>();
        protected HashSet<string> aliases = new HashSet<string>();
        private IServer server;
        protected static HashSet<VanillaCommand> fallbackCommands = new HashSet<VanillaCommand>();

        public HashSet<VanillaCommand> FallbackCommands
        {
            get
            {
                return fallbackCommands;
            }
        }

        static SimpleCommandMap()
        {

            fallbackCommands.add(new ListCommand());
            fallbackCommands.add(new OpCommand());
            fallbackCommands.add(new DeopCommand());
            fallbackCommands.add(new BanIpCommand());
            fallbackCommands.add(new PardonIpCommand());
            fallbackCommands.add(new BanCommand());
            fallbackCommands.add(new PardonCommand());
            fallbackCommands.add(new KickCommand());
            fallbackCommands.add(new TeleportCommand());
            fallbackCommands.add(new GiveCommand());
            fallbackCommands.add(new TimeCommand());
            fallbackCommands.add(new SayCommand());
            fallbackCommands.add(new WhitelistCommand());
            fallbackCommands.add(new TellCommand());
            fallbackCommands.add(new MeCommand());
            fallbackCommands.add(new KillCommand());
            fallbackCommands.add(new GameModeCommand());
            fallbackCommands.add(new HelpCommand());
            fallbackCommands.add(new ExpCommand());
            fallbackCommands.add(new ToggleDownfallCommand());
            fallbackCommands.add(new BanListCommand());
            fallbackCommands.add(new DefaultGameModeCommand());
            fallbackCommands.add(new SeedCommand());
            fallbackCommands.add(new DifficultyCommand());
            fallbackCommands.add(new WeatherCommand());
            fallbackCommands.add(new SpawnpointCommand());
            fallbackCommands.add(new ClearCommand());
            fallbackCommands.add(new GameRuleCommand());
            fallbackCommands.add(new EnchantCommand());
            fallbackCommands.add(new TestForCommand());
            fallbackCommands.add(new EffectCommand());
            fallbackCommands.add(new ScoreboardCommand());

        }

        public SimpleCommandMap(IServer server)
        {
            this.server = server;
            SetDefaultCommands(server);
        }

        private void SetDefaultCommands(IServer server)
        {
            Register("bukkit", new SaveCommand());
            Register("bukkit", new SaveOnCommand());
            Register("bukkit", new SaveOffCommand());
            Register("bukkit", new StopCommand());
            Register("bukkit", new VersionCommand("version"));
            Register("bukkit", new ReloadCommand("reload"));
            Register("bukkit", new PluginsCommand("plugins"));
            Register("bukkit", new TimingsCommand("timings"));
        }

        public void RegisterAll(string fallbackPrefix, List<Command> commands)
        {
            if (commands != null)
            {
                foreach (Command c in commands)
                {
                    Register(fallbackPrefix, c);
                }
            }
        }

        public bool Register(string fallbackPrefix, Command command)
        {
            return Register(command.Name, fallbackPrefix, command);
        }

        public bool Register(string label, string fallbackPrefix, Command command)
        {

            bool registeredPassedLabel = Register(label, fallbackPrefix, command, false);

            List<string> aliases = command.Aliases;

            for (int i = 0; i < aliases.Count; i++)
            {

                if (!Register(aliases[i], fallbackPrefix, command, true))
                {
                    aliases.Remove(aliases[i]);
                }

            }

            command.Register(this);

            return registeredPassedLabel;

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private bool Register(string label, string fallbackPrefix, Command command, bool isAlias)
        {
            string lowerLabel = label.Trim().ToLower();

            if (isAlias && knownCommands.ContainsKey(lowerLabel))
            {
                return false;
            }

            String lowerPrefix = fallbackPrefix.trim().toLowerCase();
            bool registerdPassedLabel = true;

            while (knownCommands.ContainsKey(lowerLabel) && !aliases.Contains(lowerLabel))
            {
                lowerLabel = lowerPrefix + ":" + lowerLabel;
                registerdPassedLabel = false;
            }

            if (isAlias)
            {
                aliases.Add(lowerLabel);
            }
            else
            {
                aliases.Remove(lowerLabel);
                command.Label = lowerLabel;
            }

            knownCommands.Add(lowerLabel, command);

            return registerdPassedLabel;
        }



        public bool Dispatch(CommandSender sender, string cmdLine)
        {

            string[] args = PATTERN_ON_SPACE.Split(cmdLine);

            if (args.length == 0)
            {
                return false;
            }

            String sentCommandLabel = args[0].ToLower();
            Command target = GetCommand(sentCommandLabel);

            if (target == null)
            {
                return false;
            }

            try
            {
                target.Execute(sender, sentCommandLabel, args.Arrays_copyOfRange(1, args.Length));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ClearCommands()
        {
            foreach (var entry in knownCommands)
            {
                entry.Value.Unregister(this);
            }
            knownCommands.Clear();
            aliases.Clear();
            SetDefaultCommands(server);
        }

        public Command GetCommand(string name)
        {
            Command target = knownCommands[name.ToLower()];
            if (target == null)
            {
                target = GetFallback(name);
            }
            return target;
        }

        public List<string> TabComplete(CommandSender sender, string cmdLine)
        {

            Debug.Assert(sender != null, "Sender cannot be null");
            Debug.Assert(cmdLine != null, "Command line cannot null");

            int spaceIndex = cmdLine.IndexOf(' ');

            if (spaceIndex == -1)
            {
                List<String> completions = new List<String>();
                Dictionary<string, Command> knownCommands = this.knownCommands;

                foreach (VanillaCommand command in fallbackCommands)
                {
                    String name = command.getName();

                    if (!command.TestPermissionSilent(sender))
                    {
                        continue;
                    }
                    if (knownCommands.ContainsKey(name))
                    {
                        continue;
                    }
                    if (!StringUtil.StartsWithIgnoreCase(name, cmdLine))
                    {
                        continue;
                    }

                    completions.Add('/' + name);
                }

                foreach (var entry in knownCommands)
                {
                    Command command = commandEntry.getValue();

                    if (!command.TestPermissionSilent(sender))
                    {
                        continue;
                    }

                    String name = commandEntry.Key;

                    if (StringUtil.StartsWithIgnoreCase(name, cmdLine))
                    {
                        completions.Add('/' + name);
                    }
                }

                
                completions.Sort(StringComparer.OrdinalIgnoreCase);
                return completions;
            }

        }

        protected Command GetFallback(String label)
        {
            foreach (VanillaCommand cmd in fallbackCommands)
            {
                if (cmd.Matches(label))
                {
                    return cmd;
                }
            }

            return null;
        }



    }
}
