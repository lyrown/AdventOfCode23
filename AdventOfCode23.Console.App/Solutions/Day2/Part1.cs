namespace AdventOfCode23.Console.App.Solutions.Day2;

using Helpers;
using Services;

public static class Part1
{
    private const char gameIdSeparator = ':';
    private const char gameValueSeparator = ';';
    private const string numberRegexPattern = "\\d{1,}\\s";

    private const int maxNumberOfRedCubes = 12;
    private const int maxNumberOfGreenCubes = 13;
    private const int maxNumberOfBlueCubes = 14;

    public static string GetSolution()
    {
        var inputFilePath = FileHelpers.InputPath(nameof(Day2), "Input.txt");

        var wantedCubeColorTokens = new List<CubeColorTokenizerService>
        {
            new CubeColorTokenizerService($"{numberRegexPattern}red", CubeColorToken.Red),
            new CubeColorTokenizerService($"{numberRegexPattern}green", CubeColorToken.Green),
            new CubeColorTokenizerService($"{numberRegexPattern}blue", CubeColorToken.Blue)
        };

        var validHandGameSetIds = new List<int>();
        var gameSets = File.ReadLines(inputFilePath);
        var index = 0;
        foreach (var gameSet in gameSets)
        {
            var separatorIndex = gameSet.IndexOf(gameIdSeparator);
            var handpickSets = gameSet.Substring(separatorIndex).Split(gameValueSeparator);
            var isHandpickOutOfLimits = false;

            // Set the elf took in its hands per round
            foreach (var handpickSet in handpickSets)
            {
                // Get the token representing the handpick of the elf
                var handpickCubeColors = wantedCubeColorTokens
                    .FindMatches<CubeColorTokenizerService, CubeColorToken, CubeColorTokenMatch>(handpickSet);

                var redPicks = handpickCubeColors.Find(hp => hp.Token == CubeColorToken.Red)?.NumberOfCubes ?? 0;
                var greenPicks = handpickCubeColors.Find(hp => hp.Token == CubeColorToken.Green)?.NumberOfCubes ?? 0;
                var bluePicks = handpickCubeColors.Find(hp => hp.Token == CubeColorToken.Blue)?.NumberOfCubes ?? 0;

                // Check if handpicks are within the allowed limits
                if (redPicks > maxNumberOfRedCubes
                    || greenPicks > maxNumberOfGreenCubes
                    || bluePicks > maxNumberOfBlueCubes)
                {
                    isHandpickOutOfLimits = true;
                    break;
                }
            }

            if (!isHandpickOutOfLimits)
            {
                validHandGameSetIds.Add(index + 1);
            }

            index += 1;
        }

        return $"Part 1: {validHandGameSetIds.Sum()}";
    }
}
