using _2CP.Game;
using _2CP.Tests.Fixtures;
using _2CP.Tests.Shared_Steps.Givens;
using System.Collections.Generic;
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
        public void NewGameScenarios((string name, int totalPlayers, int totalRounds, List<Player> players) scenario)
        {
            // Arrange
            Given.IAmStartingANewGame(_fixture.GameServer, scenario.totalPlayers, scenario.totalPlayers, out var game);
            Given.TheFollowingPlayersJoinGame(game, scenario.players);
        }

        #region Theory Data

        public static TheoryData<(string name, int totalPlayers, int totalRounds, List<Player> players)> TheoryDataForNewGameScenarios =>
            new TheoryData<(string name, int totalPlayers, int totalRounds, List<Player> players)>
            {
                (
                    name: "Scenario 1 – New Game for 1 player and 1 round",
                    totalPlayers: 1,
                    totalRounds: 1,
                    players: new List<Player> {
                        new Player("bob")}
                )
           };

        #endregion


    }
}
