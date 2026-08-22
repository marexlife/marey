namespace Marey;

internal abstract class ASTNode
{
    internal abstract void Parse(List<Token> tokens, out int jumpCount);
}