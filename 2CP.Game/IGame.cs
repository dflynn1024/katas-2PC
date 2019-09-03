using System.Collections.Generic;

namespace _2CP.Game
{
    public interface IGame
    {
        int RequiredPlayers { get; }
        int NumberOfRounds { get; }
        GameStatus Status { get; }
        IList<Player> Players { get; }
        IList<Round> Rounds { get; }
        void Join(Player player);
        void PlayRound();       
    }
}
