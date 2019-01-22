namespace Creational.Builder
{
    public class PersonA
    {
        public string Name;

        public string Position;

        public class InheritanceBuilder : PersonJobBuilder<InheritanceBuilder> { /* degenerate */ }

        public static InheritanceBuilder New => new InheritanceBuilder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonABuilder
    {
        protected PersonA person = new PersonA();

        public PersonA Build()
        {
            return person;
        }

        public static implicit operator PersonA(PersonABuilder pb)
        {
            return pb.person;
        }
    }

    public class PersonInfoBuilder<SELF> : PersonABuilder
      where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
      where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }
}