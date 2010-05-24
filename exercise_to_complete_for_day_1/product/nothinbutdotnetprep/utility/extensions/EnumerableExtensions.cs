using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Predicate<T> criteria)
        {
            foreach (var item in items) if (criteria(item)) yield return item;
        }

        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }
    }
}