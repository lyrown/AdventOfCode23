namespace AdventOfCode23.Console.App.Solutions.Day3;
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