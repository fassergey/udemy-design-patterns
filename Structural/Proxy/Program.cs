using static System.Console;

namespace Proxy
{
    /* An interface for accessing a particular resource. */

        /*
         * A class that functions as an interface to a particular resource.
         * That resource may be remote, expensive to construct, or may
         * require logging or some other added functionality.
         */

    internal class Program
    {
        static void Main(string[] args)
        {
            // protection proxy
            var driver1 = new Driver(12);
            var proxy1 = new CarProxy(driver1);
            proxy1.Drive();

            var driver2 = new Driver(22);
            var proxy2 = new CarProxy(driver2);
            proxy2.Drive();
            WriteLine();

            // property proxy
            var c = new Creature();
            c.Agility = 10; // c.set_Agility(10) xxxxxxxxxxxxx
                            // c.Agility = new Property<int>(10)
            c.Agility = 10;
            WriteLine();

            // dynamic proxy
            //var ba = new BankAccount();
            var ba = Log<BankAccount>.As<IBankAccount>();
            ba.Deposit(100);
            ba.Withdraw(50);
            WriteLine(ba);
            WriteLine();
        }
    }
}
