﻿using System;

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

            // exercise builder
            var cb = new CodeClass.CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(((CodeClass)cb).ToString());

            Console.ReadKey();
        }
    }
}
