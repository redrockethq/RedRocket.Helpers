using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace RedRocket.Helpers
{
    public enum SortBy
    {
        Ascending,
        Descending
    }

    public static class EnumerableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> entities, SortBy sorting, params object[] properties)
        {
            var sortingDirection = sorting == SortBy.Ascending ?
                "Ascending" : "Descending";

            return entities.OrderBy(sortingDirection, properties);
        }

        public static IQueryable<T> OrderBy<T>(this IEnumerable<T> entities, SortBy sorting, params object[] properties)
        {
            return entities.AsQueryable().OrderBy(sorting, properties);
        }
    }
}
