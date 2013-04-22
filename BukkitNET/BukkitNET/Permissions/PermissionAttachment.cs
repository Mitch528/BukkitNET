using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Permissions
{
    public class PermissionAttachment
    {

        private IPermissionRemovedExecutor removed;
        private Dictionary<string, bool> permissions = new Dictionary<string, bool>();
        private IPermissible permissible;
        private IPlugin plugin;

        public IPlugin Plugin
        {
            get
            {
                return plugin;
            }
        }

        public IPermissible Permissible
        {
            get
            {
                return permissible;
            }
        }

        public Dictionary<string, bool> Permissions
        {
            get
            {
                return permissions;
            }
        }



        public PermissionAttachment(IPlugin plugin, IPermissible Permissible)
        {
            if (plugin == null)
            {
                throw new ArgumentException("Plugin cannot be null");
            }
            else if (!plugin.IsEnabled())
            {
                throw new ArgumentException("Plugin " + plugin.GetPluginInfo().FullName + " is disabled");
            }

            this.permissible = Permissible;
            this.plugin = plugin;
        }

        public void SetRemovalCallback(IPermissionRemovedExecutor ex)
        {
            removed = ex;
        }

        public IPermissionRemovedExecutor GetRemovalCallback()
        {
            return removed;
        }

        public void SetPermission(string name, bool value)
        {

            if (permissions.ContainsKey(name.ToLower()))
                return;

            permissions.Add(name.ToLower(), value);
            permissible.RecalculatePermissions();

        }

        public void SetPermission(Permission perm, bool value)
        {
            SetPermission(perm.Name, value);
        }

        public void UnsetPermission(string name)
        {
            permissions.Remove(name.ToLower());
            permissible.RecalculatePermissions();
        }

        public void UnsetPermission(Permission perm)
        {
            UnsetPermission(perm.Name);
        }

        public bool Remove()
        {
            try
            {
                permissible.RemoveAttachment(this);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
