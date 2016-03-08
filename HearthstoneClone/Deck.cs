using System.Collections.Generic;
using System.Linq;

namespace HearthstoneClone
{
    public class Deck : List<Card>
    {
        public Deck()
        {
            var cards =
                new[] {0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8}
                    .Select(item => new Card(item))
                    .ToList();

            cards.Shuffle();

            AddRange(cards);
        }

        public List<Card> Draw(int numberOfCards)
        {
            if (Count < numberOfCards)
            {
                numberOfCards = Count;
            }

            var cards = new List<Card>();
            for (var i = 0; i < numberOfCards; i++)
            {
                cards.Add(this[i]);
                RemoveAt(i);
            }

            return cards;
        }
    }
}