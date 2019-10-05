using System.Collections.Generic;
using _2CP.Game.Actors;
using _2CP.Game.Model;

namespace _2CP.Game
{
    public interface IGame
    {
        int RequiredPlayers { get; }
        int NumberOfRounds { get; }
        GameStatus Status { get; }
        IList<Player> Players { get; }
        IList<Round> Rounds { get; }
        Player Winner { get; }
        void Join(string playerName);
        void PlayRound();
        IList<string> Errors { get; }
    }
}
