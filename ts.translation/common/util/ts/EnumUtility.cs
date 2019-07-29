using System;
using System.Collections.Generic;
using System.Linq;

namespace ts.translation.common.util.ts
{
    internal static class EnumUtility<T>
    {
        internal static IEnumerable<T> GetValues()
        {
            IEnumerable<T> vals = Enum.GetValues(typeof(T)).Cast<T>();
            return vals;
        }
    }
}