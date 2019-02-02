using System.Text;

namespace Flyweight
{
    public class Sentence
    {
        private readonly string planeText;
        private readonly WordToken token = new WordToken();

        public Sentence(string pt)
        {
            this.planeText = pt;
        }

        public WordToken this[int index]
        {
            get
            {
                token.index = index;
                return token;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var words = planeText.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (token.index == i && token.Capitalize)
                    words[i] = words[i].ToUpper();

                sb.Append(words[i]);
                sb.Append(" ");
            }
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public class WordToken
        {
            public bool Capitalize;
            public int index;
        }
    }
}
