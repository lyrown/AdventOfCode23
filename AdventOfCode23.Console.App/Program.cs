using AdventOfCode23.Console.App.Helpers;
using Spectre.Console;

using Solutions = AdventOfCode23.Console.App.Solutions;

AnsiConsole.Write(
    new FigletText("Advent Of Code 23")
        .Centered()
        .Color(Color.Green));

var table = new Table();
table.ShowRowSeparators();
table.AddColumn("Day");
table.AddColumn("Solution");

// Days solution
table.InsertDay(1, Solutions.Day1.Part1.GetSolution() + "\n" + Solutions.Day1.Part2.GetSolution());
table.InsertDay(2, Solutions.Day2.Part1.GetSolution() + "\n" + Solutions.Day2.Part2.GetSolution());


AnsiConsole.Write(table);