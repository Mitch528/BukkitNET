using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BukkitNET.Plugin;

namespace BukkitNET.Permissions
{
    public class PermissibleBase : Permissible
    {

        private IServerOperator opable = null;
        private Permissible parent = this;
        private List<PermissionAttachment> attachments = new LinkedList<PermissionAttachment>();
        private Dictionary<string, PermissionAttachmentInfo> permissions = new Dictionary<string, PermissionAttachmentInfo>();

        public PermissibleBase(IServerOperator opable)
        {
            this.opable = opable;

            if (opable is Permissible)
            {
                this.parent = (Permissible)opable;
            }

            RecalculatePermissions();
        }

        public bool IsOp()
        {
            if (opable == null)
            {
                return false;
            }
            else
            {
                return opable.IsOp();
            }
        }

        public void SetOp(bool value)
        {
            if (opable == null)
            {
                throw new Exception("Cannot change op value as no ServerOperator is set");
            }
            else
            {
                opable.SetOp(value);
            }
        }

        public bool IsPermissionSet(string name)
        {
            if (name == null)
            {
                throw new ArgumentException("Permission name cannot be null");
            }

            return permissions.ContainsKey(name.ToLower());
        }

        public bool IsPermissionSet(Permission perm)
        {
            if (perm == null)
            {
                throw new ArgumentException("Permission cannot be null");
            }

            return IsPermissionSet(perm.Name);
        }

        public bool HasPermissions(string name)
        {

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Permission name cannot be null");
            }

            name = name.ToLower();

            if (IsPermissionSet(name))
            {
                return permissions[name].Value;
            }
            else
            {
                Permission perm = Bukkit.getServer().getPluginManager().getPermission(name);

                if (perm != null)
                {
                    return perm.Default.getValue(IsOP());
                }
                else
                {
                    return Permission.DEFAULT_PERMISSION.getValue(IsOp());
                }
            }

        }

        public bool HasPermission(Permission perm)
        {

            if (perm == null)
            {
                throw new ArgumentException("Permission cannot be null");
            }

            String name = perm.getName().toLowerCase();

            if (IsPermissionSet(name))
            {
                return permissions[name].Value;
            }
            return perm.Default.getValue(IsOp());

        }

        public PermissionAttachment AddAttachment(IPlugin plugin, string name, bool value)
        {

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Permission name cannot be null");
            }
            else if (plugin == null)
            {
                throw new ArgumentException("Plugin cannot be null");
            }
            else if (!plugin.Enabled)
            {
                throw new ArgumentException("Plugin " + plugin.PluginDescription.FullName + " is disabled");
            }

            PermissionAttachment result = AddAttachment(plugin);
            result.SetPermission(name, value);

            RecalculatePermissions();

            return result;

        }

        public PermissionAttachment AddAttachment(IPlugin plugin)
        {

            if (plugin == null)
            {
                throw new ArgumentException("Plugin cannot be null");
            }
            else if (!plugin.isEnabled())
            {
                throw new ArgumentException("Plugin " + plugin.PluginDescription.FullName + " is disabled");
            }

            PermissionAttachment result = new PermissionAttachment(plugin, parent);

            attachments.Add(result);
            RecalculatePermissions();

            return result;

        }

        public PermissionAttachment AddAttachment(IPlugin plugin, string name, bool value, int ticks)
        {

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Permission name cannot be null");
            }
            else if (plugin == null)
            {
                throw new ArgumentException("Plugin cannot be null");
            }
            else if (!plugin.Enabled)
            {
                throw new ArgumentException("Plugin " + plugin.PluginDescription.FullName + " is disabled");
            }

            PermissionAttachment result = AddAttachment(plugin, ticks);

            if (result != null)
            {
                result.SetPermission(name, value);
            }

            return result;

        }

        public PermissionAttachment AddAttachment(IPlugin plugin, int ticks)
        {

            if (plugin == null)
            {
                throw new ArgumentException("Plugin cannot be null");
            }
            else if (!plugin.Enabled)
            {
                throw new ArgumentException("Plugin " + plugin.PluginDescription.FullName + " is disabled");
            }

            PermissionAttachment result = AddAttachment(plugin);

            if (Bukkit.getServer().getScheduler().scheduleSyncDelayedTask(plugin, new RemoveAttachmentRunnable(result), ticks) == -1)
            {
                Bukkit.getServer().getLogger().log(Level.WARNING, "Could not add PermissionAttachment to " + parent + " for plugin " + plugin.PluginDescription.FullName + ": Scheduler returned -1");
                result.Remove();
                return null;
            }
            else
            {
                return result;
            }

        }

        public void RemoveAttachment(PermissionAttachment attachment)
        {
            return new HashSet<PermissionAttachmentInfo>(permissions.Values);
        }

        public void RecalculatePermissions()
        {
            throw new NotImplementedException();
        }

        public HashSet<PermissionAttachmentInfo> GetEffectivePermissions()
        {
            throw new NotImplementedException();
        }

        private class RemoveAttachmentRunnable
        {
            private PermissionAttachment attachment;

            public RemoveAttachmentRunnable(PermissionAttachment attachment)
            {
                this.attachment = attachment;
            }

            public void Run()
            {
                new Thread(RemoveAttachment).Start();
            }

            public void RemoveAttachment()
            {
                attachment.Remove();
            }

        }

    }
}
