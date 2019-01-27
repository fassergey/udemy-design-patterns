using System;
using static System.Console;

/* When it is easier to copy an existing object to fully initialize a new copy */

    /*
     Prototype - a partially or fully initialized object that you
     copy (clone) and make use of.
     */

namespace Prototype
{
    class Program
    {
        public class Person
        {
            public string[] Names { get; set; }
            public Address Address { get; set; }

            public Person(string[] names, Address address)
            {
                Names = names ?? throw new ArgumentNullException(paramName: nameof(names));
                Address = address ?? throw new ArgumentNullException(paramName: nameof(address));
            }

            public override string ToString()
            {
                return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
            }
        }

        public class Address
        {
            public string StreetName { get; set; }
            public int HouseNumber { get; set; }

            public Address(string streetName, int houseNumber)
            {
                StreetName = streetName ?? throw new ArgumentNullException(paramName: nameof(streetName));
                HouseNumber = houseNumber;
            }

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
            }
        }

        static void Main(string[] args)
        {
            WriteLine("Straight forward copying:");
            var john = new Person(new[] { "John", "Smith" },
                new Address("LondonRoad", 123));

            var jane = john;
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 321;

            WriteLine(john);
            WriteLine(jane);

            #region ICloneable
            WriteLine();
            WriteLine("ICloneable approach:");
            var john1 = new Person1(new[] { "John", "Smith" },
                new Address1("LondonRoad", 123));

            var jane1 = (Person1)john1.Clone();
            jane1.Names[0] = "Jane";
            jane1.Address.HouseNumber = 321;

            WriteLine(john1);
            WriteLine(jane1);
            #endregion ICloneable

            #region Copy constructor
            WriteLine();
            WriteLine("Copy constructor approach:");
            var john2 = new Person2(new []{ "John", "Smith" },
                new Address2("LondonRoad", 123));

            var jane2 = new Person2(john2)
            {
                Names = new[] {"Jane"},
                Address = {HouseNumber = 321}
            };

            WriteLine(john2);
            WriteLine(jane2);
            #endregion Copy constructor

            #region Deep copy
            WriteLine();
            WriteLine("Deep copy approach:");
            var john3 = new Person3(new[] { "John", "Smith" },
                new Address3("LondonRoad", 123));

            var jane3 = john3.DeepCopy();
            jane3.Names[0] = "Jane";
            jane3.Address.HouseNumber = 321;

            WriteLine(john3);
            WriteLine(jane3);
            #endregion Deep copy

            #region Serialization
            WriteLine();
            WriteLine("Serialization approach:");
            var john4 = new Person4(new[] { "John", "Smith" },
                new Address4("LondonRoad", 123));

            var jane4 = john4.DeepCopy();
            jane4.Names[0] = "Jane";
            jane4.Address.HouseNumber = 321;

            WriteLine(john4);
            WriteLine(jane4);
            #endregion Serialization

            ReadKey();
        }
    }
}
