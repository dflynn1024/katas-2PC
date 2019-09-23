using _2CP.Game;

namespace _2CP.Tests.Shared_Steps.Whens
{
    public static class When
    {
        public static void TheFollowingNumberOfRoundsArePlayed(IGame game, int rounds)
        {
            while (rounds > 0)
            {
                game.PlayRound();
                rounds--;
            }
        }

        public static void TheDealerShufflesTheDeckXTimes(IDealer dealer, Deck before, out Deck after, int numberOfShuffles)
        {
            after = before;

            while (numberOfShuffles > 0)
            {
                after = dealer.Shuffle(before);
                numberOfShuffles--;
            }
        }
    }
}
