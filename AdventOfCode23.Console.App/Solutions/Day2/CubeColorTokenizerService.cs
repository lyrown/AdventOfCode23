namespace AdventOfCode23.Console.App.Solutions.Day2;

using AdventOfCode23.Console.App.Services;
using System.Text.RegularExpressions;

internal sealed class CubeColorTokenizerService : TokenizerService<CubeColorToken, CubeColorTokenMatch>
{
    public CubeColorTokenizerService(string regexPattern, CubeColorToken token) : base(regexPattern, token) { }
}

internal sealed class CubeColorTokenMatch : ITokenizerMatchResponse<CubeColorToken>
{
    public CubeColorToken Token { get; set; }

    public string Value { get; set; }

    public int NumberOfCubes => Int32.Parse(Regex.Match(Value, @"\d+").Value);
}
