using Marey.Lex;
using Marey.Ast.Decls;

namespace Marey.Ast;

internal static partial class TokenKindExtension
{
    extension(TokenKind self)
    {
        internal TypeKind ConvertToType(ParsePacket packet) => self switch
        {
            TokenKind.Bool => TypeKind.Bool,
            TokenKind.Int => TypeKind.Int,
            TokenKind.Float => TypeKind.Float,
            _ => throw new InvalidTokenException(packet.Pos, "Invalid Type"),
        };
    }
}