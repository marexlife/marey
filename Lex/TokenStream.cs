using System.Collections;

namespace Marey.Lex;

internal sealed class TokenStream : IEnumerable<Token>
{
    internal required List<Token> Tokens { get; set; }

    public IEnumerator<Token> GetEnumerator()
    {
        return Tokens.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

