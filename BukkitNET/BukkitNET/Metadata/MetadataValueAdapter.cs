using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Metadata
{
    public abstract class MetadataValueAdapter : IMetadataValue
    {

        protected readonly WeakReference OwningPlugin;

        protected MetadataValueAdapter(IPlugin owningPlugin)
        {
            Debug.Assert(owningPlugin != null, "owningPlugin cannot be null");
            this.OwningPlugin = new WeakReference(owningPlugin);
        }

        public abstract object Value();
        public abstract void Invalidate();

        public int AsInt()
        {
            return Convert.ToInt32(Value());
        }

        public float AsFloat()
        {
            return Convert.ToSingle(Value());
        }

        public double AsDouble()
        {
            return Convert.ToDouble(Value());
        }

        public long AsLong()
        {
            return Convert.ToInt64(Value());
        }

        public short AsShort()
        {
            return Convert.ToInt16(Value());
        }

        public byte AsByte()
        {
            return Convert.ToByte(Value());
        }

        public bool AsBoolean()
        {
            return Convert.ToBoolean(Value());
        }

        public string AsString()
        {
            return Convert.ToString(Value());
        }

        public IPlugin GetOwningPlugin()
        {
            return OwningPlugin.Target as IPlugin;
        }
    }
}
