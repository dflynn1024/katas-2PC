using _2CP.Game.Actors;

namespace _2CP.Game.Model
{
    public class Score
    {
        public int Total { get; }
        public Player Player { get; }

        public Score(Player player, int total)
        {
            Total = total;
            Player = player;
        }
    }
}
