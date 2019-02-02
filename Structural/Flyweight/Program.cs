using System.Collections.Generic;
using System.Linq;
using static System.Console;

/* Space optimization */

/*
 A space optimization technique that lets us use less memory
 by storing externally the data associated with similar objects.
 */

namespace Flyweight
{
    public class User
    {
        string fullName;

        public User(string fullName)
        {
            this.fullName = fullName;
        }
    }

    public class User2
    {
        static List<string> strings = new List<string>();
        private int[] names;

        public User2(string fullName)
        {
            names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        int getOrAdd(string s)
        {
            int idx = strings.IndexOf(s);
            if (idx != -1) return idx;
            else
            {
                strings.Add(s);
                return strings.Count - 1;
            }
        }

        public string FullName => string.Join(' ', names.Select(i => strings[i]));
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            var ft = new FormattedText("This is a brave new world");
            ft.Capitalize(10, 15);
            WriteLine(ft);

            var bft = new BetterFormattedText("This is a brave new world");
            bft.GetRange(10, 15).Capitalize = true;
            WriteLine(bft);

            var sentence = new Sentence("Hello world");
            sentence[1].Capitalize = true;
            WriteLine(sentence);
        }
    }
}
