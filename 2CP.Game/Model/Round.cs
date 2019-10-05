using System.Collections.Generic;

namespace _2CP.Game.Model
{
    public class Round
    {
        public int Number { get; }
        public IList<Score> Scores { get; set; }

        public Round(int number)
        {
            Number = number;
        }
    }
}
