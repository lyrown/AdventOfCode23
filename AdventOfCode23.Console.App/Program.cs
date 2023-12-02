using AdventOfCode23.Console.App.Helpers;
using Spectre.Console;
using Days = AdventOfCode23.Console.App.Solutions;

AnsiConsole.Write(
    new FigletText("Advent Of Code 23")
        .Centered()
        .Color(Color.Green));

var table = new Table();
table.ShowRowSeparators();
table.AddColumn("Day");
table.AddColumn("Solution");

// Day 1
var calibrationValue = Days.Day1.PuzzleSolution.GetPuzzleResponse();
table.InsertDay(1, $"Total calibration value: {calibrationValue}");

AnsiConsole.Write(table);