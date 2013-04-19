using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Configuration
{
    /// <summary>
    /// Various settings for controlling the input and output of a 
    /// <see cref="Configuration"/>
    /// </summary>
    public class ConfigurationOptions
    {
        private char _pathSeparator = '.';
        private bool _copyDefaults = false;
        private readonly IConfiguration _configuration;

        protected ConfigurationOptions(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IConfiguration Configuration()
        {
            return _configuration;
        }

        public char PathSeparator()
        {
            return _pathSeparator;
        }

        public ConfigurationOptions PathSeparator(char value)
        {
            this._pathSeparator = value;
            return this;
        }

        public bool CopyDefaults()
        {
            return _copyDefaults;
        }

        public ConfigurationOptions CopyDefaults(bool value)
        {
            this._copyDefaults = value;
            return this;
        }

    }
}
