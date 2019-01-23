using System;

namespace Factory
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public enum AvailableDrink
    {
        Coffee, Tea
    }

    class Program
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(AvailableDrink.Tea, 100);
            drink.Consume();

            Console.ReadKey();
        }
    }
}
