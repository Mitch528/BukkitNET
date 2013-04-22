using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Permissions;

namespace BukkitNET.Util.Permissions
{
    public sealed class BroadcastPermissions
    {

        private static String ROOT = "bukkit.broadcast";
        private static String PREFIX = ROOT + ".";

        private BroadcastPermissions() { }

        public static Permission RegisterPermissions(Permission parent)
        {
            Permission broadcasts = DefaultPermissions.registerPermission(ROOT, "Allows the user to receive all broadcast messages", parent);

            DefaultPermissions.RegisterPermission(PREFIX + "admin", "Allows the user to receive administrative broadcasts", PermissionDefault.OP, broadcasts);
            DefaultPermissions.RegisterPermission(PREFIX + "user", "Allows the user to receive user broadcasts", PermissionDefault.True, broadcasts);

            broadcasts.RecalculatePermissibles();

            return broadcasts;
        }

    }
}
