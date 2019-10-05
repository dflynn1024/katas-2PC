using System.Collections.Generic;

namespace _2CP.Game.Model
{
    /// <summary>
    /// Player's Hand which is just a collection of cards.
    /// </summary>
    public class Hand
    {
        public IList<Card> Cards { get; }

        public Hand(int max = 2)
        {
            Cards = new List<Card>(max);
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