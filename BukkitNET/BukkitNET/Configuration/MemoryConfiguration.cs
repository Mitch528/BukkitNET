using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BukkitNET.Configuration
{
    public class MemoryConfiguration : MemorySection, IConfiguration
    {

        protected IConfiguration defaults;
        protected MemoryConfigurationOptions options;

        public MemoryConfiguration()
        {
        }

        public MemoryConfiguration(IConfiguration defaults)
        {
            this.defaults = defaults;
        }

        public new void AddDefault(string path, object value)
        {

            Debug.Assert(path != null, "Path may not be null");

            if (defaults == null)
            {
                defaults = new MemoryConfiguration();
            }

            defaults.Set(path, value);

        }

        public void AddDefaults(Dictionary<string, object> defaults)
        {

            Debug.Assert(defaults != null, "Defaults may not be null");

            foreach (var entry in defaults)
            {
                AddDefault(entry.Key, entry.Value);
            }

        }

        public void AddDefaults(IConfiguration defaults)
        {

            Debug.Assert(defaults != null, "Defaults may not be null");

            AddDefaults(defaults.GetValues(true));

        }

        public void SetDefaults(IConfiguration defaults)
        {

            Debug.Assert(defaults != null, "Defaults may not be null");

            this.defaults = defaults;

        }

        public IConfiguration GetDefaults()
        {
            return defaults;
        }

        public ConfigurationOptions Options()
        {
            if (options == null)
            {
                options = new MemoryConfigurationOptions(this);
            }

            return options;
        }
    }
}
