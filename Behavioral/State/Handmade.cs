using static System.Console;
using System.Collections.Generic;

namespace State
{
    public static class Handmade
    {
        public enum State
        {
            OffHook, Connecting,
            Connected,
            OnHold
        }

        public enum Trigger
        {
            CallDialed,
            HungUp,
            CallConnected,
            PlacedOnHold,
            TakenOffHold,
            LeftMessage
        }

        public static Dictionary<State, List<(Trigger, State)>> Rules
            = new Dictionary<State, List<(Trigger, State)>>
            {
                [State.OffHook] = new List<(Trigger, State)>
                {
                    (Trigger.CallDialed, State.Connecting),
                },

                [State.Connecting] = new List<(Trigger, State)>
                {
                    (Trigger.HungUp, State.OffHook),
                    (Trigger.CallConnected, State.Connected),
                },

                [State.Connected] = new List<(Trigger, State)>
                {
                    (Trigger.LeftMessage, State.OffHook),
                    (Trigger.HungUp, State.OffHook),
                    (Trigger.PlacedOnHold, State.OnHold),
                },

                [State.OnHold] = new List<(Trigger, State)>
                {
                    (Trigger.TakenOffHold, State.Connected),
                    (Trigger.HungUp, State.OffHook),
                },
            };

        public static void Run()
        {
            var state = State.OffHook;
            while (true)
            {
                WriteLine($"The phone is currently {state}");
                WriteLine($"Select a trigger:");

                for (int i = 0; i < Rules[state].Count; i++)
                {
                    var (t, _) = Rules[state][i];
                    WriteLine($"{i}. {t}");
                }

                int input = int.Parse(ReadLine());

                var (_, s) = Rules[state][input];
                state = s;
            }
        }
    }
}
