using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Metadata
{
    public class MetadataStoreBase<T>
    {

        private Dictionary<string, Dictionary<IPlugin, IMetadataValue>> metadataMap = new Dictionary<string, Dictionary<IPlugin, IMetadataValue>>();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void SetMetadata(T subject, string metadataKey, IMetadataValue newMetadataValue)
        {
            IPlugin owningPlugin = newMetadataValue.GetOwningPlugin();
            Debug.Assert(newMetadataValue != null, "Value cannot be null");
            Debug.Assert(owningPlugin != null, "Plugin cannot be null");
            string key = Disambiguate(subject, metadataKey);
            Dictionary<IPlugin, IMetadataValue> entry = metadataMap[key];
            if (entry == null)
            {
                entry = (Dictionary<IPlugin, IMetadataValue>)new WeakReference(new Dictionary<IPlugin, IMetadataValue>(1)).Target;
                metadataMap.Add(key, entry);
            }
            entry.Add(owningPlugin, newMetadataValue);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<IMetadataValue> GetMetadata(T subject, string metadataKey)
        {
            String key = Disambiguate(subject, metadataKey);
            if (metadataMap.ContainsKey(key))
            {
                var values = metadataMap[key].Values;
                return new List<IMetadataValue>(values);
            }
            else
            {
                return new List<IMetadataValue>();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool HasMetadata(T subject, string metadataKey)
        {
            String key = Disambiguate(subject, metadataKey);
            return metadataMap.ContainsKey(key);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void RemoveMetadata(T subject, String metadataKey, IPlugin owningPlugin)
        {
            Debug.Assert(owningPlugin != null, "Plugin cannot be null");
            String key = Disambiguate(subject, metadataKey);
            var entry = metadataMap[key];
            if (entry == null)
            {
                return;
            }

            entry.Remove(owningPlugin);
            if (!entry.Any())
            {
                metadataMap.Remove(key);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InvalidateAll(IPlugin owningPlugin)
        {
            Debug.Assert(owningPlugin != null, "Plugin cannot be null");
            foreach (var values in metadataMap.Values)
            {
                if (values.ContainsKey(owningPlugin))
                {
                    values[owningPlugin].Invalidate();
                }
            }
        }

        protected abstract string Disambiguate(T subject, string metadataKey);

    }
}
