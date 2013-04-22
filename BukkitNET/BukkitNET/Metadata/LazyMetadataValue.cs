using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Metadata
{
    public class LazyMetadataValue : MetadataValueAdapter
    {

        private Func<object> lazyValue;
        private CacheStrategy cacheStrategy;
        private WeakReference internalValue;
        private static Object ACTUALLY_NULL = new object();

        public LazyMetadataValue(IPlugin owningPlugin, Func<object> lazyValue)
            : this(owningPlugin, CacheStrategy.CacheAfterFirstEval, lazyValue)
        {
        }

        public LazyMetadataValue(IPlugin owningPlugin, CacheStrategy cacheStrategy, Func<object> lazyValue)
            : base(owningPlugin)
        {
            
            Debug.Assert(lazyValue != null, "lazyValue cannot be null");
            this.internalValue = new WeakReference(null);
            this.lazyValue = lazyValue;
            this.cacheStrategy = cacheStrategy;
        }

        public LazyMetadataValue(IPlugin owningPlugin)
            : base(owningPlugin)
        {
        }

        public override object Value()
        {
            Eval();
            object value = internalValue.Target;
            if (value == ACTUALLY_NULL)
            {
                return null;
            }
            return value;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void Eval()
        {
            if (cacheStrategy == CacheStrategy.NeverCache || internalValue.Target == null)
            {
                try
                {
                    object value = lazyValue.Invoke();
                    if (value == null)
                    {
                        value = ACTUALLY_NULL;
                    }
                    internalValue = new WeakReference(value);
                }
                catch (Exception e)
                {
                    throw new MetadataEvaluationException(e);
                }
            }
        }



        public override void Invalidate()
        {
            if (cacheStrategy != CacheStrategy.CacheEternally)
            {
                internalValue = null;
            }
        }

    }

    public enum CacheStrategy
    {
        CacheAfterFirstEval,
        NeverCache,
        CacheEternally
    }

}
