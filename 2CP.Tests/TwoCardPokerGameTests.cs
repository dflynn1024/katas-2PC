using _2CP.Game;
using _2CP.Game.Actors;
using _2CP.Game.Model;
using _2CP.Game.Validators;
using _2CP.Tests.Fixtures;
using _2CP.Tests.Shared_Steps.Givens;
using _2CP.Tests.Shared_Steps.Thens;
using _2CP.Tests.Shared_Steps.Whens;
using FluentValidation;
using Xunit;

namespace _2CP.Tests
{
    public class TwoCardPokerGameTests : IClassFixture<SystemUnderTestFixture<GameServer>>
    {
        private readonly IGameServer _gameServer;

        public TwoCardPokerGameTests(SystemUnderTestFixture<GameServer> fixture)
        {
            fixture.RegisterDependency<IValidator<TwoCardPokerGame>>(new TwoCardPokerGameValidator());
            fixture.RegisterDependency<IDealer>(new Dealer(new Shuffler(), new Scorer(new Ranker())));
            _gameServer = fixture.SystemUnderTest;
        }

        [Theory(DisplayName = "Two Card Poker Game Tests: Play Game Scenarios")]
        [MemberData(nameof(TheoryDataForPlayGameScenarios))]
        public void PlayGameScenarios((string name, int totalPlayers, int totalRounds, string[] players, int playRounds, GameStatus expectedStatus, int expectedPlayersJoined, int expectedRoundsScored, int expectedNumberOfErrors) scenario)
        {
            Given.IAmStartingANewGame(_gameServer, scenario.totalPlayers, scenario.totalRounds, out var game);
            Given.TheFollowingPlayersJoinGame(game, scenario.players);
            When.TheFollowingNumberOfRoundsArePlayed(game, scenario.playRounds);
            Then.GameStatusIs(game, scenario.expectedStatus);
            Then.GameHasExpectedNumberOfPlayers(game, scenario.expectedPlayersJoined);
            Then.GameHasExpectedNumberOfRoundsScored(game, scenario.expectedRoundsScored);
            Then.GameHasExpectedNumberOfErrors(game, scenario.expectedNumberOfErrors);
            Then.TheWinnerOfEachRoundIsThePlayerWithHighestScore(game);
            Then.TheWinningPlayerIsThePlayerWithHighestScore(game);
        }

        #region Theory Data

        public static TheoryData<(string name, int totalPlayers, int totalRounds, string [] players, int playRounds, GameStatus expectedStatus, int expectedPlayersJoined, int expectedRoundsScored, int expectedNumberOfErrors)> TheoryDataForPlayGameScenarios =>
            new TheoryData<(string name, int totalPlayers, int totalRounds, string[] players, int playRounds, GameStatus expectedStatus, int expectedPlayersJoined, int expectedRoundsScored, int expectedNumberOfErrors)>
            {
                (
                    name: "Scenario 01: 2 of 2 Players Joined, 1 of 1 Rounds Played: Expect Game Over",
                    totalPlayers: 2,
                    totalRounds: 1,
                    players: new [] {"Bob", "Gill"},
                    playRounds: 1,
                    expectedStatus: GameStatus.GameOver,
                    expectedPlayersJoined: 2,
                    expectedRoundsScored: 1,
                    expectedNumberOfErrors: 0
                ),
                (
                    name: "Scenario 02: 1 of 2 Players Joined: Expect Awaiting Players, No rounds scored",
                    totalPlayers: 2,
                    totalRounds: 1,
                    players: new [] {"Bob"},
                    playRounds: 0,
                    expectedStatus: GameStatus.AwaitingPlayers,
                    expectedPlayersJoined: 1,
                    expectedRoundsScored: 0,
                    expectedNumberOfErrors: 0
                ),
                (
                    name: "Scenario 03: 1 of 2 Players Joined: Expect Awaiting Players, Try Play Round, No rounds scored",
                    totalPlayers: 2,
                    totalRounds: 1,
                    players: new [] {"Bob"},
                    playRounds: 1,
                    expectedStatus: GameStatus.AwaitingPlayers,
                    expectedPlayersJoined: 1,
                    expectedRoundsScored: 0,
                    expectedNumberOfErrors: 0
                ),
                (
                    name: "Scenario 04: 2 of 2 Players Joined: 1 or 2 Rounds Played, Expect Game InProgress",
                    totalPlayers: 2,
                    totalRounds: 2,
                    players: new [] {"Bob", "Gill"},
                    playRounds: 1,
                    expectedStatus: GameStatus.InProgress,
                    expectedPlayersJoined: 2,
                    expectedRoundsScored: 1,
                    expectedNumberOfErrors: 0
                ),
                (
                    name: "Scenario 05: Max Players: Max Rounds (all played), Expect Game Over",
                    totalPlayers: 6,
                    totalRounds: 5,
                    players: new [] {"Bob", "Gill", "Tim", "Todd", "Jon", "Liz"},
                    playRounds: 5,
                    expectedStatus: GameStatus.GameOver,
                    expectedPlayersJoined: 6,
                    expectedRoundsScored: 5,
                    expectedNumberOfErrors: 0
                ),
                (
                    name: "Scenario 06: Invalid number of players (> max). Expect Game Invalid and 1 errors",
                    totalPlayers: 8,
                    totalRounds: 5,
                    players: new string []{},
                    playRounds: 5,
                    expectedStatus: GameStatus.Invalid,
                    expectedPlayersJoined: 0,
                    expectedRoundsScored: 0,
                    expectedNumberOfErrors: 1
                ),
                (
                    name: "Scenario 07: Invalid number of players (< min). Expect Game Invalid and 1 errors",
                    totalPlayers: 1,
                    totalRounds: 5,
                    players: new string []{},
                    playRounds: 5,
                    expectedStatus: GameStatus.Invalid,
                    expectedPlayersJoined: 0,
                    expectedRoundsScored: 0,
                    expectedNumberOfErrors: 1
                ),
                (
                    name: "Scenario 08: Invalid number of rounds (> max). Expect Game Invalid and 1 errors",
                    totalPlayers: 2,
                    totalRounds: 6,
                    players: new string []{},
                    playRounds: 5,
                    expectedStatus: GameStatus.Invalid,
                    expectedPlayersJoined: 0,
                    expectedRoundsScored: 0,
                    expectedNumberOfErrors: 1
                ),
                (
                    name: "Scenario 09: Invalid number of rounds (< min). Expect Game Invalid and 1 errors",
                    totalPlayers: 2,
                    totalRounds: 0,
                    players: new string []{},
                    playRounds: 5,
                    expectedStatus: GameStatus.Invalid,
                    expectedPlayersJoined: 0,
                    expectedRoundsScored: 0,
                    expectedNumberOfErrors: 1
                ),
                (
                    name: "Scenario 10: Invalid number of players and rounds. Expect Game Invalid and 2 errors",
                    totalPlayers: 0,
                    totalRounds: 0,
                    players: new string []{},
                    playRounds: 5,
                    expectedStatus: GameStatus.Invalid,
                    expectedPlayersJoined: 0,
                    expectedRoundsScored: 0,
                    expectedNumberOfErrors: 2
                ),
                (
                    name: "Scenario 11: Try to join more than required number of players. Expect only first x players to be joined.",
                    totalPlayers: 2,
                    totalRounds: 1,
                    players: new [] {"Bob", "Gill", "Tim"},
                    playRounds: 1,
                    expectedStatus: GameStatus.GameOver,
                    expectedPlayersJoined: 2,
                    expectedRoundsScored: 1,
                    expectedNumberOfErrors: 0
                )
           };

        #endregion
    }
}
