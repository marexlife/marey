namespace Marey.Lex;

internal static class TokenKindExtension
{
    extension(TokenKind self)
    {
        internal static TokenBiding[] GetTokenBindings() =>
        [
            new("}", TokenKind.CloseBrace),
            new("{", TokenKind.OpenBrace),
        ];

        internal static TokenKind? FromString(string name)
        {
            foreach (TokenBiding binding in GetTokenBindings())
            {
                if (binding.Name == name)
                {
                    return binding.TokenKind;
                }
            }

            return null;
        }

        internal string? EnumAsString()
        {
            foreach (TokenBiding binding in GetTokenBindings())
            {
                if (binding.TokenKind == self)
                {
                    return binding.Name;
                }
            }

            return null;
        }
    }
}