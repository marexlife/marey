using Marey.Lex;

namespace Marey.Ast;

internal sealed class TranslationUnit
{
    private ClassNode _classNode = new();

    internal void Parse(TokenStream tokenStream)
    {
        try
        {
            _classNode.Parse(new ParsePacket(tokenStream));
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