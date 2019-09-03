namespace _2CP.Game
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
