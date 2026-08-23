using Marey.Lex;
using Marey.Ast;

namespace Marey;

internal static class Program
{
    private static void Main()
    {
        var sourceCode = """
        extends Object;

        var is_alive: bool = true;
        
        def update() {
            var x: bool = true;
        }
        """;

        var tokenStream = new Lexer(sourceCode).Run();

        new TranslationUnit().Parse(tokenStream);
    }
}