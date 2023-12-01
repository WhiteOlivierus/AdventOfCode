using AdventOfCode._2023;
using AdventOfCode._2023.DayOne;

new List<IDay>
{
    new DayOne()
}
.ForEach(day =>
{
    string dayName = day.GetType().Name;
    //day.Execute(File.ReadAllText($"{dayName}/{dayName}SampleData1.txt"), Part.One);
    //day.Execute(File.ReadAllText($"{dayName}/{dayName}Data1.txt"), Part.One);
    //day.Execute(File.ReadAllText($"{dayName}/{dayName}SampleData2.txt"), Part.Two);
    day.Execute(File.ReadAllText($"{dayName}/{dayName}Data2.txt"), Part.Two);
});