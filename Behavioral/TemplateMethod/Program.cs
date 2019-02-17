using static System.Console;

namespace TemplateMethod
{
    /* A high-level blueprint for an algorithm to be completed by inheritors. */

    /*
     * Allows us to define the 'skeleton' of the algorithm, with concrete
     * implementations defined in subclasses.
     */

    public abstract class Game
    {
        public void Run()
        {
            Start();

            while (!HaveWinner)
            {
                TakeTurn();
            }

            WriteLine($"Player {WinningPlayer} wins.");
        }

        protected int currentPlayer;
        protected readonly int numberOfPlayers;

        protected Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }

        protected abstract void Start();
        protected abstract void TakeTurn();
        protected abstract bool HaveWinner { get; }
        protected abstract int WinningPlayer { get; }
    }

    public class Chess : Game
    {
        public Chess(int numberOfPlayers) : base(2)
        {
        }

        protected override void Start()
        {
            WriteLine($"Starting a game of chess with {numberOfPlayers} players.");
        }

        protected override void TakeTurn()
        {
            WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        }

        protected override bool HaveWinner => turn == maxTurns;
        protected override int WinningPlayer => currentPlayer;

        private int turn = 1;
        private int maxTurns = 10;
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
