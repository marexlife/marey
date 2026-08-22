namespace Marey.Ast;

using Marey.Lex;

internal sealed class ParsePacket(List<Token> tokens)
{
    internal List<Token> Tokens { get; } = tokens;


    internal int Progress { get; private set; }


    internal Token Token
    {
        get
        {
            ++Progress;

            return Tokens[Progress];
        }
    }

    internal TokenKind Kind => Token.TokenKind;
}