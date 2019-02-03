using NUnit.Framework;
using ChainOfResponsibility.Exercise;

namespace ChainOfResponsibility
{
    [TestFixture]
    public class UnitTests
    {
        private Game game;

        [SetUp]
        public void Init()
        {
            game = new Game();
        }

        [Test]
        public void SingleGoblin_HasAttack_1()
        {
            // Arrange
            var goblin = new Goblin(game);

            // Act
            var actual = goblin.Attack;

            // Assert
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void SingleGoblin_HasDefense_1()
        {
            // Arrange
            var goblin = new Goblin(game);

            // Act
            var actual = goblin.Defense;

            // Assert
            Assert.AreEqual(1, actual);
        }

        [Test]
        public void GoblinKing_HasAttack_3()
        {
            // Arrange
            var king = new GoblinKing(game);

            // Act
            var actual = king.Attack;

            // Assert
            Assert.AreEqual(3, actual);
        }

        [Test]
        public void GoblinKing_HasDefense_3()
        {
            // Arrange
            var king = new GoblinKing(game);

            // Act
            var actual = king.Defense;

            // Assert
            Assert.AreEqual(3, actual);
        }

        [Test]
        public void When_GoblinKingIsInGame_SimpleGoblinHasAttack_2()
        {
            // Arrange
            var goblin1 = new Goblin(game);
            var goblin2 = new Goblin(game);
            var goblin3 = new Goblin(game);
            var king = new GoblinKing(game);

            // Act
            var actual1 = goblin1.Attack;
            var actual2 = goblin2.Attack;
            var actual3 = goblin3.Attack;
            var actualKing = king.Attack;

            // Assert
            Assert.AreEqual(2, actual1);
            Assert.AreEqual(2, actual2);
            Assert.AreEqual(2, actual3);
            Assert.AreEqual(3, actualKing);
        }

        [Test]
        public void WhenThereAreSeveralGoblinsInGame_SimpleGoblinDefense_EqualsNumberOfGoblins()
        {
            // Arrange
            var goblin1 = new Goblin(game);
            var goblin2 = new Goblin(game);
            var goblin3 = new Goblin(game);
            var king = new GoblinKing(game);

            // Act
            var actual1 = goblin1.Defense;
            var actual2 = goblin2.Defense;
            var actual3 = goblin3.Defense;
            var actualKing = king.Defense;

            // Assert
            Assert.AreEqual(4, actual1);
            Assert.AreEqual(4, actual2);
            Assert.AreEqual(4, actual3);
            Assert.AreEqual(4, actualKing);
        }

        [Test]
        public void WhenThereAreOneGoblinAndKingInGame_SimpleGoblinDefense_EqualsNumberOfGoblins()
        {
            // Arrange
            var goblin = new Goblin(game);
            var king = new GoblinKing(game);

            // Act
            var actual1 = goblin.Defense;
            var actualKing = king.Defense;

            // Assert
            Assert.AreEqual(2, actual1);
            Assert.AreEqual(3, actualKing);
        }

        // authors test
        [Test]
        public void ManyGoblinsTest()
        {
            var game = new Game();
            var goblin = new Goblin(game);
            game.Creatures.Add(goblin);

            Assert.That(goblin.Attack, Is.EqualTo(1));
            Assert.That(goblin.Defense, Is.EqualTo(1));

            var goblin2 = new Goblin(game);
            game.Creatures.Add(goblin2);

            Assert.That(goblin.Attack, Is.EqualTo(1));
            Assert.That(goblin.Defense, Is.EqualTo(2));

            var goblin3 = new GoblinKing(game);
            game.Creatures.Add(goblin3);

            Assert.That(goblin.Attack, Is.EqualTo(2));
            Assert.That(goblin.Defense, Is.EqualTo(3));
        }
    }
}
