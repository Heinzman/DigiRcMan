using System;
using System.Collections.Generic;
using System.Linq;

namespace Elreg.HelperLib
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Flatten<T>(this T source, Func<T, IEnumerable<T>> selector)
        {
            return selector(source).SelectMany(c => Flatten(c, selector)).Concat(new[] { source });
        }
    }
}
