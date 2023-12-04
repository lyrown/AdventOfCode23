namespace AdventOfCode23.Console.App.Solutions.Day2;

using AdventOfCode23.Console.App.Services;
using Helpers;

public static class Part2
{
    private const char gameIdSeparator = ':';
    private const char gameValueSeparator = ';';
    private const string numberRegexPattern = "\\d{1,}\\s";

    public static string GetSolution()
    {
        var inputFilePath = FileHelpers.InputPath(nameof(Day2), "Input.txt");

        var wantedCubeColorTokens = new List<CubeColorTokenizerService>
        {
            new CubeColorTokenizerService($"{numberRegexPattern}red", CubeColorToken.Red),
            new CubeColorTokenizerService($"{numberRegexPattern}green", CubeColorToken.Green),
            new CubeColorTokenizerService($"{numberRegexPattern}blue", CubeColorToken.Blue)
        };

        var gamePowers = new List<int>();
        var gameSets = File.ReadLines(inputFilePath);
        foreach (var gameSet in gameSets)
        {
            var separatorIndex = gameSet.IndexOf(gameIdSeparator);
            var handpickSets = gameSet.Substring(separatorIndex).Split(gameValueSeparator);

            var handpickCubeColors = handpickSets
                .SelectMany(s => wantedCubeColorTokens.FindMatches<CubeColorTokenizerService, CubeColorToken, CubeColorTokenMatch>(s));

            var maxAmountRedCubes = handpickCubeColors.Where(hp => hp.Token == CubeColorToken.Red).Max(hp => hp.NumberOfCubes);
            var maxAmountGreenCubes = handpickCubeColors.Where(hp => hp.Token == CubeColorToken.Green).Max(hp => hp.NumberOfCubes);
            var maxAmountBlueCubes = handpickCubeColors.Where(hp => hp.Token == CubeColorToken.Blue).Max(hp => hp.NumberOfCubes);

            var power = maxAmountRedCubes * maxAmountGreenCubes * maxAmountBlueCubes;
            gamePowers.Add(power);
        }

        return $"Part 2: {gamePowers.Sum()}";
    }
}
