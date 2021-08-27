using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceDesigner.Utilities
{
    public static class EnumUtilities
    {
        public static IEnumerable<T> GetAll<T>() => Enum.GetValues(typeof(T)).Cast<T>();
    }
}