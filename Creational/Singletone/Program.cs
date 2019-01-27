using Autofac;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

/*
    Singleton - a component which is instantiated only once.
*/

namespace Singleton
{

    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        private SingletonDatabase()
        {
            WriteLine("Initializing database");

            capitals = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(list => list.ElementAt(0).Trim(),
                              list => int.Parse(list.ElementAt(1).Trim()));
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => instance.Value;
    }

    public class OrdinaryDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        private OrdinaryDatabase()
        {
            WriteLine("Initializing database");

            capitals = File.ReadAllLines(
                Path.Combine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, 
                "capitals.txt"))
                .Batch(2)
                .ToDictionary(list => list.ElementAt(0).Trim(),
                              list => int.Parse(list.ElementAt(1).Trim()));
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            WriteLine($"{city} has population {db.GetPopulation(city)}");

            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();

            // monostate
            var ceo1 = new CEO() {
                Name = "Adam Smith",
                Age = 55,
            };

            var ceo2 = new CEO();
            WriteLine(ceo2);

            ReadKey();
        }
    }
}
