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
                    name: "Scenario 1: 2 Players, Ken win's, high card",
                    round: 1,
                    players: new [] {
                        (player: "ken", hand: "3♠,4♥"),
                        (player: "jon", hand: "2♠,3♥")},
                    scores: new [] {
                        (player: "jon", score: 0),
                        (player: "ken", score: 1)}
                ),
                (
                    name: "Scenario 2: 2 Players, Jon win's, high card (same rank ♠ > ♥)",
                    round: 1,
                    players: new [] {
                        (player: "ken", hand: "7♥,4♥"),
                        (player: "jon", hand: "7♠,3♥")},
                    scores: new [] {
                        (player: "ken", score: 0),
                        (player: "jon", score: 1)}
                ),
                (
                    name: "Scenario 3: 6 Players, Bob win's, high card (ace high)",
                    round: 1,
                    players: new [] {
                        (player: "ken", hand: "8♠,4♥"),
                        (player: "jon", hand: "K♠,4♥"),
                        (player: "bob", hand: "A♠,4♥"),
                        (player: "sue", hand: "J♠,4♥"),
                        (player: "joe", hand: "6♠,4♥"),
                        (player: "tim", hand: "2♠,3♥")},
                    scores: new [] {
                        (player: "tim", score: 0),
                        (player: "joe", score: 1),
                        (player: "ken", score: 2),
                        (player: "sue", score: 3),
                        (player: "jon", score: 4),
                        (player: "bob", score: 5)}
                )
           };

        #endregion
    }
}
