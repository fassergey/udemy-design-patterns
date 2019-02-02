using System;
using static System.Console;
using System.Text;

namespace Proxy
{
    public interface ICar
    {
        void Drive();
    }

    internal class Car : ICar
    {
        public void Drive()
        {
            WriteLine("The car could be driven. Enjoy!");
        }
    }

    internal class Driver
    {
        public int Age { get; set; }

        public Driver(int age)
        {
            Age = age;
        }
    }

    internal class CarProxy : ICar
    {
        private readonly Driver driver;
        private ICar car = new Car();

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void Drive()
        {
            if (driver.Age >= 16)
                car.Drive();
            else
            {
                WriteLine("Too young");
            }
        }
    }
}
