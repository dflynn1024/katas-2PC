using System.Collections.Generic;
using System.Linq;
using _2CP.Game.Actors;

namespace _2CP.Game.Model
{
    public class Round
    {
        public int Number { get; }
        public IList<Score> Scores { get; }

        public Player Winner() => Scores?.OrderBy(s => s.Total).Last()?.Player;

        public Round(int number=1, IList<Score> scores=null)
        {
            Number = number;
            Scores = scores;
        }
    }
}
