using System;
using System.Collections.Generic;
using System.Linq;
using _2CP.Game.Extensions;

namespace _2CP.Game.Model
{
    /// <summary>
    /// Deck of 52 cards
    /// </summary>
    public class Deck : ICloneable
    {
        public IList<Card> Cards { get; }

        public Deck()
        {
            Cards = NewDeck();
        }

        public Deck(IList<Card> cards)
        {
            Cards = cards;
        }

        public Card Pop()
        {
            var index = Cards.Count - 1;
            var card = Cards[index];
            Cards.RemoveAt(index);
            return card;
        }

        public object Clone()
        {
            var cards = Cards.ToList().ConvertAll(c => c.Clone() as Card);
            return new Deck(cards);
        }

        #region Private Helpers

        private static IList<Card> NewDeck()
        {
            return (from suit in EnumExtensions.GetValues<Suit>()
                from rank in EnumExtensions.GetValues<Rank>()
                select new Card(rank, suit)).ToList();

        }
        
        #endregion
    }
}