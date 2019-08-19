using System;

/* When construction gets a little bit too complicated */

    /*
     Builder - when piecewise object construction is complicated, 
     provide an API for doing it succinctly.
     */

namespace Creational.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // inheritance builder
            var me = PersonA.New
                .Called("Sergii")
                .WorksAsA("Developer")
                .Build();
            Console.WriteLine(me);
            Console.WriteLine();

            // facets builder
            var pb = new PersonBBuilder();
            PersonB person = pb
              .Lives
                .At("123 London Road")
                .In("London")
                .WithPostcode("SW12BC")
              .Works
                .At("Fabrikam")
                .AsA("Engineer")
                .Earning(123000);
            Console.WriteLine(person);
            Console.WriteLine();

            // exercise builder
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
