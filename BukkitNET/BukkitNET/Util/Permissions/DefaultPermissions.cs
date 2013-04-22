using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Permissions;

namespace BukkitNET.Util.Permissions
{
    public static class DefaultPermissions
    {

        private static string ROOT = "craftbukkit";
        private static string LEGACY_PREFIX = "craft";

        public static Permission RegisterPermission(Permission perm)
        {
            return RegisterPermission(perm, true);
        }

        public static Permission RegisterPermission(Permission perm, bool withLegacy)
        {
            Permission result = perm;

            try
            {
                Bukkit.PluginManager.AddPermission(perm);
            }
            catch (Exception ex)
            {
                result = Bukkit.PluginManager.GetPermission(perm.Name);
            }

            if (withLegacy)
            {
                Permission legacy = new Permission(LEGACY_PREFIX + result.Name, result.Description, PermissionDefault.False);
                legacy.Children.Add(result.Name, true);
                RegisterPermission(perm, false);
            }

            return result;
        }

        public static Permission RegisterPermission(Permission perm, Permission parent)
        {
            parent.Children.Add(perm.Name, true);
            return RegisterPermission(perm);
        }

        public static Permission RegisterPermission(string name, string desc)
        {
            Permission perm = RegisterPermission(new Permission(name, desc));
            return perm;
        }

        public static Permission RegisterPermission(string name, string desc, Permission parent)
        {
            Permission perm = RegisterPermission(name, desc);
            if (!parent.Children.ContainsKey(perm.Name))
                parent.Children.Add(perm.Name, true);
            return perm;
        }

        public static Permission RegisterPermission(string name, string desc, PermissionDefault def)
        {
            Permission perm = RegisterPermission(new Permission(name, desc, def));
            return perm;
        }

        public static Permission RegisterPermission(string name, string desc, PermissionDefault def, Permission parent)
        {
            Permission perm = RegisterPermission(name, desc, def);
            if (!parent.Children.ContainsKey(perm.Name))
                parent.Children.Add(perm.Name, true);
            return perm;
        }

        public static Permission RegisterPermission(string name, string desc, PermissionDefault def, Dictionary<string, bool> children)
        {
            Permission perm = RegisterPermission(new Permission(name, desc, def, children));
            return perm;
        }

        public static Permission RegisterPermission(string name, string desc, PermissionDefault def, Dictionary<string, bool> children, Permission parent)
        {
            Permission perm = RegisterPermission(name, desc, def, children);
            if (!parent.Children.ContainsKey(perm.Name))
                parent.Children.Add(perm.Name, true);
            return perm;
        }

        public static void RegisterCorePermissions()
        {
            Permission parent = RegisterPermission(ROOT, "Gives the user the ability to use all CraftBukkit utilities and commands");

            CommandPermissions.RegisterPermissions(parent);
            BroadcastPermissions.RegisterPermissions(parent);

            parent.RecalculatePermissibles();
        }

    }
}
