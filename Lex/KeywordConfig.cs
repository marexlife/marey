namespace Marey.Lex;

internal static class KeywordConfig
{
    private const string IdentString = "identifier";

    internal readonly static KeywordBinding[] KeywordBindings = [
        new("(", TokenKind.OpenBracket),
        new(")", TokenKind.CloseBracket),
        new("{", TokenKind.OpenBrace),
        new("}", TokenKind.CloseBrace),
        new("=", TokenKind.Assignment),
        new("def", TokenKind.Fun),
        new("var", TokenKind.Var),
        new(";", TokenKind.StatementEnd),
        new(":", TokenKind.Colon),
        new("float", TokenKind.Float),
        new("bool", TokenKind.Bool),
        new("int", TokenKind.Int),
        new("extends", TokenKind.Extends)
    ];

    internal static TokenKind MapStringToTokenKind(string input)
    {
        foreach (var binding in KeywordBindings)
        {
            if (binding.Word == input)
            {
                return binding.TokenKind;
            }
        }

        return TokenKind.Ident;
    }

    internal static string MapTokenKindToString(TokenKind input)
    {
        foreach (var binding in KeywordBindings)
        {
            if (binding.TokenKind == input)
            {
                return binding.Word;
            }
        }

        return IdentString;
    }
}