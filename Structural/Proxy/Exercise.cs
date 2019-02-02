using NUnit.Framework;

namespace Proxy
{
    interface IPerson
    {
        string Drink();
        string Drive();
        string DrinkAndDrive();
    }

    public class Person : IPerson
    {
        public Person()
        {

        }

        public Person(int age)
        {
            Age = age;
        }

        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson : IPerson
    {
        private Person person;
        public int Age
        {
            get { return person.Age; }
            set { person.Age = value; }
        }

        public ResponsiblePerson(Person person)
        {
            this.person = person;
            Age = person.Age;
        }

        public string Drink()
        {
            return person.Age < 18 ? "too young" : person.Drink();
        }

        public string Drive()
        {
            return person.Age < 16 ? "too young" : person.Drive();
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }
    }

    [TestFixture]
    public class ExerciseTest
    {
        [Test]
        public void Test()
        {
            var p = new Person { Age = 10 };
            var rp = new ResponsiblePerson(p);

            Assert.That(rp.Drive(), Is.EqualTo("too young"));
            Assert.That(rp.Drink(), Is.EqualTo("too young"));
            Assert.That(rp.DrinkAndDrive(), Is.EqualTo("dead"));

            rp.Age = 20;

            Assert.That(rp.Drive(), Is.EqualTo("driving"));
            Assert.That(rp.Drink(), Is.EqualTo("drinking"));
            Assert.That(rp.DrinkAndDrive(), Is.EqualTo("dead"));
        }
    }
}
