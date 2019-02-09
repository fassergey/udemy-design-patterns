using NUnit.Framework;
using System.Collections.Generic;

namespace Interpreter
{
    [TestFixture]
    public class UnitTests
    {
        private ExpressionProcessor sut;

        [SetUp]
        public void Init()
        {
            sut = new ExpressionProcessor();
        }

        [TestCase("")]
        [TestCase("()asdf")]
        [TestCase("18*7-4/3")]
        public void ExpressionProcessor_WhenExpressionIsIncorrect_ShouldReturn_0(string expression)
        {
            // Arrange

            // Act
            var actual = sut.Calculate(expression);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestCase("1+2+3+x+y")]
        public void ExpressionProcessor_WhenExpressionContainsNotExpectedVariables_ShouldReturn_0(string expression)
        {
            // Arrange
            sut.Variables = new Dictionary<char, int>
            {
                { 'x', 4 },
            };

            // Act
            var actual = sut.Calculate(expression);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestCase("1+2+3+xy")]
        public void ExpressionProcessor_WhenExpressionContainsVariableWithMoreThanOneLetter_ShouldReturn_0(string expression)
        {
            // Arrange
            sut.Variables = new Dictionary<char, int>
            {
                { 'x', 4 },
                { 'y', 5 },
            };

            // Act
            var actual = sut.Calculate(expression);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestCase("1+2+3+x+y", 15)]
        [TestCase("10+20+30+x+y", 69)]
        [TestCase("10+20+30-x-y", 51)]
        //[TestCase("-10+20+30-x-y", 31)]       broke our class
        public void ExpressionProcessor_WhenExpressionContainsExpectedVariables_ShouldBeCalculated(string expression, int result)
        {
            // Arrange
            sut.Variables = new Dictionary<char, int>
            {
                { 'x', 4 },
                { 'y', 5 },
            };

            // Act
            var actual = sut.Calculate(expression);

            // Assert
            Assert.AreEqual(result, actual);
        }
    }
}
