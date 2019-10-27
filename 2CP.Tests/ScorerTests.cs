using _2CP.Game.Actors;
using _2CP.Tests.Fixtures;
using _2CP.Tests.Shared_Steps.Givens;
using _2CP.Tests.Shared_Steps.Thens;
using _2CP.Tests.Shared_Steps.Whens;
using System.Collections.Generic;
using Xunit;

namespace _2CP.Tests
{
    public class ScorerTests : IClassFixture<SystemUnderTestFixture<Scorer>>
    {
        private readonly IScorer _scorer;

        public ScorerTests(SystemUnderTestFixture<Scorer> fixture)
        {
            _scorer = fixture.SystemUnderTest;
        }
        
        [Theory(DisplayName = "Scorer Scenarios")]
        [MemberData(nameof(ScorerScenarios))]
        public void ScoreRound((string name, int round, IList<(string player, string hand)> players, IList<(string player, int score)> scores) scenario)
        {
            Given.TheFollowingPlayersWithHands(scenario.players, out var players);
            When.TheRoundIsScored(_scorer, players, scenario.round, out var round);
            Then.TheRoundScoreIs(round, scenario.scores);
        }

        #region Theory Data

        public static TheoryData<(string name, int round, IList<(string player, string hand)> players, IList<(string player, int score)> scores)> ScorerScenarios =>
            new TheoryData<(string name, int round, IList<(string player, string hand)> players, IList<(string player, int score)> scores)>
            {
                (
                    name: "Scenario 1: Ken win's, high card (ace high)'",
                    round: 1,
                    players: new [] {
                        (player: "ken", hand: "A♠,2♥"),
                        (player: "jon", hand: "K♠,2♥")},
                    scores: new [] {
                        (player: "ken", score: 1),
                        (player: "jon", score: 0)}
                )
           };

        #endregion
    }
}
