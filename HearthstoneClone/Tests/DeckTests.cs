using NUnit.Framework;

namespace HearthstoneClone.Tests
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void Ctor_CreatesTwentyCardDeck()
        {
            var deck = new Deck();

            Assert.That(deck.Count, Is.EqualTo(20));
        }

        [Test]
        public void Draw_GivenNumber_ReturnsAndRemovesThatManyCards()
        {
            var deck = new Deck();

            var cards = deck.Draw(3);

            Assert.That(cards.Count, Is.EqualTo(3));
            Assert.That(deck.Count, Is.EqualTo(17));
        }
    }
}