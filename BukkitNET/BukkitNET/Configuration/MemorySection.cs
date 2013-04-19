using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BukkitNET.Inventory;
using BukkitNET.Util;

namespace BukkitNET.Configuration
{
    public class MemorySection : IConfigurationSection
    {

        protected Dictionary<string, object> map = new Dictionary<string, object>();
        private IConfiguration root;
        private IConfigurationSection parent;
        protected string path;
        protected string fullPath;

        public MemorySection()
        {

            if (!this.GetType().IsAssignableFrom(typeof(IConfiguration)))
            {
                throw new Exception("Cannot construct a root MemorySection when not a Configuration");
            }

            this.path = "";
            this.fullPath = "";
            this.parent = null;
            this.root = (IConfiguration)this;

        }

        protected MemorySection(IConfigurationSection parent, String path)
        {
            Debug.Assert(parent != null, "Parent cannot be null");
            Debug.Assert(path != null, "Path cannot be null");

            this.path = path;
            this.parent = parent;
            this.root = parent.GetRoot();

            Debug.Assert(root != null, "Path cannot be orphaned");

            this.fullPath = CreatePath(parent, path);
        }

        public HashSet<string> GetKeys(bool deep)
        {

            HashSet<string> result = new HashSet<string>();

            IConfiguration root = GetRoot();
            if (root != null && root.Options().CopyDefaults())
            {
                IConfigurationSection defaults = GetDefaultSection();

                if (defaults != null)
                {
                    result = defaults.GetKeys(deep);
                }
            }

            MapChildrenKeys(result, this, deep);

            return result;

        }

        public Dictionary<string, object> GetValues(bool deep)
        {


            Dictionary<string, object> result = new Dictionary<string, object>();

            IConfiguration root = GetRoot();
            if (root != null && root.Options().CopyDefaults())
            {
                IConfigurationSection defaults = GetDefaultSection();

                if (defaults != null)
                {
                    result = defaults.GetValues(deep);
                }
            }

            MapChildrenValues(result, this, deep);

            return result;

        }

        public bool Contains(string path)
        {
            return Get(path) != null;
        }

        public bool IsSet(string path)
        {

            IConfiguration root = GetRoot();
            if (root == null)
            {
                return false;
            }
            if (root.Options().CopyDefaults())
            {
                return Contains(path);
            }
            return Get(path, null) != null;

        }

        public string GetCurrentPath()
        {
            return fullPath;
        }

        public string GetName()
        {
            return path;
        }

        public IConfiguration GetRoot()
        {
            return root;
        }

        public IConfigurationSection GetParent()
        {
            return parent;
        }

        public object Get(string path)
        {
            return Get(path, GetDefault(path));
        }

        public object Get(string path, object def)
        {
            Debug.Assert(path != null, "Path cannot be null");

            if (path.Length == 0)
            {
                return this;
            }

            IConfiguration root = GetRoot();
            if (root == null)
            {
                throw new Exception("Cannot access section without a root");
            }

            char separator = root.Options().PathSeparator();
            // i1 is the leading (higher) index
            // i2 is the trailing (lower) index
            int i1 = -1, i2;
            IConfigurationSection section = this;
            while ((i1 = path.IndexOf(separator, i2 = i1 + 1)) != -1)
            {
                section = section.GetConfigurationSection(path.Substring(i2, i1));
                if (section == null)
                {
                    return def;
                }
            }

            string key = path.Substring(i2);
            if (section == this)
            {
                object result = map[key];
                return result ?? def;
            }
            return section.Get(key, def);
        }

        public void Set(string path, object value)
        {

            Debug.Assert(!string.IsNullOrEmpty(path), "Cannot set to an empty path");

            IConfiguration root = GetRoot();
            if (root == null)
            {
                throw new Exception("Cannot use section without a root");
            }

            char separator = root.Options().PathSeparator();
            // i1 is the leading (higher) index
            // i2 is the trailing (lower) index
            int i1 = -1, i2;
            IConfigurationSection section = this;
            while ((i1 = path.IndexOf(separator, i2 = i1 + 1)) != -1)
            {
                string node = path.Substring(i2, i1);
                IConfigurationSection subSection = section.GetConfigurationSection(node);
                if (subSection == null)
                {
                    section = section.CreateSection(node);
                }
                else
                {
                    section = subSection;
                }
            }

            String key = path.Substring(i2);
            if (section == this)
            {
                if (value == null)
                {
                    map.Remove(key);
                }
                else
                {
                    map.Add(key, value);
                }
            }
            else
            {
                section.Set(key, value);
            }

        }

        public IConfigurationSection CreateSection(string path)
        {
            Debug.Assert(!string.IsNullOrEmpty(path), "Cannot create section at empty path");
            IConfiguration root = GetRoot();
            if (root == null)
            {
                throw new Exception("Cannot create section without a root");
            }

            char separator = root.Options().PathSeparator();
            // i1 is the leading (higher) index
            // i2 is the trailing (lower) index
            int i1 = -1, i2;
            IConfigurationSection section = this;
            while ((i1 = path.IndexOf(separator, i2 = i1 + 1)) != -1)
            {
                String node = path.Substring(i2, i1);
                IConfigurationSection subSection = section.GetConfigurationSection(node);
                if (subSection == null)
                {
                    section = section.CreateSection(node);
                }
                else
                {
                    section = subSection;
                }
            }

            String key = path.Substring(i2);
            if (section == this)
            {
                IConfigurationSection result = new MemorySection(this, key);
                map.Add(key, result);
                return result;
            }
            return section.CreateSection(key);
        }

        public IConfigurationSection CreateSection<TKey, TValue>(string path, Dictionary<TKey, TValue> map)
        {

            IConfigurationSection section = CreateSection(path);

            foreach (var entry in map)
            {
                if (entry.Value is Dictionary<TKey, TValue>)
                {
                    section.CreateSection(entry.Key.ToString(), (Dictionary<TKey, TValue>)((object)entry.Value));
                }
                else
                {
                    section.Set(entry.Key.ToString(), entry.Value);
                }
            }

            return section;

        }

        public string GetString(string path)
        {
            object def = GetDefault(path);
            return GetString(path, def != null ? def.ToString() : null);
        }

        public string GetString(string path, string def)
        {
            object val = Get(path, def);
            return (val != null) ? val.ToString() : def;
        }

        public bool IsString(string path)
        {
            object val = Get(path);
            return val is string;
        }

        public int GetInt(string path)
        {
            object def = GetDefault(path);
            return GetInt(path, (def is int) ? (int)def : 0);
        }

        public int GetInt(string path, int def)
        {
            object val = Get(path, def);
            return (val is int) ? (int)val : def;
        }

        public bool IsInt(string path)
        {
            object val = Get(path);
            return val is int;
        }

        public bool GetBoolean(string path)
        {
            object def = GetDefault(path);
            return GetBoolean(path, (def is bool) && (bool)def);
        }

        public bool GetBoolean(string path, bool def)
        {
            object val = Get(path, def);
            return (val is bool) ? (bool)val : def;
        }

        public double GetDouble(string path)
        {
            object def = GetDefault(path);
            double d;
            double.TryParse(def.ToString(), out d);
            return d;
        }

        public double GetDouble(string path, double def)
        {
            object val = Get(path, def);
            double d;
            return double.TryParse(val.ToString(), out d) ? d : def;
        }

        public bool IsDouble(string path)
        {
            object val = Get(path);
            return val is double;
        }

        public long GetLong(string path)
        {
            object def = GetDefault(path);
            long l;
            long.TryParse(def.ToString(), out l);
            return GetLong(path, l);
        }

        public long GetLong(string path, long def)
        {
            object val = Get(path);
            long l;
            return long.TryParse(val.ToString(), out l) ? l : def;
        }

        public bool IsLong(string path)
        {
            object val = Get(path);
            return val is long;
        }

        public List<T> GetList<T>(string path)
        {
            object def = GetDefault(path);
            return GetList(path, (def is List<T>) ? (List<T>)def : null);
        }

        public List<T> GetList<T>(string path, List<T> def)
        {
            object val = Get(path, def);
            return ((val is List<T>) ? (List<T>)val : def);
        }

        public bool IsList<T>(string path)
        {
            object val = Get(path);
            return val is List<T>;
        }

        public List<string> GetStringList(string path)
        {

            var list = GetList<object>(path);

            if (list == null)
                return new List<string>();

            List<string> result = new List<string>();

            foreach (object obj in list)
            {
                result.Add(obj.ToString());
            }

            return result;

        }

        public List<int> GetIntegerList(string path)
        {

            var list = GetList<object>(path);

            if (list == null)
                return new List<int>();

            List<int> result = new List<int>();

            foreach (object obj in list)
            {
                try
                {
                    result.Add(int.Parse(obj.ToString()));
                }
                catch (Exception)
                {
                }
            }

            return result;

        }

        public List<bool> GetBooleanList(string path)
        {

            var list = GetList<object>(path);

            if (list == null)
                return new List<bool>();

            List<bool> result = new List<bool>();

            foreach (object obj in list)
            {
                result.Add(Convert.ToBoolean(obj));
            }

            return result;

        }

        public List<double> GetDoubleList(string path)
        {

            var list = GetList<object>(path);

            if (list == null)
                return new List<double>();

            List<double> result = new List<double>();

            foreach (object obj in list)
            {
                try
                {
                    result.Add(double.Parse(obj.ToString()));
                }
                catch (Exception)
                {
                }
            }

            return result;

        }

        public List<float> GetFloatList(string path)
        {

            var list = GetList<object>(path);

            if (list == null)
                return new List<float>();

            List<float> result = new List<float>();

            foreach (object obj in list)
            {
                try
                {
                    result.Add(float.Parse(obj.ToString()));
                }
                catch (Exception)
                {
                }
            }

            return result;

        }

        public List<byte> GetByteList(string path)
        {

            var list = GetList<object>(path);

            if (list == null)
                return new List<byte>();

            List<byte> result = new List<byte>();

            foreach (object obj in list)
            {
                list.Add(Convert.ToByte(obj));
            }

            return result;

        }

        public List<char> GetCharacterList(string path)
        {

            var list = GetList<object>(path);

            if (list == null)
                return new List<char>();

            List<char> result = new List<char>();

            foreach (object obj in list)
            {
                try
                {
                    result.Add(char.Parse(obj.ToString()));
                }
                catch (Exception)
                {
                }
            }

            return result;

        }

        public List<short> GetShortList(string path)
        {

            var list = GetList<object>(path);

            if (list == null)
                return new List<short>();

            List<short> result = new List<short>();

            foreach (object obj in list)
            {
                try
                {
                    result.Add(short.Parse(obj.ToString()));
                }
                catch (Exception)
                {
                }
            }

            return result;

        }

        public List<Dictionary<TKey, TValue>> GetMapList<TKey, TValue>(string path)
        {

            var list = GetList<object>(path);

            if (list == null)
                return new List<Dictionary<TKey, TValue>>();

            List<Dictionary<TKey, TValue>> result = new List<Dictionary<TKey, TValue>>();

            foreach (object obj in list)
            {
                if (obj is Dictionary<TKey, TValue>)
                {
                    result.Add((Dictionary<TKey, TValue>)obj);
                }
            }

            return result;

        }

        public Vector GetVector(string path)
        {
            object def = GetDefault(path);
            return GetVector(path, def is Vector ? (Vector)def : null);
        }

        public Vector GetVector(string path, Vector def)
        {
            object val = Get(path, def);
            return (val is Vector) ? (Vector)val : def;
        }

        public bool IsVector(string path)
        {
            object val = Get(path);
            return val is Vector;
        }

        public OfflinePlayer GetOfflinePlayer(string path)
        {
            object def = GetDefault(path);
            return GetOfflinePlayer(path, (def is OfflinePlayer) ? (OfflinePlayer)def : null);
        }

        public OfflinePlayer GetOfflinePlayer(string path, OfflinePlayer def)
        {
            object val = Get(path, def);
            return (val is OfflinePlayer) ? (OfflinePlayer)val : def;
        }

        public bool IsOfflinePlayer(string path)
        {
            object val = Get(path);
            return val is OfflinePlayer;
        }

        public ItemStack GetItemStack(string path)
        {
            object def = GetDefault(path);
            return GetItemStack(path, def is ItemStack ? (ItemStack)def : null);
        }

        public ItemStack GetItemStack(string path, ItemStack def)
        {
            object val = Get(path, def);
            return GetItemStack(path, val is ItemStack ? (ItemStack)val : def);
        }

        public bool IsItemStack(string path)
        {
            object val = Get(path);
            return val is ItemStack;
        }

        public Color GetColor(string path)
        {
            object def = GetDefault(path);
            return GetColor(path, def is Color ? (Color)def : null);
        }

        public Color GetColor(string path, Color def)
        {
            object val = Get(path, def);
            return (val is Color) ? (Color)val : def;
        }

        public bool IsColor(string path)
        {
            object val = Get(path);
            return val is Color;
        }

        public IConfigurationSection GetConfigurationSection(string path)
        {
            object val = Get(path, null);
            if (val != null)
            {
                return (val is IConfigurationSection) ? (IConfigurationSection)val : null;
            }

            val = Get(path, GetDefault(path));
            return (val is IConfigurationSection) ? CreateSection(path) : null;
        }

        public bool IsConfigurationSection(string path)
        {
            object val = Get(path);
            return val is IConfigurationSection;
        }

        public IConfigurationSection GetDefaultSection()
        {

            IConfiguration root = GetRoot();
            IConfiguration defaults = root == null ? null : root.GetDefaults();

            if (defaults != null)
            {
                if (defaults.IsConfigurationSection(GetCurrentPath()))
                {
                    return defaults.GetConfigurationSection(GetCurrentPath());
                }
            }

            return null;

        }

        public void AddDefault(string path, object value)
        {

            Debug.Assert(path != null, "Path cannot be null");

            IConfiguration root = GetRoot();
            if (root == null)
            {
                throw new Exception("Cannot add default without root");
            }
            if (root == this)
            {
                throw new NotImplementedException("Unsupported addDefault(String, Object) implementation");
            }
            root.AddDefault(CreatePath(this, path), value);

        }

        protected object GetDefault(String path)
        {
            Debug.Assert(path != null, "Path cannot be null");

            IConfiguration root = GetRoot();
            IConfiguration defaults = root == null ? null : root.GetDefaults();
            return (defaults == null) ? null : defaults.Get(CreatePath(this, path));
        }

        protected void MapChildrenKeys(HashSet<string> output, IConfigurationSection section, bool deep)
        {
            if (section is MemorySection)
            {
                MemorySection sec = (MemorySection)section;

                foreach (var entry in sec.map)
                {
                    output.Add(CreatePath(section, entry.Key, this));

                    if ((deep) && (entry.Value is IConfigurationSection))
                    {
                        IConfigurationSection subsection = (IConfigurationSection)entry.Value;
                        MapChildrenKeys(output, subsection, deep);
                    }
                }
            }
            else
            {
                HashSet<string> keys = section.GetKeys(deep);

                foreach (string key in keys)
                {
                    output.Add(CreatePath(section, key, this));
                }
            }
        }

        protected void MapChildrenValues(Dictionary<string, object> output, IConfigurationSection section, bool deep)
        {
            if (section is MemorySection)
            {
                MemorySection sec = (MemorySection)section;

                foreach (var entry in sec.map)
                {

                    output.Add(CreatePath(section, entry.Key, this), entry.Value);

                    var value = entry.Value as IConfigurationSection;
                    if (value != null)
                    {
                        if (deep)
                        {
                            MapChildrenValues(output, value, true);
                        }
                    }
                }
            }
            else
            {
                Dictionary<string, object> values = section.GetValues(deep);

                foreach (var entry in values)
                {
                    output.Add(CreatePath(section, entry.Key, this), entry.Value);
                }
            }
        }

        public static String CreatePath(IConfigurationSection section, string key)
        {
            return CreatePath(section, key, (section == null) ? null : section.GetRoot());
        }

        public static String CreatePath(IConfigurationSection section, string key, IConfigurationSection relativeTo)
        {
            Debug.Assert(section != null, "Cannot create path without a section");
            IConfiguration root = section.GetRoot();
            if (root == null)
            {
                throw new Exception("Cannot create path without a root");
            }
            char separator = root.Options().PathSeparator();

            StringBuilder builder = new StringBuilder();
            for (IConfigurationSection parent = section; (parent != null) && (parent != relativeTo); parent = parent.GetParent())
            {
                if (builder.Length > 0)
                {
                    builder.Insert(0, separator);
                }

                builder.Insert(0, parent.GetName());
            }

            if (!string.IsNullOrEmpty(key))
            {
                if (builder.Length > 0)
                {
                    builder.Append(separator);
                }

                builder.Append(key);
            }

            return builder.ToString();
        }

        public override string ToString()
        {
            IConfiguration root = GetRoot();
            return new StringBuilder()
                .Append(GetType().Name)
                .Append("[path='")
                .Append(GetCurrentPath())
                .Append("', root='")
                .Append(root == null ? null : root.GetType().Name)
                .Append("']")
                .ToString();
        }

    }
}
