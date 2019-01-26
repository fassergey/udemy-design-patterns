using System;

namespace Prototype
{
    /*
        not a good approach because you are unaware of which kind of copying (shadow or deep)
        is proceeded
    */

    public class Person1 : ICloneable
    {
        public string[] Names { get; set; }
        public Address1 Address { get; set; }

        public Person1(string[] names, Address1 address)
        {
            Names = names ?? throw new ArgumentNullException(paramName: nameof(names));
            Address = address ?? throw new ArgumentNullException(paramName: nameof(address));
        }
        
        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public object Clone()
        {
            return new Person1(Names, (Address1)Address.Clone());
        }
    }

    public class Address1 : ICloneable
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public Address1(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(paramName: nameof(streetName));
            HouseNumber = houseNumber;
        }
        
        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public object Clone()
        {
            return new Address1(StreetName, HouseNumber);
        }
    }
}
