namespace AdventOfCode._2023;

public static class ConsoleExtensions
{
    public static T Log<T>(this T obj)
    {
        Console.WriteLine(obj);
        return obj;
    }

    public static T Log<T>(this T obj, string format)
    {
        Console.WriteLine(string.Format(format, obj));
        return obj;
    }
}