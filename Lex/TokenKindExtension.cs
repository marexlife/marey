namespace Marey.Lex;

internal static class TokenKindExtension
{
    extension(TokenKind self)
    {
        internal string EnumAsString() => self switch
        {
            TokenKind.Fun => ""
        };
    }
}