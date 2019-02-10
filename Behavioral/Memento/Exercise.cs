using System.Collections.Generic;

namespace Memento
{
    public class Token
    {
        public int Value = 0;

        public Token(int value)
        {
            this.Value = value;
        }
    }

    public class MyMemento
    {
        public Token Shapshort { get; set; }

        public MyMemento(Token shapshort)
        {
            Shapshort = shapshort;
        }
    }

    public class TokenMachine
    {
        public List<Token> Tokens = new List<Token>();

        public MyMemento AddToken(int value)
        {
            var token = new Token(value);
            Tokens.Add(token);
            return new MyMemento(token);
        }

        public MyMemento AddToken(Token token)
        {
            var t = new Token(token.Value);
            Tokens.Add(t);
            return new MyMemento(t);
        }

        public void Revert(MyMemento m)
        {
            var idx = Tokens.FindLastIndex(x => x == m.Shapshort);
            Tokens.RemoveRange(idx + 1, Tokens.Count - idx - 1);
        }
    }
}
