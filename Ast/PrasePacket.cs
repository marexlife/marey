namespace Marey.Ast;

using Marey.Lex;

internal sealed class ParsePacket(List<Token> tokens)
{
    internal List<Token> Tokens { get; } = tokens;


    internal int Progress { get; set; }

    internal Token Token => Tokens[Progress];

    internal TokenKind Kind => Token.Kind;

    internal TokenPos Pos => Token.Pos;
}