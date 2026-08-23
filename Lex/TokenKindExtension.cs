using System.Diagnostics;

namespace Marey.Lex;

internal static class TokenKindExtension
{
    extension(TokenKind self)
    {
        internal string FromEnumToString() => KeywordConfig.MapTokenKindToString(self);
    }
}