using System;
using System.Numerics;

namespace Strategy
{
    public class Exercise
    {
        public interface IDiscriminantStrategy
        {
            double CalculateDiscriminant(double a, double b, double c);
        }

        public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
        {
            public double CalculateDiscriminant(double a, double b, double c)
            {
                return b*b - 4*a*c;
            }
        }

        public class RealDiscriminantStrategy : IDiscriminantStrategy
        {
            public double CalculateDiscriminant(double a, double b, double c)
            {
                var result = b * b - 4 * a * c;
                return result < 0 ? Double.NaN : result;
            }
        }

        public class QuadraticEquationSolver
        {
            private readonly IDiscriminantStrategy strategy;

            public QuadraticEquationSolver(IDiscriminantStrategy strategy)
            {
                this.strategy = strategy;
            }

            public Tuple<Complex, Complex> Solve(double a, double b, double c)
            {
                var disc = new Complex(strategy.CalculateDiscriminant(a, b, c), 0);
                var rootDisc = Complex.Sqrt(disc);
                return Tuple.Create(
                    (-b + rootDisc) / (2 * a),
                    (-b - rootDisc) / (2 * a)
                );
            }
        }
    }
}
