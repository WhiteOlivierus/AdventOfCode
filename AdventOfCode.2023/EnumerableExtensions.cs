namespace AdventOfCode._2023;

public static class EnumerableExtensions
{
    public static (T, T) Deconstruct<T>(this IEnumerable<T> enumerable)
    {
        return (
            enumerable.Any() ? enumerable.ElementAt(0) : throw new Exception(),
            enumerable.Count() > 1 ? enumerable.ElementAt(1) : throw new Exception());
    }

    public static bool None<T>(this IEnumerable<T> enumerable)
    {
        return !enumerable.Any();
    }

    public static bool None<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
    {
        return !enumerable.Any(predicate);
    }
}