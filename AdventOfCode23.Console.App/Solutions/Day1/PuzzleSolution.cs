namespace AdventOfCode23.Console.App.Solutions.Day1;

public static class PuzzleSolution
{
    public static int GetPuzzleResponse()
    {
        var fileName = Path.Combine(Environment.CurrentDirectory, nameof(Solutions), nameof(Day1), "Input.txt");
        var totalCalibrationValue = 0;

        // Read each line
        var calibrationLines = File.ReadLines(fileName);
        foreach (var calibrationLine in calibrationLines)
        {
            var calibrationValues = calibrationLine.Where(char.IsDigit);
            var concatCalibrationValue = string.Concat(calibrationValues.First(), calibrationValues.Last());

            var calibrationValue = int.Parse(concatCalibrationValue);
            totalCalibrationValue += calibrationValue;
        }

        return totalCalibrationValue;
    }
}
