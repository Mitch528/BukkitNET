using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Configuration.Serialization
{
    public interface ConfigurationSerializable
    {

        Dictionary<string, object> Serialize();

    }
}
