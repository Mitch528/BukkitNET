using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Configuration
{
    public class MemoryConfigurationOptions : ConfigurationOptions
    {

        public MemoryConfigurationOptions(IConfiguration configuration) : base(configuration)
        {
        }

        public new MemoryConfiguration Configuration()
        {
            return (MemoryConfiguration)base.Configuration();
        }

        public new MemoryConfigurationOptions CopyDefaults(bool value)
        {
            base.CopyDefaults(value);
            return this;
        }

        public new MemoryConfigurationOptions PathSeparator(char value)
        {
            base.PathSeparator(value);
            return this;
        }

    }
}
