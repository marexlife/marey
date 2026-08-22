using Marey.Lex;

namespace Marey.Ast;

internal sealed class TranslationUnit
{
    private ClassNode _classNode = new();

    internal void Parse(TokenStream tokenStream)
    {
        _classNode.Parse(new ParsePacket(tokenStream));
    }
}