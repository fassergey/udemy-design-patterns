using JetBrains.dotMemoryUnit;
using NUnit.Framework;
using System;
using System.Linq;
using static System.Console;

namespace Flyweight
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        // 6741226
        public void TestUser()
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            var users = (from firstName in firstNames
                         from lastName in lastNames
                         select new User($"{firstName} {lastName}")).ToList();

            ForceGC();

            dotMemory.Check(memory => {
                WriteLine(memory.SizeInBytes);
            });
        }

        [Test]
        // 7311481
        public void TestUser2()
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => RandomString());

            var users = (from firstName in firstNames
                         from lastName in lastNames
                         select new User2($"{firstName} {lastName}")).ToList();

            ForceGC();

            dotMemory.Check(memory => {
                WriteLine(memory.SizeInBytes);
            });
        }

        private void ForceGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private string RandomString()
        {
            var rand = new Random();
            return new string(Enumerable.Range(0, 10)
                .Select(i => (char)('a' + rand.Next(26)))
                .ToArray());
        }
    }
}
