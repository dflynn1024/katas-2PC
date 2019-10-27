using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    /// <summary>
    /// Ranks cards in a hand based on the 2-card poker rules. E.g. J♠,A♠ is a Flush with A♠ high card.
    /// </summary>
    public interface IRanker
    {
        void RankHand(Hand hand);
    }
}