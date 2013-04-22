using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Util.Permissions;

namespace BukkitNET.Permissions
{
    public sealed class CommandPermissions
    {

        private static string ROOT = "bukkit.command";
        private static string PREFIX = ROOT + ".";

        private CommandPermissions() { }

        private static Permission RegisterWhitelist(Permission parent)
        {
            Permission whitelist = DefaultPermissions.RegisterPermission(PREFIX + "whitelist", "Allows the user to modify the server whitelist", PermissionDefault.OP, parent);

            DefaultPermissions.RegisterPermission(PREFIX + "whitelist.add", "Allows the user to add a player to the server whitelist", whitelist);
            DefaultPermissions.RegisterPermission(PREFIX + "whitelist.remove", "Allows the user to remove a player from the server whitelist", whitelist);
            DefaultPermissions.RegisterPermission(PREFIX + "whitelist.reload", "Allows the user to reload the server whitelist", whitelist);
            DefaultPermissions.RegisterPermission(PREFIX + "whitelist.enable", "Allows the user to enable the server whitelist", whitelist);
            DefaultPermissions.RegisterPermission(PREFIX + "whitelist.disable", "Allows the user to disable the server whitelist", whitelist);
            DefaultPermissions.RegisterPermission(PREFIX + "whitelist.list", "Allows the user to list all the users on the server whitelist", whitelist);

            whitelist.RecalculatePermissibles();

            return whitelist;
        }

        private static Permission RegisterBan(Permission parent)
        {
            Permission ban = DefaultPermissions.RegisterPermission(PREFIX + "ban", "Allows the user to ban people", PermissionDefault.OP, parent);

            DefaultPermissions.RegisterPermission(PREFIX + "ban.player", "Allows the user to ban players", ban);
            DefaultPermissions.RegisterPermission(PREFIX + "ban.ip", "Allows the user to ban IP addresses", ban);

            ban.RecalculatePermissibles();

            return ban;
        }

        private static Permission RegisterUnban(Permission parent)
        {
            Permission unban = DefaultPermissions.RegisterPermission(PREFIX + "unban", "Allows the user to unban people", PermissionDefault.OP, parent);

            DefaultPermissions.RegisterPermission(PREFIX + "unban.player", "Allows the user to unban players", unban);
            DefaultPermissions.RegisterPermission(PREFIX + "unban.ip", "Allows the user to unban IP addresses", unban);

            unban.RecalculatePermissibles();

            return unban;
        }

        private static Permission RegisterOp(Permission parent)
        {
            Permission op = DefaultPermissions.RegisterPermission(PREFIX + "op", "Allows the user to change operators", PermissionDefault.OP, parent);

            DefaultPermissions.RegisterPermission(PREFIX + "op.give", "Allows the user to give a player operator status", op);
            DefaultPermissions.RegisterPermission(PREFIX + "op.take", "Allows the user to take a players operator status", op);

            op.RecalculatePermissibles();

            return op;
        }

        private static Permission RegisterSave(Permission parent)
        {
            Permission save = DefaultPermissions.RegisterPermission(PREFIX + "save", "Allows the user to save the worlds", PermissionDefault.OP, parent);

            DefaultPermissions.RegisterPermission(PREFIX + "save.enable", "Allows the user to enable automatic saving", save);
            DefaultPermissions.RegisterPermission(PREFIX + "save.disable", "Allows the user to disable automatic saving", save);
            DefaultPermissions.RegisterPermission(PREFIX + "save.perform", "Allows the user to perform a manual save", save);

            save.RecalculatePermissibles();

            return save;
        }

        private static Permission RegisterTime(Permission parent)
        {
            Permission time = DefaultPermissions.RegisterPermission(PREFIX + "time", "Allows the user to alter the time", PermissionDefault.OP, parent);

            DefaultPermissions.RegisterPermission(PREFIX + "time.add", "Allows the user to fast-forward time", time);
            DefaultPermissions.RegisterPermission(PREFIX + "time.set", "Allows the user to change the time", time);

            time.RecalculatePermissibles();

            return time;
        }

        public static Permission RegisterPermissions(Permission parent)
        {
            Permission commands = DefaultPermissions.RegisterPermission(ROOT, "Gives the user the ability to use all CraftBukkit commands", parent);

            RegisterWhitelist(commands);
            RegisterBan(commands);
            RegisterUnban(commands);
            RegisterOp(commands);
            RegisterSave(commands);
            RegisterTime(commands);

            DefaultPermissions.RegisterPermission(PREFIX + "kill", "Allows the user to commit suicide", PermissionDefault.True, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "me", "Allows the user to perform a chat action", PermissionDefault.True, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "tell", "Allows the user to privately message another player", PermissionDefault.True, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "say", "Allows the user to talk as the console", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "give", "Allows the user to give items to players", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "teleport", "Allows the user to teleport players", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "kick", "Allows the user to kick players", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "stop", "Allows the user to stop the server", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "list", "Allows the user to list all online players", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "help", "Allows the user to view the vanilla help menu", PermissionDefault.True, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "plugins", "Allows the user to view the list of plugins running on this server", PermissionDefault.True, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "reload", "Allows the user to reload the server settings", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "version", "Allows the user to view the version of the server", PermissionDefault.True, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "gamemode", "Allows the user to change the gamemode of another player", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "xp", "Allows the user to give themselves or others arbitrary values of experience", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "toggledownfall", "Allows the user to toggle rain on/off for a given world", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "defaultgamemode", "Allows the user to change the default gamemode of the server", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "seed", "Allows the user to view the seed of the world", PermissionDefault.OP, commands);
            DefaultPermissions.RegisterPermission(PREFIX + "effect", "Allows the user to add/remove effects on players", PermissionDefault.OP, commands);

            commands.RecalculatePermissibles();

            return commands;
        }

    }
}
