using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceDesigner
{
    public static class EnumUtility
    {
        public static IEnumerable<T> GetAll<T>() => Enum.GetValues(typeof(T)).Cast<T>();
    }
}