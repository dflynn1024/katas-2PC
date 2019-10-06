using System.Collections.Generic;
using System.Linq;

namespace _2CP.Game.Model
{
    /// <summary>
    /// Player's Hand which is just a collection of cards.
    /// </summary>
    public class Hand
    {
        public IList<Card> Cards { get; }

        public Hand(IList<Card> cards = null)
        {
            Cards = cards ?? new List<Card>();
        }

        public Hand(IEnumerable<string> cardShortNames)
        {
            Cards = cardShortNames.Select(shortName => new Card(shortName)).ToList();
        }

        public void AssignCard(Card card)
        {
            Cards.Add(card);
        }

        public void ClearCards()
        {
            Cards.Clear();
        }
    }
}