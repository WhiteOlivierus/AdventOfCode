namespace AdventOfCode._2023.DayOne;

public class DayOne : IDay
{
    private static readonly Dictionary<string, int> _spelledOutDigits = new()
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
    };

    public void Execute(string input, Part part)
    {
        switch (part)
        {
            case Part.One:
                PartOne(input);
                break;

            case Part.Two:
                PartTwo(input);
                break;
        }
    }

    private static void PartOne(string input)
    {
        _ = input.Split(Environment.NewLine)
            .Select(line => line
                .Trim()
                .Where(character => char.IsDigit(character)))
            .Select(character => $"{character.First()}{character.Last()}")
            .Select(int.Parse)
            .Sum()
            .Log($"Day one {nameof(PartOne)} result: {{0}}");
    }

    private static void PartTwo(string input)
    {
        _ = input.Split(Environment.NewLine)
            .Select(SpelledOutDigitsToDigits)
            .Select(line => line
                .Trim()
                .Where(character => char.IsDigit(character)))
            .Select(character => $"{character.First()}{character.Last()}")
            .Select(int.Parse)
            .Sum()
            .Log($"Day one {nameof(PartTwo)}  result: {{0}}");
    }

    private static string SpelledOutDigitsToDigits(string input)
    {
        _spelledOutDigits
            .OrderByDescending(entry => input.IndexOf(entry.Key, StringComparison.OrdinalIgnoreCase))
            .Reverse()
            .ToList()
            .ForEach((value) => input = input.Replace(value.Key, value.Value.ToString(), StringComparison.OrdinalIgnoreCase));

        _spelledOutDigits
            .OrderByDescending(entry => input.LastIndexOf(entry.Key, StringComparison.OrdinalIgnoreCase))
            .Reverse()
            .ToList()
            .ForEach((value) => input = input.Replace(value.Key, value.Value.ToString(), StringComparison.OrdinalIgnoreCase));

        return input;
    }
}