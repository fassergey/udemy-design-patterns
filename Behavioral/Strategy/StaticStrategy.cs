using System;
using System.Collections.Generic;
using static System.Console;
using System.Text;

namespace Strategy
{
    static class StaticStrategy
    {
        public enum OutputFormat
        {
            Markdown,
            Html
        }

        // <ul><li></li></ul>
        public interface IListStrategy
        {
            void Start(StringBuilder sb);
            void End(StringBuilder sb);
            void AddlistItem(StringBuilder sb, string item);
        }

        public class HtmlListStrategy : IListStrategy
        {
            public void Start(StringBuilder sb)
            {
                sb.AppendLine("<ul>");
            }

            public void End(StringBuilder sb)
            {
                sb.AppendLine("</ul>");
            }

            public void AddlistItem(StringBuilder sb, string item)
            {
                sb.AppendLine($"<li>{item}</li>");
            }
        }

        public class MarkdownListStrategy : IListStrategy
        {
            public void Start(StringBuilder sb)
            {
            }

            public void End(StringBuilder sb)
            {
            }

            public void AddlistItem(StringBuilder sb, string item)
            {
                sb.AppendLine($" * {item}");
            }
        }

        public class TextProcessor<LS> where LS: IListStrategy, new()
        {
            private StringBuilder sb = new StringBuilder();
            private IListStrategy listStrategy = new LS();
            
            public void AppendList(IEnumerable<string> items)
            {
                listStrategy.Start(sb);
                foreach (var item in items)
                {
                    listStrategy.AddlistItem(sb, item);
                }
                listStrategy.End(sb);
            }

            public StringBuilder Clear()
            {
                return sb.Clear();
            }

            public override string ToString()
            {
                return sb.ToString();
            }
        }

        public static void Run()
        {
            // cb.Register<MarkDownListStrategy>().As<IListStrategy>();

            var tp = new TextProcessor<MarkdownListStrategy>();
            tp.AppendList(new[] { "foo", "bar", "baz" });
            WriteLine(tp);

            tp.Clear();
            // tp = new TextProcessor<HtmlListStrategy>();  doesn't work
            var tp2 = new TextProcessor<HtmlListStrategy>();
            tp2.AppendList(new[] { "foo", "bar", "baz" });
            WriteLine(tp2);
        }
    }
}
