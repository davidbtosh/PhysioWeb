using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtosh.Common
{
    public static class Extensions
    {
        //public static T ValueOrDefault<T>(this Nullable<T> value)
        //{
        //    return value.HasValue ? value.Value : default(T);
        //}

        public static bool GenericParse<T>(string input, out T result)
        {
            result = default(T);

            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (!string.IsNullOrEmpty(input) && converter != null)
            {
                try
                {
                    result = (T)converter.ConvertFromString(input);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public static bool NullOrEmpty<TSource>(this IEnumerable<TSource> source)
        {
            return source == null || !source.Any();
        }

        public static bool NullOrEmpty<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source == null || !source.Any();
        }

        public static bool NullOrEmpty(this string source)
        {
            return source == null || string.IsNullOrEmpty(source) || string.IsNullOrWhiteSpace(source);
        }
    }
}
