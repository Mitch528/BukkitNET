using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Metadata
{
    public interface IMetadataValue
    {

        object Value();

        int AsInt();

        float AsFloat();

        double AsDouble();

        long AsLong();

        short AsShort();

        byte AsByte();

        bool AsBoolean();

        string AsString();

        IPlugin GetOwningPlugin();

        void Invalidate();

    }
}
