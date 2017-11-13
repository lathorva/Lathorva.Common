using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lathorva.Common.Extensions
{
    public static class EnumExtensions
    {
        public static Dictionary<int, string> EnumToDictionary<T>(this T t2)
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToDictionary(t =>
                        (int)Convert.ChangeType(t, t.GetType()),
                    t => t.ToString()
                );
        }
    }
}
