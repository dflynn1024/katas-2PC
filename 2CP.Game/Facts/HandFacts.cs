using System.Linq;
using _2CP.Game.Extensions;
using _2CP.Game.Model;

namespace _2CP.Game.Facts
{
    internal static class HandFacts
    {
        /// <summary>
        /// Any 2 cards that are the same Rank are considered a pair. E.g. 2♠,2♥.
        /// </summary>
        public static bool IsPair(this Hand hand)
        {
            var cardsOrderedByRank = hand.Cards.OrderBy(c => c.Rank).ToList();

            return cardsOrderedByRank[0].Rank == cardsOrderedByRank[1].Rank;
        }

        /// <summary>
        /// All cards are sequential and their are no gaps. Wrap around scenario is for Ace and Two. E.g. A♠,2♥.
        /// </summary>
        public static bool IsStraight(this Hand hand)
        {
            var cardsOrderedByRank = hand.Cards.OrderBy(c => c.Rank).ToList();

            for (var n = 1; n < cardsOrderedByRank.Count; n++)
            {
                var diff = ((int)cardsOrderedByRank[n].Rank).Difference((int)cardsOrderedByRank[n - 1].Rank);

                if (diff != 1 && diff != 12) // Ace vs Two
                    return false;
            }

            return true;
        }

        /// <summary>
        /// All cards are the same suit. E.g. 5♠,2♠.
        /// </summary>
        public static bool IsFlush(this Hand hand)
        {
            return hand.Cards.All(c => c.Suit == hand.Cards[0].Suit);
        }

        /// <summary>
        /// All cards are sequential (no gaps) and same suit. E.g. K♦,A♦.
        /// </summary>
        public static bool IsStraightFlush(this Hand hand)
        {
            return hand.IsStraight() && hand.IsFlush();
        }
    }
}
