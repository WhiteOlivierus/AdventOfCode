namespace AdventOfCode._2023.DayOne;

public class DayTwo : IDay
{
    private const char _gameIndexAndDataSeparator = ':';
    private const char _gameIndexSeparator = ' ';
    private const char _cubeDataSeparator = ' ';

    private static readonly char[] _cubeSeparators = [',', ';'];

    private static readonly Dictionary<string, int> _knowAmountOfCubes = new()
    {
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 }
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
        input
            .Split(Environment.NewLine)
            .Select(line => line.SplitInTwo(_gameIndexAndDataSeparator))
            .Select(parts => (
                gameIndex: ParseGameIndex(parts),
                parameters: ParseGameParameters(parts)))
            .Where(FitsKnowAmountOfCubes)
            .Select(s => s.gameIndex)
            .Sum()
            .Log($"Day two {nameof(PartOne)} result: {{0}}");
    }

    private static bool FitsKnowAmountOfCubes((int, IEnumerable<IEnumerable<(int, string)>>) tuple)
    {
        return tuple
            .Item2
            .SelectMany(s => s)
            .GroupBy(part => part.Item2)
            .None(group => group.Select(s => s.Item1).Any(t => t >= _knowAmountOfCubes[group.Key]));
    }

    private static IEnumerable<IEnumerable<(int, string)>> ParseGameParameters((string, string) parts)
    {
        return parts
            .Item2
            .Split(';')
            .Select(s => s.Split(','))
            .Select(s => s.Select(f => f.Trim()))
            .Select(cubeLine => cubeLine.Select(t => t.SplitInTwo(_cubeDataSeparator)))
            .Select(cubeData => cubeData.Select(n => (
                n.Item1.ToInt(),
                n.Item2)))
                    ?? Enumerable.Empty<IEnumerable<(int, string)>>();
    }

    private static int ParseGameIndex((string, string) parts)
    {
        return parts
            .Item1
            .Split(_gameIndexSeparator)
            .Last()
            .ToInt();
    }

    private static void PartTwo(string input)
    {
    }
}