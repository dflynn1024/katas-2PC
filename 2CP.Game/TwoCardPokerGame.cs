using System.Collections.Generic;

namespace _2CP.Game
{
    /// <summary>
    /// Two Card Poker Game
    /// </summary>
    public class TwoCardPokerGame : IGame
    {
        private int _totalPlayers;
        private int _totalRounds;

        public GameStatus Status { get; private set; }
        public IList<Player> Players { get;  }

        public TwoCardPokerGame(int players, int rounds)
        {
            _totalPlayers = players;
            _totalRounds = rounds;

            Status = GameStatus.AwaitingPlayers;
            Players = new List<Player>(players);
        }

        /// <summary>
        /// Run Game
        /// </summary>
        public void Run()
        {
            Status = GameStatus.InProgress;
        }

        public void Join(Player player)
        {
            Players.Add(player);
        }
    }
}
