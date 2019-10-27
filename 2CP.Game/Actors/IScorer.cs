using System.Collections.Generic;
using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    public interface IScorer
    {
        IList<Score> Score(IList<Player> players);
    }
}