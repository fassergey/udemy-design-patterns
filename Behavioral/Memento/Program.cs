using static System.Console;

namespace Memento
{
    /* Keep a memento of an object state to return to that state. */

    /*
     * A tiken/handle representing the system state. Lets us roll back to the
     * state when the token was generated. May or may not directly expose state information.
     */

    class Program
    {
        static void Main(string[] args)
        {
            // basic memento
            var ba = new BankAccount(100);
            var m1 = ba.Deposit(50);
            var m2 = ba.Deposit(25);
            WriteLine(ba);

            ba.Restore(m1);
            WriteLine(ba);

            ba.Restore(m2);
            WriteLine(ba);

            WriteLine();

            // undo-redo
            var baExt = new BankAccountExtended(100);
            baExt.Deposit(50);
            baExt.Deposit(25);
            WriteLine(baExt);

            baExt.Undo();
            WriteLine($"Undo 1: {baExt}");
            baExt.Undo();
            WriteLine($"Undo 2: {baExt}");
            baExt.Redo();
            WriteLine($"Redo: {baExt}");
        }
    }
}
