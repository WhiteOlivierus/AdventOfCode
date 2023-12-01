namespace AdventOfCode._2023.DayOne;

public class DayOne : IDay
{
    public void Execute(string input)
    {
        input.Split(Environment.NewLine)
            .Select(line => line
                .Trim()
                .ToCharArray()
                .Where(character => char.IsDigit(character)))
            .Select(character => $"{character.First()}{character.Last()}")
            .Select(int.Parse)
            .Sum()
            .Log("Day one result: {0}");
    }
}

public interface IDay
{
    void Execute(string input);
}