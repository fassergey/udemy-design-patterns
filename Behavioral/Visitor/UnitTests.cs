using NUnit.Framework;

namespace Visitor.Exercise
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void SimpleAddition()
        {
            var simple = new AdditionExpression(new Value(2), new Value(3));
            var ep = new ExpressionPrinter();
            ep.Visit(simple);
            Assert.That(ep.ToString(), Is.EqualTo("(2+3)"));
        }
    }
}
