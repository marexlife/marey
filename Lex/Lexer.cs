namespace Marey.Lex;

public class Lexer(string sourceCode)
{
    private TokenStream tokens = [];
    private string _lastWord = string.Empty;
    private SourcePos sourcePos = new();

    internal TokenStream Run()
    {
        foreach (var sourceCodeChar in sourceCode)
        {
            switch (sourceCodeChar)
            {
                case ' ': Flush(); break;
                case ';' or ':':
                    FlushAndAdd(sourceCodeChar);
                    break;
                case '\n': ++sourcePos.Line; break;
                default:
                    _lastWord += sourceCodeChar;
                    ++sourcePos.Column;
                    break;
            }
        }

        return tokens;
    }

    private void FlushAndAdd(char toAdd)
    {
        Flush();

        string toAddString = string.Empty;
        toAddString += toAdd;
        tokens.Add(new Token(sourcePos, toAddString));
    }

    private void Flush()
    {
        tokens.Add(new Token(sourcePos, _lastWord));

        _lastWord = string.Empty;
    }
}