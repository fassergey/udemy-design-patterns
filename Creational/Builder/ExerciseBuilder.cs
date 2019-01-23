using System.Collections.Generic;
using System.Text;

namespace Creational.Builder
{
    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"public {Type} {Name}";
        }
    }

    public class CodeClass
    {
        public string Name { get; set; }
        public IList<Field> Fields { get; set; }

        public CodeClass()
        {
            Fields = new List<Field>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {Name}").AppendLine("{");
            foreach (var field in Fields)
            {
                sb.AppendLine($"  {field};");
            }
            sb.AppendLine("}");

            return sb.ToString();
        }
    }

    public class CodeBuilder
    {
        private CodeClass Class { get; set; }

        public CodeBuilder(string className)
        {
            Class = new CodeClass { Name = className };
        }

        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            Class.Fields.Add(new Field
            {
                Name = fieldName,
                Type = fieldType
            });

            return this;
        }

        public override string ToString()
        {
            return Class.ToString();
        }
    }
}