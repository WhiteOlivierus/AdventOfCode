namespace AdventOfCode._2023;

public static class StringExtensions
{
    public static int ToInt(this string value)
    {
        return int.TryParse(value, out int result)
            ? result
            : -1;
    }

    public static (string, string) SplitInTwo(this string value, char separator)
    {
        return value
            .Split(separator)
            .Select(s => s.Trim())
            .Deconstruct();
    }
}