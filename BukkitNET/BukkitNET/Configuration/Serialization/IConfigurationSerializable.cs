using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Configuration.Serialization
{
    public interface IConfigurationSerializable
    {

        Dictionary<string, object> Serialize();

    }
}
