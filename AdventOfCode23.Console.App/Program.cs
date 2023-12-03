using AdventOfCode23.Console.App.Helpers;
using Spectre.Console;

using Day1 = AdventOfCode23.Console.App.Solutions.Day1;

AnsiConsole.Write(
    new FigletText("Advent Of Code 23")
        .Centered()
        .Color(Color.Green));

var table = new Table();
table.ShowRowSeparators();
table.AddColumn("Day");
table.AddColumn("Solution");

// Day 1
table.InsertDay(1, Day1.Part1.Solution() + "\n" + Day1.Part2.Solution());


AnsiConsole.Write(table);