using NUnit.Framework;

namespace State
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Exercise_WhenCreated_StatusLocked()
        {
            var cl = new CombinationLock(new[] {1,2,3,4,5});
            Assert.That(cl.Status, Is.EqualTo("LOCKED"));
        }

        [Test]
        public void Exercise_WhenEnteredWrongDigit_StatusError()
        {
            var cl = new CombinationLock(new[] { 1, 2, 3, 4, 5 });
            cl.EnterDigit(1);
            Assert.That(cl.Status, Is.EqualTo("1"));
            cl.EnterDigit(1);
            Assert.That(cl.Status, Is.EqualTo("ERROR"));
        }

        [Test]
        public void Exercise_WhenEnteredCorrect_StatusOpen()
        {
            var cl = new CombinationLock(new[] { 1, 2, 3, 4, 5 });
            cl.EnterDigit(1);
            Assert.That(cl.Status, Is.EqualTo("1"));
            cl.EnterDigit(2);
            Assert.That(cl.Status, Is.EqualTo("12"));
            cl.EnterDigit(3);
            Assert.That(cl.Status, Is.EqualTo("123"));
            cl.EnterDigit(4);
            Assert.That(cl.Status, Is.EqualTo("1234"));
            cl.EnterDigit(5);
            Assert.That(cl.Status, Is.EqualTo("OPEN"));
        }
    }
}
