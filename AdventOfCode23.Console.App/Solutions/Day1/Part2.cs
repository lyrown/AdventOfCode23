namespace AdventOfCode23.Console.App.Solutions.Day1;

using Helpers;

internal static class Part2
{
    public static List<string> _acceptedAlphabeticalNumbers =>
            new()
            {
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine"
            };

    public static string GetSolution()
    {
        var inputFilePath = FileHelpers.InputPath(nameof(Day1), "Input.txt");
        var totalCalibrationValue = 0;

        // Read each line
        var calibrationLines = File.ReadLines(inputFilePath);
        foreach (var calibrationLine in calibrationLines)
        {
            // Get all the numbers in this line
            var foudNumbers = new List<string>();
            getNumbers(calibrationLine, foudNumbers);

            // Get calibration value
            totalCalibrationValue += calculateCalibrationValueForLine(foudNumbers);
        }

        return $"Part 2: {totalCalibrationValue}";
    }

    private static void getNumbers(string input, List<string> foundNumbers, int currentIndex = 0)
    {
        // We still have text to parse
        if (currentIndex < input.Length)
        {
            var charAtIndex = input[currentIndex];
            if (char.IsDigit(charAtIndex))
            {
                foundNumbers.Add(charAtIndex.ToString());
            }
            else
            {
                // We have a letter
                var inputLeft = string.Concat(input.Skip(currentIndex));
                var alphabeticalNumber = getAlphabeticalNumber(inputLeft);
                if (alphabeticalNumber != null)
                {
                    // Get index because the list is sorted by number ascending
                    var indexForAlphabeticalNumber = _acceptedAlphabeticalNumbers.IndexOf(alphabeticalNumber);
                    foundNumbers.Add((indexForAlphabeticalNumber + 1).ToString());
                }
            }

            // We have found no number (numeric or alphabetical) so we go even deeper
            getNumbers(input, foundNumbers, currentIndex + 1);

        }
    }

    private static string? getAlphabeticalNumber(string input)
    {
        // Get first letter and retrieve the accepted alphabetical number that starts with this letter
        var acceptedAlphabeticalNumbersWithLetter = _acceptedAlphabeticalNumbers
            .Where(n => n.StartsWith(input[0]));

        if (!acceptedAlphabeticalNumbersWithLetter.Any())
        {
            return null; // No word
        }

        foreach (var alphabeticalNumber in acceptedAlphabeticalNumbersWithLetter)
        {
            // Get a word from input with the same length at the alphabetical number we are currently searching for
            var wordAtRange = string.Concat(input.Take(alphabeticalNumber.Length));
            if (wordAtRange.Equals(alphabeticalNumber, StringComparison.InvariantCultureIgnoreCase))
            {
                return wordAtRange;
            }
        }

        return null;
    }

    private static int calculateCalibrationValueForLine(List<string> foundNumbers)
    {
        if (foundNumbers.Count < 2)
        {
            // First is also the last number
            foundNumbers.Add(foundNumbers[0]);
        }

        var concatenatedNumber = string.Concat(foundNumbers[0], foundNumbers[foundNumbers.Count - 1]);
        return Int32.Parse(concatenatedNumber);
    }
}
