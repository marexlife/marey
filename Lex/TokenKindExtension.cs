using System.Diagnostics;

namespace Marey.Lex;

internal static class TokenKindExtension
{
    extension(TokenKind self)
    {
        internal string FromEnumToString()
        {
            return self switch
            {
                TokenKind.Ident => "identifier",
                TokenKind.Fun => "fun",
                TokenKind.Var => "var",
                TokenKind.StatementEnd => ";",
                TokenKind.OpenBrace => "{",
                TokenKind.CloseBrace => "}",
                TokenKind.OpenBracket => "(",
                TokenKind.CloseBracket => ")",
                TokenKind.Assignment => "=",
                TokenKind.Colon => ":",
                TokenKind.Float => "float",
                TokenKind.Bool => "bool",
                TokenKind.Int => "int",
                _ => throw new UnreachableException(),
            };
        }
    }
}