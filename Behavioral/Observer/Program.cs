using System;
using System.ComponentModel;
using static System.Console;

namespace Observer
{
    /* Built-in right into C#/.NET, right? */

    /*
     * An observer is an object that wishes to be informed about events happening in the system.
     * The entity generating the events is an observable.
     */



    class Program
    {
        static void Main(string[] args)
        {
            // observer via event
            var person = new Person();
            person.FallsIll += CallDoctor;
            person.CatchACold();

            person.FallsIll -= CallDoctor;
            WriteLine();


            // weak event pattern
            var button = new Button();
            var window = new Window(button);
            var windowRef = new WeakReference(window);
            button.Fire();

            WriteLine("Setting window to null");
            window = null;

            // window isn't finalized - memory leak
            FireGC();
            WriteLine($"Is the window alive after GC?  {windowRef.IsAlive}");
            WriteLine();


            // observable properties and sequences
            var market1 = new Market1();
            market1.PropertyChanged += (sender, eventArgs) =>
            {
                if (eventArgs.PropertyName == "Volatility")
                {

                }
            };

            var market = new Market();
            market.Prices.ListChanged += (sender, eventArgs) =>
            {
                if (eventArgs.ListChangedType == ListChangedType.ItemAdded)
                {
                    float price = ((BindingList<float>)sender)[eventArgs.NewIndex];
                    WriteLine($"Binding list got a price of {price}");
                }
            };
            market.AddPrice(123);
        }

        private static void CallDoctor(object sender, FallIllEventArgs e)
        {
            WriteLine($"A doctor has been called to {e.Address}");
        }

        private static void FireGC()
        {
            WriteLine("Starting GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            WriteLine("GC is done!");
        }
    }
}
