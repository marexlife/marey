using Marey.Lex;
using Marey.Ast;

namespace Marey;

internal static class Program
{
    private static void Main()
    {
        var sourceCode = "";

        var tokenStream = new Lexer(sourceCode).Run();

        new TranslationUnit().Parse(tokenStream);
    }
}