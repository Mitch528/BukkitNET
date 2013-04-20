using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Metadata
{
    public interface IMetadatable
    {

        void SetMetadata(string metadataKey, IMetadataValue newMetadataValue);

        List<IMetadataValue> GetMetadata(string metadataKey);

        bool HasMetadata(String metadataKey);

        void RemoveMetadata(string metadataKey, IPlugin owningPlugin);

    }
}
