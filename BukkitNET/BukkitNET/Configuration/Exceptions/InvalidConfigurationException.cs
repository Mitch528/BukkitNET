using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Configuration.Exceptions
{
    public class InvalidConfigurationException : Exception
    {

        public InvalidConfigurationException() : base()
        {
        }

        public InvalidConfigurationException(string msg) : base(msg)
        {
        }

        public InvalidConfigurationException(Exception innerException) : base("", innerException)
        {
        }

        public InvalidConfigurationException(string msg, Exception innerException) : base(msg, innerException)
        {
        }

    }
}
