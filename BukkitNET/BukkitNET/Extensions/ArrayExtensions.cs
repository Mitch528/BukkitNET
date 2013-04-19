using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Extensions
{
    public static class ArrayExtensions
    {

        public static T[] Arrays_copyOfRange<T>(this T[] original, int start, int end)
        {
            if (original.Length >= start && 0 <= start)
            {
                if (start <= end)
                {
                    int length = end - start;
                    int copyLength = Math.Min(length, original.Length - start);
                    T[] copy = (T[])Array.CreateInstance(original.GetType(), length);

                    Array.Copy(original, start, copy, 0, copyLength);
                    return copy;
                }
                throw new ArgumentException();
            }
            throw new IndexOutOfRangeException();
        }

    }
}
