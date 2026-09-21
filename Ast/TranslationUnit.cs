using Marey.Lex;

namespace Marey.Ast;

internal sealed class TranslationUnit
{
    private ClassNode _classNode = new();

    internal void Parse(List<Token> tokens)
    {
        try
        {
            TokenStream stream = new(tokens);

            _classNode.Parse(stream);
        }
        catch (InvalidTokenException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (NotYetSupportedException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Internal Error: {exception}");
        }
    }

    internal void Emit(EmitPack pack)
    {
        _classNode.Emit(pack);
    }
}