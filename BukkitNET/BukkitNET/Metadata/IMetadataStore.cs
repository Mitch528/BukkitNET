using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Metadata
{
    public interface IMetadataStore<T>
    {

        void SetMetadata(T subject, string metadataKey, IMetadataValue newMetadataValue);

        List<IMetadataValue> GetMetadata(T subject, string metadataKey);

        bool HasMetadata(T subject, string metadataKey);

        void RemoveMetadata(T subject, string metadataKey, IPlugin owningPlugin);

        void InvalidateAll(IPlugin owningPlugin);

    }
}
