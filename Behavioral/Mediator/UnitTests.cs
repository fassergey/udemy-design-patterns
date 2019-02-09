using NUnit.Framework;

namespace Mediator
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Participant_WhenCreated_ValueShouldBe_0()
        {
            // Arrange
            var mediator = new Mediator();
            var sut = new Participant(mediator);

            // Act
            var actual = sut.Value;

            // Assert
            Assert.AreEqual(0, actual);
        }
        
        [Test]
        public void Test()
        {
            Mediator mediator = new Mediator();
            var p1 = new Participant(mediator);
            var p2 = new Participant(mediator);

            Assert.That(p1.Value, Is.EqualTo(0));
            Assert.That(p2.Value, Is.EqualTo(0));

            p1.Say(2);

            Assert.That(p1.Value, Is.EqualTo(0));
            Assert.That(p2.Value, Is.EqualTo(2));

            p2.Say(4);

            Assert.That(p1.Value, Is.EqualTo(4));
            Assert.That(p2.Value, Is.EqualTo(2));
        }
    }
}
