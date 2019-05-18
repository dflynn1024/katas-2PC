using System.Collections.Generic;

namespace _2CP.Game
{
    public interface IGame
    {
        GameStatus Status { get; }
        IList<Player> Players { get; }
        void Join(Player player);
        void Run();       
    }
}
