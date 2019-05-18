namespace _2CP.Game
{
    public interface IGameServer
    {
        IGame NewGame(int players, int rounds);
    }
}
