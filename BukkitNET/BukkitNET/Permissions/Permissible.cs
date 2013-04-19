using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Permissions
{
    public interface Permissible : IServerOperator
    {

        bool IsPermissionSet(string name);

        bool IsPermissionSet(Permission perm);

        bool HasPermissions(string name);

        bool HasPermission(Permission perm);

        PermissionAttachment AddAttachment(IPlugin plugin, string name, bool value);

        PermissionAttachment AddAttachment(IPlugin plugin);

        PermissionAttachment AddAttachment(IPlugin plugin, String name, bool value, int ticks);

        PermissionAttachment AddAttachment(IPlugin plugin, int ticks);

        void RemoveAttachment(PermissionAttachment attachment);

        void RecalculatePermissions();

        HashSet<PermissionAttachmentInfo> GetEffectivePermissions();

    }
}
