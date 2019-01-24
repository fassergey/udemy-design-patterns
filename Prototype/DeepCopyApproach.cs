using System;

namespace Prototype
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Person3 : IPrototype<Person3>
    {
        public string[] Names { get; set; }
        public Address3 Address { get; set; }

        public Person3(string[] names, Address3 address)
        {
            Names = names ?? throw new ArgumentNullException(paramName: nameof(names));
            Address = address ?? throw new ArgumentNullException(paramName: nameof(address));
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address3)}: {Address}";
        }

        public Person3 DeepCopy()
        {
            var namesCopy = new string[Names.Length];
            Array.Copy(Names, namesCopy, Names.Length);
            return new Person3(namesCopy, Address.DeepCopy());
        }
    }

    public class Address3 : IPrototype<Address3>
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public Address3(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(paramName: nameof(streetName));
            HouseNumber = houseNumber;
        }

        public Address3 DeepCopy()
        {
            return new Address3(StreetName, HouseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }
}
