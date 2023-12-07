using AdventOfCode23.Console.App.Helpers;

namespace AdventOfCode23.Console.App.Solutions.Day3;

public class Part1
{
    public static string GetSolution()
    {
        var inputFilePath = FileHelpers.InputPath(nameof(Day3), "Input.txt");
        var lines = File.ReadAllLines(inputFilePath);

        var total = 0;
        var lineIndex = 0;
        foreach (var line in lines)
        {
            var rowIndex = 0;
            foreach (var rowChar in line)
            {
                // Found a special char
                if (rowChar.IsSpecialChar())
                {
                    var numbers = findNumbersAround(lines, lineIndex, rowIndex);
                    total += numbers?.Sum() ?? 0;
                }
                rowIndex++;
            }
            lineIndex++;
        }


        return $"Part 1: {total}";
    }

    private static List<int> findNumbersAround(string[] lines, int lineIndex, int rowIndex)
    {
        var numbers = new List<int?>
        {
            findNumber(lines.StringAt(lineIndex - 1), rowIndex, true, new List<char>()), // Top
            findNumber(lines.StringAt(lineIndex + 1), rowIndex, true, new List<char>()), // Bottom
            findNumber(lines.StringAt(lineIndex), rowIndex - 1, true, new List<char>()), // Left
            findNumber(lines.StringAt(lineIndex), rowIndex + 1, true, new List<char>()), // Right
            findNumber(lines.StringAt(lineIndex - 1), rowIndex - 1, true, new List<char>()), // Top left
            findNumber(lines.StringAt(lineIndex - 1), rowIndex + 1, true, new List<char>()), // Top right
            findNumber(lines.StringAt(lineIndex + 1), rowIndex - 1, true, new List<char>()), // Bottom left
            findNumber(lines.StringAt(lineIndex + 1), rowIndex + 1, true, new List<char>()) // Bottom right
        };

        // I assume number do not repeat...
        return numbers
            .Where(n => n.HasValue)
            .Select(n => n.Value)
            .Distinct()
            .ToList();
    }

    private static int? findNumber(string line, int startIndex, bool findStart, List<char> previousChars)
    {
        var charAtIndex = line.CharAt(startIndex);
        if (charAtIndex.HasValue)
        {
            if (!previousChars.Any() && !charAtIndex.Value.IsDigit())
            {
                return null;
            }

            if (charAtIndex.Value.IsDigit())
            {
                var nextIndex = findStart ? startIndex - 1 : startIndex + 1;
                previousChars.Insert(findStart
                    ? 0
                    : previousChars.Count, charAtIndex.Value);
                return findNumber(line, nextIndex, findStart, previousChars);
            }
            // No more digit so we find one end of the number
            if (findStart)
            {
                // Now we need to find the end
                findStart = false;
                var nextIndex = startIndex + previousChars.Count + 1;
                return findNumber(line, nextIndex, findStart, previousChars);
            }
        }

        // We have reachd the end of the number
        return previousChars.Any()
            ? Int32.Parse(string.Concat(previousChars))
            : null;
    }
}

internal static class Extensions
{
    internal static string StringAt(this string[] lines, int index)
    {
        if (index >= lines.Count())
        {
            return null;
        }
        return lines.ElementAt(index);
    }

    internal static char? CharAt(this string line, int index)
    {
        if (string.IsNullOrEmpty(line) || index < 0 || index >= line.Length)
        {
            return null;
        }
        return line.ElementAt(index);
    }

    internal static bool IsSpecialChar(this char value)
    {
        return !char.IsLetterOrDigit(value) && value != '.';
    }
    internal static bool IsDigit(this char value)
    {
        return char.IsDigit(value);
    }
}
