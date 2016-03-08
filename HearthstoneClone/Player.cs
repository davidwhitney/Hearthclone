using System.Collections.Generic;
using System.Linq;

namespace HearthstoneClone
{
    public class Player
    {
        public Deck Deck { get; set; }
        public List<Card> Hand { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public bool IsDead => Health <= 0;

        public Player()
        {
            Health = 30;
            Mana = 1;

            Deck = new Deck();
            Hand = new List<Card>(Deck.Draw(3));
        }

        public void StartTurn()
        {
            var freshCard = Deck.Draw(1);

            if (freshCard.Any())
            {
                if (Hand.Count < 5)
                {
                    Hand.AddRange(freshCard);
                }
            }
            else
            {
                Health--;
            }

            Mana++;
            Mana = Mana > 10 ? 10 : Mana;
        }

        public Card PlayCard(Card cardToPlay)
        {
            Hand.Remove(cardToPlay);
            return cardToPlay;
        }

        public void BeAttacked(Card card)
        {
            Health -= card.Value;
        }
    }
}