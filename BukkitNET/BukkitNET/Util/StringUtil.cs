using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BukkitNET.Util
{
    public class StringUtil
    {

        public static Collection<T> CopyPartialMatches<T>(String token, List<string> originals, Collection<T> collection)
        {
            Debug.Assert(token != null, "Search token cannot be null");
            Debug.Assert(collection != null, "Collection cannot be null");
            Debug.Assert(originals != null, "Originals cannot be null");

            foreach (string str in originals)
            {
                if (StartsWithIgnoreCase(str, token))
                {
                    collection.Add((T)((object)str));
                }
            }

            return collection;
        }

        public static bool StartsWithIgnoreCase(string str, string prefix)
        {
            Debug.Assert(str != null, "Cannot check a null string for a match");
            if (str.Length < prefix.Length)
            {
                return false;
            }
            return str.Substring(0, prefix.Length).Equals(prefix, StringComparison.OrdinalIgnoreCase);
        }

    }
}
