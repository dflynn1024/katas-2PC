using _2CP.Game.Extensions;
using FluentValidation;
using System.Collections.Generic;

namespace _2CP.Game
{
    /// <summary>
    /// Two Card Poker Game according to specification: https://github.com/dflynn1024/katas-2PC/blob/master/README.md
    /// </summary>
    public class TwoCardPokerGame : IGame
    {
        public int RequiredPlayers { get; }
        public int NumberOfRounds { get; }
        public GameStatus Status { get; private set; }
        public IList<Player> Players { get;  }
        public IList<Round> Rounds { get; }
        public IList<string> Errors { get; }

        public Player Winner { get; private set; }

        public TwoCardPokerGame(IValidator<TwoCardPokerGame> validator, int requiredPlayers, int numberOfRounds)
        {
            RequiredPlayers = requiredPlayers;
            NumberOfRounds = numberOfRounds;
            Errors = new List<string>();

            RunValidations(validator);

            if (Status == GameStatus.Invalid) return;

            Status = GameStatus.AwaitingPlayers;
            Players = new List<Player>(requiredPlayers);
            Rounds = new List<Round>(numberOfRounds);
        }

        /// <summary>
        /// Play next game round. Game Status change to GameOver when there are no more rounds to play.
        /// </summary>
        public void PlayRound()
        {
            if (!this.CanPlayRound())
                return;

            Rounds.Add(new Round(Rounds.Count + 1));

            Status = Rounds.Count == NumberOfRounds
                ? GameStatus.GameOver
                : GameStatus.InProgress;

            if(Status == GameStatus.GameOver)
                GameOver();
        }
        
        /// <summary>
        /// Join Player to Game. Once required players has been met, additional join players will be ignored.
        /// </summary>
        public void Join(string playerName)
        {
            if (!this.CanAddMorePlayers())
                return;

            Players.Add(new Player(playerName));

            Status = Players.Count < RequiredPlayers
                ? GameStatus.AwaitingPlayers
                : GameStatus.ReadyToBegin;
        }

        #region Private Helpers

        private void RunValidations(IValidator<TwoCardPokerGame> validator)
        {
            var result = validator.Validate(this);

            if (result.IsValid) return;

            Status = GameStatus.Invalid;

            foreach (var validationFailure in result.Errors)
            {
                Errors.Add(validationFailure.ErrorMessage);
            }
        }

        private void GameOver()
        {
            Winner = Players[0];
        }

        #endregion
    }
}
