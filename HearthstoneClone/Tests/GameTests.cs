using NUnit.Framework;

namespace HearthstoneClone.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Ctor_CreatesTwoPlayers()
        {
            var game = new Game();

            Assert.That(game.Player1, Is.Not.Null);
            Assert.That(game.Player2, Is.Not.Null);
        }
    }
}
