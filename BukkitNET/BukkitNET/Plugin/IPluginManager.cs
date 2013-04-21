using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BukkitNET.Events;
using BukkitNET.Permissions;

namespace BukkitNET.Plugin
{
    public interface IPluginManager
    {

        void RegisterInterface(Type loader);

        IPlugin GetPlugin(string name);

        IPlugin[] GetPlugins();

        bool IsPluginEnabled(string name);

        bool IsPluginEnabled(IPlugin plugin);

        IPlugin LoadPlugin(FileInfo file);

        IPlugin[] LoadPlugins(DirectoryInfo directory);

        void ClearPlugins();

        void CallEvent(Event evt);

        void RegisterEvents(IListener listener, IPlugin plugin);

        void RegisterEvent(Type evt, IListener listener, EventPriority priority, EventExecutor executor, IPlugin plugin);

        void RegisterEvent(Type evt, IListener listener, EventPriority priority, EventExecutor executor, IPlugin plugin, bool ignoreCancelled);

        void EnablePlugin(IPlugin plugin);

        void DisablePlugin(IPlugin plugin);

        Permission GetPermission(string name);

        void AddPermission(Permission perm);

        void RemovePermission(Permission perm);

        void RemovePermission(string name);

        HashSet<Permission> GetDefaultPermissions(bool op);

        void RecalculatePermissionDefaults(Permission perm);

        void SubscribeToPermission(string permission, IPermissible permissible);

        void UnsubscribeFromPermission(string permission, IPermissible permissible);

        HashSet<IPermissible> GetPermissionSubscriptions(string permission);

        void SubscribeToDefaultPerms(bool op, IPermissible permissible);

        void UnsubscribeFromDefaultPerms(bool op, IPermissible permissible);

        HashSet<IPermissible> GetDefaultPermSubscriptions(bool op);

        HashSet<Permission> GetPermissions();

        bool UseTimings();

    }
}
