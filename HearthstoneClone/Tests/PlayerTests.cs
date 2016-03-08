using System.Linq;
using NUnit.Framework;

namespace HearthstoneClone.Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Ctor_GetsFullHand()
        {
            var player = new Player();

            Assert.That(player.Deck, Is.Not.Null);
        }

        [Test]
        public void Ctor_PlayerHasMaxHealthAndOneMana()
        {
            var player = new Player();

            Assert.That(player.Health, Is.EqualTo(30));
            Assert.That(player.Mana, Is.EqualTo(1));
        }

        [Test]
        public void Ctor_PlayerDrawsThreeCards()
        {
            var player = new Player();

            Assert.That(player.Hand.Count, Is.EqualTo(3));
        }

        [Test]
        public void StartTurn_DrawsACard()
        {
            var player = new Player();

            player.StartTurn();

            Assert.That(player.Hand.Count, Is.EqualTo(4));
        }

        [Test]
        public void StartTurn_HandFiveOrOver_DiscardsDrawnCard()
        {
            var player = new Player();

            player.StartTurn();
            player.StartTurn();
            player.StartTurn();

            Assert.That(player.Hand.Count, Is.EqualTo(5));
        }

        [Test]
        public void StartTurn_IncrementsMana()
        {
            var player = new Player();

            player.StartTurn();

            Assert.That(player.Mana, Is.EqualTo(2));
        }

        [Test]
        public void StartTurn_ManaIsFull_StaysFull()
        {
            var player = new Player {Mana = 10};

            player.StartTurn();

            Assert.That(player.Mana, Is.EqualTo(10));
        }

        [Test]
        public void StartTurn_DeckIsEmpty_PlayerBleeds()
        {
            var deck = new Deck();
            deck.Clear();
            var player = new Player { Deck = deck };

            player.StartTurn();

            Assert.That(player.Health, Is.EqualTo(29));
        }

        [Test]
        public void PlayCard_RemovesCardFromHand()
        {
            var player = new Player {Mana = 10};
            var cardToPlay = player.Hand.First();

            var returned = player.PlayCard(cardToPlay);

            CollectionAssert.DoesNotContain(player.Hand, cardToPlay);
            Assert.That(returned, Is.EqualTo(cardToPlay));
        }

        [Test]
        public void BeAttacked_GivenCard_DamagesHealth()
        {
            var player = new Player();

            player.BeAttacked(new Card(1));

            Assert.That(player.Health, Is.EqualTo(29));
        }

        [Test]
        public void IsDead_LessThanOrEqToZeroHealth_IsTrue()
        {
            var player = new Player {Health = 1};

            player.BeAttacked(new Card(1));

            Assert.That(player.Health, Is.EqualTo(0));
            Assert.That(player.IsDead, Is.True);
        }
    }
}