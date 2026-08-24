using Marey.Lex;
using Marey.Ast;

namespace Marey;

internal static class Program
{
    private static void Main()
    {
        var sourceCode = """
        extends Object;

        var y: bool = true;

        def update() {
            var x: bool = true;
        }
        """;

        var tokenStream = new Lexer(sourceCode).Run();

        new TranslationUnit().Parse(tokenStream);
    }
}