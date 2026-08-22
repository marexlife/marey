using Marey.Lex;
using Marey.Ast;

namespace Marey;

internal static class Program
{
    private static void Main()
    {
        var tokens = new Lexer().Run();

        new TranslationUnit().Parse(new ParsePacket(tokens));
    }
}