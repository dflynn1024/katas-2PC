using System.Collections.Generic;
using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    public class Dealer : IDealer
    {
        private readonly IShuffler _shuffler;
        private readonly IScorer _scorer;

        public Dealer(IShuffler shuffler, IScorer scorer)
        {
            _shuffler = shuffler;
            _scorer = scorer;
        }

        public Deck Shuffle(Deck deck)
        {
            return _shuffler.Shuffle(deck);
        }

        /// <summary>
        /// Each player is dealt a card until all players have been dealt x cards.
        /// </summary>
        public void Deal(Deck deck, IList<Player> players, int cardsToDeal)
        {
            while (cardsToDeal > 0)
            {
                foreach (var player in players)
                {
                    player.AssignCard(deck.Pop());
                }

                cardsToDeal--;
            }
        }

        /// <summary>
        /// Evaluate player hands and scorer each player from weakest to strongest hand.
        /// </summary>
        public IList<Score> ScorePlayers(IList<Player> players)
        {
            return _scorer.Score(players);
        }
    }
}