using _2CP.Game;
using System.Collections.Generic;
using _2CP.Game.Actors;
using _2CP.Game.Model;

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

        public static void TheDealerDealsXCards(IDealer dealer, Deck deck, IList<Player> players, int cards)
        {
            dealer.Deal(deck, players, cards);
        }
    }
}
