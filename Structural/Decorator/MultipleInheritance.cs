using System;
using static System.Console;

namespace Decorator
{
    public interface IBird
    {
        int Weight { get; set; }
        void Fly();
    }

    public interface ILizard
    {
        int Weight { get; set; }
        void Crawl();
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            WriteLine($"The bird can fly with weight {Weight}");
        }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            WriteLine($"The lizard can crawl with weight {Weight}");
        }
    }

    public class Dragon // no multiple inheritance
    {
        private Bird bird;
        private Lizard lizard;
        private int weight;

        public Dragon()
        {
            this.bird = new Bird();
            this.lizard = new Lizard();
        }

        public Dragon(Bird bird, Lizard lizard)
        {
            this.bird = bird ?? throw new ArgumentNullException(paramName: nameof(bird));
            this.lizard = lizard ?? throw new ArgumentNullException(paramName: nameof(lizard));
        }

        public int Weight {
            get { return weight; }
            set {
                bird.Weight = value;
                lizard.Weight = value;
                this.weight = value;
            }
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }
}