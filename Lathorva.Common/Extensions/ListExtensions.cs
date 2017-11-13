using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lathorva.Common.Extensions
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return true;

            return !enumerable.Any();
        }
    }
}
