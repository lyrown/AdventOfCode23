namespace AdventOfCode23.Console.App.Services;

using System.Text.RegularExpressions;

public class TokenizerService<TTokenType, TTokenMatch> 
    where TTokenType : Enum
    where TTokenMatch : ITokenizerMatchResponse<TTokenType>
{
    public readonly string RegexPattern;

    public readonly TTokenType TokenType;

    private readonly Regex _regex;

    public TokenizerService(string regexPattern, TTokenType tokenType)
    {
        RegexPattern = regexPattern;
        TokenType = tokenType;

        _regex = new Regex(regexPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
    }

    public IEnumerable<TTokenMatch> FindMatches(string input)
    {
        var matches = _regex.Matches(input);
        for (int i = 0; i < matches.Count; i++)
        {
            var match = Activator.CreateInstance<TTokenMatch>();
            match.Value = matches[i].Value;
            match.Token = TokenType;

            yield return match;
        }
    }
}

public interface ITokenizerMatchResponse<TTokenType> 
        where TTokenType : Enum
{
    TTokenType Token { get; set; }

    string Value { get; set; }
}

#region Extensions

public static class TokenizerServiceExtensions
{
    public static List<TTokenMatch> FindMatches<TTokenizerService, TTokenType, TTokenMatch>(this IList<TTokenizerService> tokenizers, string input)
        where TTokenizerService : TokenizerService<TTokenType, TTokenMatch>
        where TTokenType : Enum
        where TTokenMatch : ITokenizerMatchResponse<TTokenType>
    {
        var tokenMatches = new List<TTokenMatch>();

        foreach (var tokenizer in tokenizers)
            tokenMatches.AddRange(tokenizer.FindMatches(input).ToList());

        return tokenMatches;
    }
}

#endregion