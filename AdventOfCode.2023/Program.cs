using AdventOfCode._2023;
using AdventOfCode._2023.DayOne;

new Dictionary<IDay, IEnumerable<(string, Part)>>
{
    //{
    //    new DayOne(),
    //    new List<(string,Part)>
    //    {
    //        (File.ReadAllText($"{nameof(DayOne)}/SampleData1.txt"), Part.One),
    //        (File.ReadAllText($"{nameof(DayOne)}/Data1.txt"), Part.One),
    //        (File.ReadAllText($"{nameof(DayOne)}/SampleData2.txt"), Part.Two),
    //        (File.ReadAllText($"{nameof(DayOne)}/Data2.txt"), Part.Two),
    //    }
    //},
    {
        new DayTwo(),
        new List<(string,Part)>
        {
            (File.ReadAllText($"{nameof(DayTwo)}/SampleData1.txt"), Part.One),
            (File.ReadAllText($"{nameof(DayTwo)}/Data1.txt"), Part.One),
        }
    }
}
.ToList()
.ForEach(entry => entry.Value
    .ToList()
    .ForEach(parameters => entry.Key.Execute(parameters.Item1, parameters.Item2)));