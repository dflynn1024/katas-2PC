using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    public interface IGameServer
    {
        IGame NewGame(int players, int rounds);
    }
}
