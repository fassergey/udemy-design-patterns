using static System.Console;

/* Sequence of handlers processing an event one after another */

/*
 * A chain of components who all get a chance to process a command or a query,
 * optionally having default processing implementation and an ability to terminate
 * the processing chain
 */

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            // command query separation
            var goblin = new CommandQuerySeparation.Creature("Goblin", 2, 2);
            WriteLine(goblin);

            var root = new CommandQuerySeparation.CreatureModifier(goblin);

            root.Add(new CommandQuerySeparation.NoBonusesModifier(goblin));

            WriteLine("Let's double the goblin's attack");
            root.Add(new CommandQuerySeparation.DoubleAttackModifier(goblin));

            WriteLine("Let's increase the goblin's defense");
            root.Add(new CommandQuerySeparation.IncreasedDefenseModifier(goblin));

            root.Handle();
            WriteLine(goblin);
            WriteLine();

            // broker chain
            var game = new BrokerChain.Game();
            var strongGoblin = new BrokerChain.Creature(game, "Strong Goblin", 3, 3);
            using (new BrokerChain.DoubleAttackModifier(game, strongGoblin))
            {
                WriteLine(strongGoblin);
                using (new BrokerChain.IncreaseDefenseModifier(game, strongGoblin))
                {
                    WriteLine(strongGoblin);
                }
                WriteLine(strongGoblin);
            }

            WriteLine(strongGoblin);
            WriteLine();

            // exercise

        }
    }
}
