namespace AdventOfCode23.Console.App.Solutions.Day4;

using AdventOfCode23.Console.App.Helpers;
using System.Text.RegularExpressions;

public class Part1
{
    public static string GetSolution()
    {
        var inputFilePath = FileHelpers.InputPath(nameof(Day4), "Input.txt");
        var lines = File.ReadAllLines(inputFilePath);

        var total = 0;
        foreach (var line in lines)
        {
            var numberSets = line.Split(':')[1].Split('|');
            var winNumbers = getNumbers(string.Concat(numberSets[0]));
            var ownNumbers = getNumbers(string.Concat(numberSets[1]));

            var matchCount = ownNumbers
                .Where(n => winNumbers.Contains(n));

            if (matchCount.Any())
            {
                var lineTotal = 1;
                for (int i = 0; i < matchCount.Count() - 1; i++)
                {
                    lineTotal = lineTotal * 2;
                }

                total += lineTotal;
            }
        }

        return $"Part 1: {total}";
    }

    private static int[] getNumbers(string lineWithNumbers) => 
        Regex
        .Split(lineWithNumbers, @"\D+")
        .Where(sn => !string.IsNullOrWhiteSpace(sn))
        .Select(sn => Int32.Parse(sn))
        .ToArray();
}