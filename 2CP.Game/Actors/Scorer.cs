using System.Collections.Generic;
using System.Linq;
using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    public class Scorer : IScorer
    {
        private readonly IRanker _ranker;

        public Scorer(IRanker ranker)
        {
            _ranker = ranker;
        }

        public IList<Score> Score(IList<Player> players)
        {
            RankEachPlayersHand(players);
            return ScoreBasedOnPlayersOrderedByHand(players);
        }

        #region Private Helpers
        private static List<Score> ScoreBasedOnPlayersOrderedByHand(IEnumerable<Player> players)
        {
            return players.OrderBy(p => p.Hand).Select((p, index) => new Score(p, index)).ToList();
        }

        private void RankEachPlayersHand(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                _ranker.RankHand(player.Hand);
            }
        }

        #endregion
    }
}