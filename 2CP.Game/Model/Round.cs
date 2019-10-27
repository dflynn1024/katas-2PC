using System.Collections.Generic;

namespace _2CP.Game.Model
{
    public class Round
    {
        public int Number { get; }
        public IList<Score> Scores { get; }

        public Round(int number=1, IList<Score> scores=null)
        {
            Number = number;
            Scores = scores;
        }
    }
}
