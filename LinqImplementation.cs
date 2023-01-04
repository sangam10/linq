namespace linq;

public static class IEnumerableExtension
{
    public static IEnumerable<T> NewWhere<T>(this IEnumerable<T> items, Func<T, bool> predicate)
    {
        foreach (var item in items)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }
    public static IEnumerable<TResult> NewSelect<T, TResult>(this IEnumerable<T> items, Func<T, TResult> selector)
    {
        foreach (var item in items)
        {
            yield return selector(item);
        }
    }

    public static IEnumerable<TResult> NewJoin<T, Tinner, TKey, TResult>(
            this IEnumerable<T> items,
           IEnumerable<Tinner> innerItems,
           Func<T, TKey> outerKeySelector,
           Func<Tinner, TKey> innerKeySelector,
           Func<T, Tinner, TResult> resultSelector

        )
    {
        foreach (var item in items)
        {
            foreach (var innerItem in innerItems)
            {
                if (outerKeySelector(item).Equals(innerKeySelector(innerItem)))
                {
                    yield return resultSelector(item, innerItem);
                }
            }
        }
    }
}