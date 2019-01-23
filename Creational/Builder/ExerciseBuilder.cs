using System.Collections.Generic;
using System.Text;

namespace Creational.Builder
{
    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class CodeClass
    {
        public static string Name { get; set; }
        public IList<Field> Fields = new List<Field>();

        public class CodeBuilder : ConcreteCodeBuilder<CodeBuilder>
        {
            public CodeBuilder(string className)
            {
                CodeClass.Name = className;
            }
        }

        public override string ToString()
        {
            const int spaces = 4;
            var tab = new string(' ', spaces);
            var sb = new StringBuilder();
            sb.AppendLine($"Name of class : {Name}");
            for (var i = 0; i < Fields.Count; i++)
            {
                sb.AppendLine($"{tab}Field-{i + 1}: name - {Fields[i].Name}, type - {Fields[i].Type}");
            }

            return sb.ToString();
        }
    }

    public abstract class AbstractCodeBuilder
    {
        protected CodeClass Class = new CodeClass();

        public static implicit operator CodeClass(AbstractCodeBuilder cb)
        {
            return cb.Class;
        }
    }

    public class ConcreteCodeBuilder<T> : AbstractCodeBuilder where T : ConcreteCodeBuilder<T>
    {
        public T AddField(string fieldName, string fieldType)
        {
            Class.Fields.Add(new Field
            {
                Name = fieldName,
                Type = fieldType
            });

            return (T) this;
        }
    }

    //public class Person
    //{
    //    public string Name;
    //    public int Age;

        //    public class Builder : AgeCodeBuilder<Builder> { }

        //    public override string ToString()
        //    {
        //        return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        //    }
        //}

        //public abstract class CodeBuilder
        //{
        //    protected Person person = new Person();

        //    public Person Build()
        //    {
        //        return person;
        //    }

        //    public static implicit operator Person(CodeBuilder pb)
        //    {
        //        return pb.person;
        //    }
        //}

        //public class NameCodeBuilder<T> : CodeBuilder where T : NameCodeBuilder<T>
        //{
        //    public NameCodeBuilder<T> AddField(string name)
        //    {
        //        this.person.Name = name;
        //        return (T)this;
        //    }
        //}

        //public class AgeCodeBuilder<T> : NameCodeBuilder<AgeCodeBuilder<T>> where T : AgeCodeBuilder<T>
        //{
        //    public AgeCodeBuilder<T> AddField(int age)
        //    {
        //        this.person.Age = age;
        //        return (T)this;
        //    }
        //}
}