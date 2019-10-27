using _2CP.Game;
using _2CP.Game.Actors;
using _2CP.Game.Model;
using System.Collections.Generic;

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

        public static void TheHandIsRanked(IRanker ranker, string handNotation, out Hand hand)
        {
            hand = new Hand(handNotation);
            ranker.RankHand(hand);
        }

        public static void TheRoundIsScored(IScorer scorer, IList<Player> players, int roundNumber, out Round round)
        {
            var scores = scorer.Score(players);
            round = new Round(roundNumber, scores);
        }
    }
}
