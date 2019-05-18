namespace _2CP.Game
{
    public class GameServer : IGameServer
    {
        public IGame NewGame(int players, int rounds)
        {
            return new TwoCardPokerGame(players, rounds);
        }
    }
}
