using NUnit.Framework;
using System.Numerics;

namespace Strategy
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void PositiveTestOrdinaryStrategy()
        {
            var strategy = new Exercise.OrdinaryDiscriminantStrategy();
            var solver = new Exercise.QuadraticEquationSolver(strategy);
            var results = solver.Solve(1, 10, 16);
            Assert.That(results.Item1, Is.EqualTo(new Complex(-2, 0)));
            Assert.That(results.Item2, Is.EqualTo(new Complex(-8, 0)));
        }

        [Test]
        public void PositiveTestRealStrategy()
        {
            var strategy = new Exercise.RealDiscriminantStrategy();
            var solver = new Exercise.QuadraticEquationSolver(strategy);
            var results = solver.Solve(1, 10, 16);
            Assert.That(results.Item1, Is.EqualTo(new Complex(-2, 0)));
            Assert.That(results.Item2, Is.EqualTo(new Complex(-8, 0)));
        }

        [Test]
        public void NegativeTestOrdinaryStrategy()
        {
            var strategy = new Exercise.OrdinaryDiscriminantStrategy();
            var solver = new Exercise.QuadraticEquationSolver(strategy);
            var results = solver.Solve(1, 4, 5);
            Assert.That(results.Item1, Is.EqualTo(new Complex(-2, 1)));
            Assert.That(results.Item2, Is.EqualTo(new Complex(-2, -1)));
        }

        [Test]
        public void NegativeTestRealStrategy()
        {
            var strategy = new Exercise.RealDiscriminantStrategy();
            var solver = new Exercise.QuadraticEquationSolver(strategy);
            var results = solver.Solve(1, 4, 5);
            var complexNaN = new Complex(double.NaN, double.NaN);

            Assert.That(results.Item1, Is.EqualTo(complexNaN));
            Assert.That(results.Item2, Is.EqualTo(complexNaN));

            Assert.IsTrue(double.IsNaN(results.Item1.Real));
            Assert.IsTrue(double.IsNaN(results.Item1.Imaginary));
            Assert.IsTrue(double.IsNaN(results.Item2.Real));
            Assert.IsTrue(double.IsNaN(results.Item2.Imaginary));
        }
    }
}
