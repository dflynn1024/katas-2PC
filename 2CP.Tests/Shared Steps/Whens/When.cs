using System;
using _2CP.Game;
using System.Collections.Generic;
using _2CP.Game.Actors;
using _2CP.Game.Model;
using _2CP.Tests.Builders;
using FizzWare.NBuilder;

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

        public static void TheShufflerShufflesTheDeckXTimes(IShuffler shuffler, Deck before, out Deck after, int numberOfShuffles)
        {
            after = (Deck)before.Clone();

            while (numberOfShuffles > 0)
            {
                after = shuffler.Shuffle(before);
                numberOfShuffles--;
            }
        }

        public static void TheDealerDealsXCards(IDealer dealer, Deck deck, IList<Player> players, int cards)
        {
            dealer.Deal(deck, players, cards);
        }

        public static void TheHandIsRanked(IRanker ranker, string hand, out (HandRank rank, Card highCard) result)
        {
            result = ranker.RankHand(CreateHand(hand));
        }

        #region Private Helpers

        private static Hand CreateHand(string csvCards)
        {
            return Builder<Hand>.CreateNew().WithCards(csvCards.Split(',', StringSplitOptions.RemoveEmptyEntries)).Build();
        }

        #endregion
    }
}
