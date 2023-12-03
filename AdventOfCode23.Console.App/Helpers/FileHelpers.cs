namespace AdventOfCode23.Console.App.Helpers;

public static class FileHelpers
{
    public static string InputPath(string day,string fileNameWithExtension)
    {
        return Path.Combine(
            Environment.CurrentDirectory, 
            nameof(Solutions), 
            day, 
            fileNameWithExtension);
    }
}
