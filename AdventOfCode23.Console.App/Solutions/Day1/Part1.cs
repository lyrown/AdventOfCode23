namespace AdventOfCode23.Console.App.Solutions.Day1;

using Helpers;

internal static class Part1
{
    public static string GetSolution()
    {
        var inputFilePath = FileHelpers.InputPath(nameof(Day1), "Input.txt");
        var totalCalibrationValue = 0;

        // Read each line
        var calibrationLines = File.ReadLines(inputFilePath);
        foreach (var calibrationLine in calibrationLines)
        {
            var digitCalibrationValues = calibrationLine.Where(char.IsDigit);
            if (digitCalibrationValues.Any())
            {
                var concatCalibrationValue = string.Concat(digitCalibrationValues.First(), digitCalibrationValues.Last());
                var calibrationValue = int.Parse(concatCalibrationValue);
                totalCalibrationValue += calibrationValue;
            }
        }

        return $"Part 1: {totalCalibrationValue}";
    }
}
