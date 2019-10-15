using System.Linq;
using _2CP.Game.Facts;
using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    /// <summary>
    /// Ranks cards in a hand based on the 2-card poker rules. E.g. J♠,A♠ is a Flush with A♠ high card.
    /// </summary>
    public class Ranker : IRanker
    {
        public (HandRank rank, Card highCard) RankHand(Hand hand)
        {
            if (hand.IsStraightFlush())
                return (HandRank.StraightFlush, GetHighCard(hand));

            if (hand.IsFlush())
                return (HandRank.Flush, GetHighCard(hand));

            if (hand.IsStraight())
                return (HandRank.Straight, GetHighCard(hand));

            return hand.IsPair() 
                ? (HandRank.Pair, GetHighCard(hand)) 
                : (HandRank.HighCard, GetHighCard(hand));
        }

        #region Private Helpers

        private static Card GetHighCard(Hand hand)
        {
            return hand.Cards
                .OrderByDescending(c => c.Rank)
                .ThenByDescending(c => c.Suit)
                .FirstOrDefault();
        }

        #endregion
    }
}