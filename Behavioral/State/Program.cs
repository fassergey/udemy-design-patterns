using System;
using static System.Console;

namespace State
{
    /* Fun with Finite State Machines */

    /*
     * A pattern in which the object's behavior is determined by its state.
     * An object transitions from one state to another (something needs to
     * trigger a transition).
     * A formalized construct which manages state and transitions is called
     * a state machine.
     */

    
    
    class Program
    {
        static void Main(string[] args)
        {
            //Handmade.Run();

            //SwitchBased.Run();

            Stateless.Run();
        }
    }
}
