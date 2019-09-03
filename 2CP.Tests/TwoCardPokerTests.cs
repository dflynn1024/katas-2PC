using _2CP.Game;
using _2CP.Tests.Fixtures;
using _2CP.Tests.Shared_Steps.Givens;
using System.Collections.Generic;
using _2CP.Tests.Shared_Steps.Thens;
using _2CP.Tests.Shared_Steps.Whens;
using Xunit;

namespace _2CP.Tests
{

    public class TwoCardPokerTests : IClassFixture<GameServerFixture>
    {
        private readonly GameServerFixture _fixture;

        public TwoCardPokerTests(GameServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory(DisplayName = "Game Server Tests")]
        [MemberData(nameof(TheoryDataForNewGameScenarios))]
        public void NewGameScenarios((string name, int totalPlayers, int totalRounds, List<Player> players, int playRounds, GameStatus expectedStatus, int expectedRoundsScored) scenario)
        {
            Given.IAmStartingANewGame(_fixture.GameServer, scenario.totalPlayers, scenario.totalRounds, out var game);
            Given.TheFollowingPlayersJoinGame(game, scenario.players);
            When.TheFollowingNumberOfRoundsArePlayed(game, scenario.playRounds);
            Then.GameStatusIs(game, scenario.expectedStatus);
            Then.GameHasExpectedNumberOfPlayers(game, scenario.players.Count);
            Then.GameHasExpectedNumberOfRoundsScored(game, scenario.expectedRoundsScored);
        }

        #region Theory Data

        public static TheoryData<(string name, int totalPlayers, int totalRounds, List<Player> players, int playRounds, GameStatus expectedStatus, int expectedRoundsScored)> TheoryDataForNewGameScenarios =>
            new TheoryData<(string name, int totalPlayers, int totalRounds, List<Player> players, int playRounds, GameStatus expectedStatus, int expectedRoundsScored)>
            {
                (
                    name: "Scenario 1: 2 of 2 Players Joined, 1 of 1 Rounds Played: Expect Game Over",
                    totalPlayers: 2,
                    totalRounds: 1,
                    players: new List<Player> {
                        new Player("bob"),
                        new Player("gill")
                    },
                    playRounds: 1,
                    expectedStatus: GameStatus.GameOver,
                    expectedRoundsScored: 1
                ),
                (
                    name: "Scenario 2: 1 of 2 Players Joined: Expect Awaiting Players, No rounds scored",
                    totalPlayers: 2,
                    totalRounds: 1,
                    players: new List<Player> {
                        new Player("bob")
                    },
                    playRounds: 0,
                    expectedStatus: GameStatus.AwaitingPlayers,
                    expectedRoundsScored: 0
                ),
                (
                    name: "Scenario 3: 1 of 2 Players Joined: Expect Awaiting Players, Try Play Round, No rounds scored",
                    totalPlayers: 2,
                    totalRounds: 1,
                    players: new List<Player> {
                        new Player("bob")
                    },
                    playRounds: 1,
                    expectedStatus: GameStatus.AwaitingPlayers,
                    expectedRoundsScored: 0
                ),
                (
                    name: "Scenario 4: 2 of 2 Players Joined: 1 or 2 Rounds Played, Expect Game InProgress",
                    totalPlayers: 2,
                    totalRounds: 2,
                    players: new List<Player> {
                        new Player("bob"),
                        new Player("gill")
                    },
                    playRounds: 1,
                    expectedStatus: GameStatus.InProgress,
                    expectedRoundsScored: 1
                ),
                (
                    name: "Scenario 5: Max Players: Max Rounds (all played), Expect Game Over",
                    totalPlayers: 6,
                    totalRounds: 5,
                    players: new List<Player> {
                        new Player("bob"),
                        new Player("gill"),
                        new Player("tim"),
                        new Player("todd"),
                        new Player("jon"),
                        new Player("liz")
                    },
                    playRounds: 5,
                    expectedStatus: GameStatus.GameOver,
                    expectedRoundsScored: 5
                )
           };

        #endregion


    }
}
