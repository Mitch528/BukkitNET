using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Configuration.File
{
    public class FileConfigurationOptions : MemoryConfigurationOptions
    {

        private String header = null;
        private bool copyHeader = true;

        public FileConfigurationOptions(IConfiguration configuration) : base(configuration)
        {
        }

        public new FileConfiguration Configuration()
        {
            return (FileConfiguration)base.Configuration();
        }

        public new FileConfigurationOptions CopyDefaults(bool value)
        {
            base.CopyDefaults(value);
            return this;
        }

        public new FileConfigurationOptions PathSeparator(char value)
        {
            base.PathSeparator(value);
            return this;
        }

    }
}
