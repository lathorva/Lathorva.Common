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

        /// <summary>
        /// Taks an enum and returns entire list of values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="removeUnknown"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToList<T>(bool removeUnknown = true) where T : struct , IConvertible
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");

            return Enum.GetValues(typeof(T)).Cast<T>().Where(e => !removeUnknown || Convert.ToInt32(e) != 0);
        }

    }
}
