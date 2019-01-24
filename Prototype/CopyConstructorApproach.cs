using System;

namespace Prototype
{
    public class Person2
    {
        public string[] Names { get; set; }
        public Address2 Address { get; set; }

        public Person2(string[] names, Address2 address)
        {
            Names = names ?? throw new ArgumentNullException(paramName: nameof(names));
            Address = address ?? throw new ArgumentNullException(paramName: nameof(address));
        }

        // CopyConstructor approach
        public Person2(Person2 other)
        {
            Names = other.Names;
            Address = new Address2(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class Address2
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public Address2(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(paramName: nameof(streetName));
            HouseNumber = houseNumber;
        }

        // CopyConstructor approach
        public Address2(Address2 other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }
}
