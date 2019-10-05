using _2CP.Game.Actors;

namespace _2CP.Game.Model
{
    public class Score
    {
        public int Total { get; }
        public Player Player { get; }

        public Score(int total, Player player)
        {
            Total = total;
            Player = player;
        }
    }
}
