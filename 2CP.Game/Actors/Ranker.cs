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
        public void RankHand(Hand hand)
        {
            if (hand.IsStraightFlush())
            {
                hand.Rank = HandRank.StraightFlush;
                return;
            }

            if (hand.IsFlush())
            {
                hand.Rank = HandRank.Flush;
                return;
            }

            if (hand.IsStraight())
            {
                hand.Rank = HandRank.Straight;
                return;
            }

            if (hand.IsPair())
            {
                hand.Rank = HandRank.Pair;
                return;
            }

            hand.Rank = HandRank.HighCard;
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