using System.Collections.Generic;
using _2CP.Game.Extensions;

namespace _2CP.Game
{
    /// <summary>
    /// Two Card Poker Game
    /// </summary>
    public class TwoCardPokerGame : IGame
    {
        public int RequiredPlayers { get; }
        public int NumberOfRounds { get; }
        public GameStatus Status { get; private set; }
        public IList<Player> Players { get;  }
        public IList<Round> Rounds { get; }

        public TwoCardPokerGame(int requiredPlayers, int numberOfRounds)
        {
            RequiredPlayers = requiredPlayers;
            NumberOfRounds = numberOfRounds;

            ValidatePlayers();
            ValidateRounds();

            if (this.Status == GameStatus.Invalid)
                return;

            Status = GameStatus.AwaitingPlayers;
            Players = new List<Player>(requiredPlayers);
            Rounds = new List<Round>(numberOfRounds);
        }

        /// <summary>
        /// Run Game
        /// </summary>
        public void PlayRound()
        {
            if (!this.CanPlayRound())
                return;

            Rounds.Add(new Round(Rounds.Count + 1));

            Status = Rounds.Count == NumberOfRounds
                ? GameStatus.GameOver
                : GameStatus.InProgress;
        }

        public void Join(Player player)
        {
            if (!this.CanAddMorePlayers())
                return;

            Players.Add(player);

            Status = Players.Count < RequiredPlayers
                ? GameStatus.AwaitingPlayers
                : GameStatus.ReadyToBegin;
        }

        #region Private Helpers

        private void ValidatePlayers()
        {
            const int minPlayers = 2;
            const int maxPlayers = 6;

            if(this.RequiredPlayers < minPlayers || this.RequiredPlayers > maxPlayers)
                this.Status = GameStatus.Invalid;
        }

        private void ValidateRounds()
        {
            const int minRounds = 1;
            const int maxRounds = 5;

            if (this.NumberOfRounds < minRounds || this.NumberOfRounds > maxRounds)
                this.Status = GameStatus.Invalid;
        }
        #endregion
    }
}
