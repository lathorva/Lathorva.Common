using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lathorva.Common.Extensions
{
    public static class StringExtensions
    {
            public static string ReplaceLastOccurrence(this string source, string find, string replace)
            {
                var place = source.LastIndexOf(find, StringComparison.Ordinal);

                if (place == -1)
                    return source;

                var result = source.Remove(place, find.Length).Insert(place, replace);
                return result;
            }

            

            public static string UppercaseFirst(this string s)
            {
                // Check for empty string.
                if (string.IsNullOrEmpty(s))
                {
                    return string.Empty;
                }
                // Return char and concat substring.
                return char.ToUpper(s[0]) + s.Substring(1);
            }

            public static string LowercaseFirst(this string s)
            {
                // Check for empty string.
                if (string.IsNullOrEmpty(s))
                {
                    return string.Empty;
                }
                // Return char and concat substring.
                return char.ToLower(s[0]) + s.Substring(1);
            }

            

            public static bool ContainsAny(this string haystack, params string[] needles)
            {
                foreach (string needle in needles)
                {
                    if (haystack.Contains(needle))
                        return true;
                }

                return false;
            }
    }
}
