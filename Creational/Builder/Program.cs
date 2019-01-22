using System;

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

            Console.ReadKey();
        }
    }
}
