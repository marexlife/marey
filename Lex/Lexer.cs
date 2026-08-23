namespace Marey.Lex;

public class Lexer(string sourceCode)
{
    private TokenStream tokens = [];
    private string _lastWord = string.Empty;
    private SourcePos sourcePos = new();
    private bool _isContentToFlushAvailable = false;

    internal TokenStream Run()
    {
        foreach (var sourceCodeChar in sourceCode)
        {
            switch (sourceCodeChar)
            {
                case ' ':
                    Flush();
                    break;
                case ';' or ':':
                    FlushAndAdd(sourceCodeChar);
                    break;
                case '\n':
                    Flush();
                    ++sourcePos.Line;
                    continue;
                default:
                    _lastWord += sourceCodeChar;
                    _isContentToFlushAvailable = true;
                    break;
            }

            ++sourcePos.Column;
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
        if (!_isContentToFlushAvailable) return;

        tokens.Add(new Token(sourcePos, _lastWord));

        _lastWord = string.Empty;
        _isContentToFlushAvailable = false;
    }
}