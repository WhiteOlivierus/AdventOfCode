using AdventOfCode._2023.DayOne;




new List<IDay>
{
    new DayOne()
}
.ForEach(day =>
{
    string dayName = day.GetType().Name;
    day.Execute(File.ReadAllText($"{dayName}/{dayName}Data.txt"));
    day.Execute(File.ReadAllText($"{dayName}/{dayName}SampleData.txt"));
});
