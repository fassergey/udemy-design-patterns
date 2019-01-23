namespace Factory
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class PersonFactory
    {
        private static int Index = 0;

        public Person CreatePerson(string name)
        {
            var person = new Person(Index, name);
            Index++;
            return person;
        }
    }
}
