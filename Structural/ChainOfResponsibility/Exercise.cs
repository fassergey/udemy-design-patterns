using System.Collections.Generic;
using System.Linq;

namespace ChainOfResponsibility.Exercise
{
    public abstract class Creature
    {
        public virtual int Attack { get; set; }
        public virtual int Defense { get; set; }

    }

    public class Goblin : Creature
    {
        protected Game game;
        private const int NominalAttackValue = 1;

        public Goblin(Game game)
        {
            game.Creatures.Add(this);       // comment this for authors test
            this.game = game;
        }

        public override int Attack
        {
            get
            {
                return game.Creatures.Any(x => x.GetType() == typeof(GoblinKing)) ?
                       game.Creatures.Count(x => x.GetType() == typeof(GoblinKing)) + NominalAttackValue :
                       NominalAttackValue;
            }
            set
            {

            }
        }

        public override int Defense
        {
            get => game.Creatures.Count;
            set
            {

            }
        }
    }

    public class GoblinKing : Goblin
    {
        private const int MinDefenseValue = 3;
        private const int NominalAttackValue = 3;

        public GoblinKing(Game game) : base(game)
        {

        }

        public override int Attack
        {
            get => NominalAttackValue;
            set
            {

            }
        }

        public override int Defense
        {
            get => game.Creatures.Count <= 2 ? MinDefenseValue : game.Creatures.Count;
            set
            {

            }
        }
    }

    public class Game
    {
        public IList<Creature> Creatures = new List<Creature>();
    }
}
