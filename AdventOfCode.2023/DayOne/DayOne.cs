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
            .Select(FirstSpelledOutDigitToDigit)
            .Select(LastSpelledOutDigitToDigit)
            .Select(line => line
                .Trim()
                .Where(character => char.IsDigit(character)))
            .Select(character => $"{character.First()}{character.Last()}")
            .Select(int.Parse)
            .Sum()
            .Log($"Day one {nameof(PartTwo)} result: {{0}}");
    }

    private static string FirstSpelledOutDigitToDigit(string input)
    {
        ((string firstSpelledOutDigit, int firstDigit), int _) = _spelledOutDigits
            .Select(entry => (entry, input.IndexOf(entry.Key, StringComparison.OrdinalIgnoreCase)))
            .Where(s => s.Item2 >= 0)
            .OrderBy(s => s.Item2)
            .FirstOrDefault();

        return string.IsNullOrEmpty(firstSpelledOutDigit)
            ? input
            : input.Replace(firstSpelledOutDigit, firstDigit.ToString(), StringComparison.OrdinalIgnoreCase);
    }

    private static string LastSpelledOutDigitToDigit(string input)
    {
        IEnumerable<(KeyValuePair<string, int> entry, int)> enumerable = _spelledOutDigits
            .Select(entry => (entry, input.LastIndexOf(entry.Key, StringComparison.OrdinalIgnoreCase)))
            // Go to check for the overlapping cases and the take the first
            .Where(entry => ())
            .Where(s => s.Item2 >= 0);

        IEnumerable<(KeyValuePair<string, int> entry, int)> enumerable1 = enumerable;

        if (enumerable.Count() > 1)
        {
            enumerable1 = enumerable
                .OrderByDescending(s => s.Item2)
                .Skip(1)
                .Take(1);
        }

        ((string lastSpelledOutDigit, int lastDigit), int _) = enumerable1
            .FirstOrDefault();

        return string.IsNullOrEmpty(lastSpelledOutDigit)
            ? input
            : input.Replace(lastSpelledOutDigit, lastDigit.ToString(), StringComparison.OrdinalIgnoreCase);
    }
}