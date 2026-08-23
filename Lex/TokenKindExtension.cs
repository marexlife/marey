namespace Marey.Lex;

internal static partial class TokenKindExtension
{
    extension(TokenKind self)
    {
        internal string FromEnumToString() => KeywordConfig.MapTokenKindToString(self);
    }
}