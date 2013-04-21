using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Permissions
{
    public class Permission
    {

        public static PermissionDefault DEFAULT_PERMISSION = PermissionDefault.OP;

        private string name;
        private Dictionary<string, bool> children = new Dictionary<string, bool>();
        private PermissionDefault defaultValue = DEFAULT_PERMISSION;
        private string description;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public Dictionary<string, bool> Children
        {
            get
            {
                return children;
            }
        }

        public PermissionDefault Default
        {
            get
            {
                return defaultValue;
            }
            set
            {

                if (defaultValue == null)
                {
                    throw new Exception("Default value cannot be null");
                }

                defaultValue = value;

                RecalculatePermissibles();

            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {

                if (value == null)
                {
                    description = "";
                }
                else
                {
                    description = value;
                }

            }
        }

        public Permission(string name)
            : this(name, null, default(PermissionDefault), null)
        {
        }

        public Permission(string name, string description)
            : this(name, description, default(PermissionDefault), null)
        {
        }

        public Permission(string name, PermissionDefault defaultValue)
            : this(name, null, defaultValue, null)
        {
        }

        public Permission(string name, string description, PermissionDefault defaultValue)
            : this(name, description, defaultValue, null)
        {
        }

        public Permission(string name, Dictionary<string, bool> children)
            : this(name, null, default(PermissionDefault), children)
        {
        }

        public Permission(String name, String description, Dictionary<string, bool> children)
            : this(name, description, default(PermissionDefault), children)
        {
        }

        public Permission(String name, PermissionDefault defaultValue, Dictionary<string, bool> children)
            : this(name, null, defaultValue, children)
        {
        }

        public Permission(String name, String description, PermissionDefault defaultValue, Dictionary<string, bool> children)
        {
            this.name = name;
            this.description = description ?? "";

            if (defaultValue != null)
            {
                this.defaultValue = defaultValue;
            }

            if (children != null)
            {
                this.children = children;
            }

            RecalculatePermissibles();
        }

        public HashSet<IPermissible> GetPermissibles()
        {
            return Bukkit.Server.GetPluginManager().GetPermissionSubscriptions(name);
        }

        public void RecalculatePermissibles()
        {

            HashSet<IPermissible> perms = GetPermissibles();

            Bukkit.Server.GetPluginManager().RecalculatePermissionDefaults(this);

            foreach (IPermissible p in perms)
            {
                p.RecalculatePermissions();
            }

        }

        public Permission AddParent(string name, bool value)
        {
            IPluginManager pm = Bukkit.Server.GetPluginManager();
            String lname = name.ToLower();

            Permission perm = pm.GetPermission(lname);

            if (perm == null)
            {
                perm = new Permission(lname);
                pm.AddPermission(perm);
            }

            AddParent(perm, value);

            return perm;
        }

        public void AddParent(Permission perm, bool value)
        {
            perm.Children.Add(name, value);
            perm.RecalculatePermissibles();
        }

        public static List<Permission> LoadPermissions<TKey, TValue>(Dictionary<TKey, TValue> data, string error, PermissionDefault def)
        {
            List<Permission> result = new List<Permission>();

            foreach (var entry in data)
            {
                try
                {
                    result.Add(Permission.LoadPermission(entry.Key.ToString(), (Dictionary<TKey, TValue>)((object)entry.Value), def, result));
                }
                catch (Exception ex)
                {
                    Bukkit.Server.GetLogger().Log(Level.SEVERE, String.Format(error, entry.Key), ex);
                }
            }

            return result;
        }

        public static Permission LoadPermission(string name, Dictionary<string, object> data)
        {
            return LoadPermission(name, data, DEFAULT_PERMISSION, null);
        }

        public static Permission LoadPermission<TKey, TValue>(String name, Dictionary<TKey, TValue> data, PermissionDefault def, List<Permission> output)
        {
            Debug.Assert(name != null, "Name cannot be null");
            Debug.Assert(data != null, "Data cannot be null");

            String desc = null;
            Dictionary<String, Boolean> children = null;

            if (((Dictionary<TKey, string>)((object)data))[(TKey)((object)"default")] != null)
            {
                PermissionDefault value = PermissionDefaultHelper.GetByName(data[(TKey)((object)"default")].ToString());
                if (value != default(PermissionDefault))
                {
                    def = value;
                }
                else
                {
                    throw new ArgumentException("'default' key contained unknown value");
                }
            }

            if (data[(TKey)((object)"children")] != null)
            {
                object childrenNode = data[(TKey)((object)"children")];
                if (childrenNode is IList)
                {
                    children = new Dictionary<string, bool>();
                    foreach (var child in (List<TKey>)childrenNode)
                    {
                        if (child != null)
                        {
                            children.Add(child.ToString(), true);
                        }
                    }
                }
                else if (childrenNode is Dictionary<TKey, TValue>)
                {
                    children = ExtractChildren((Dictionary<TKey, TValue>)childrenNode, name, def, output);
                }
                else
                {
                    throw new ArgumentException("'children' key is of wrong type");
                }
            }

            if (data[(TKey)((object)"description")] != null)
            {
                desc = data[(TKey)((object)"description")].ToString();
            }

            return new Permission(name, desc, def, children);
        }

        private static Dictionary<string, bool> ExtractChildren<TKey, TValue>(Dictionary<TKey, TValue> input, String name, PermissionDefault def, List<Permission> output)
        {
            Dictionary<string, bool> children = new Dictionary<string, bool>();

            foreach (var entry in input)
            {
                if (((object)entry.Value is bool))
                {
                    children.Add(entry.Key.ToString(), (bool)((object)entry.Value));
                }
                else if (((object)entry.Value is Dictionary<TKey, TValue>))
                {
                    try
                    {
                        Permission perm = LoadPermission(entry.Key.ToString(), (Dictionary<TKey, TValue>)((object)entry.Value), def, output);
                        children.Add(perm.Name, true);

                        if (output != null)
                        {
                            output.Add(perm);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException("Permission node '" + entry.Key.ToString() + "' in child of " + name + " is invalid", ex);
                    }
                }
                else
                {
                    throw new ArgumentException("Child '" + entry.Key.ToString() + "' contains invalid value");
                }
            }

            return children;
        }

    }
}
