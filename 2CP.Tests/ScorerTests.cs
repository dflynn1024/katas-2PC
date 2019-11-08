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
            fixture.RegisterDependency<IRanker>(new Ranker());
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
                    name: "Scenario 01: 2 Players, Bob win's, high card",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "3♠,9♥"),
                        (player: "jon", hand: "2♠,4♥")},
                    scores: new [] {
                        (player: "jon", score: 0),
                        (player: "bob", score: 1)}
                ),
                (
                    name: "Scenario 02: 2 Players, Jim win's, high card (same rank, suit wins)",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "7♥,4♠"),
                        (player: "jim", hand: "7♠,3♥")},
                    scores: new [] {
                        (player: "bob", score: 0),
                        (player: "jim", score: 1)}
                ),
                (
                    name: "Scenario 03: 2 Players, Jim win's, pair beats high card",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "T♠,4♥"),
                        (player: "jim", hand: "2♠,2♥")},
                    scores: new [] {
                        (player: "bob", score: 0),
                        (player: "jim", score: 1)}
                ),
                (
                    name: "Scenario 04: 2 Players, Bob win's, pair beats pair (high card wins)",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "6♠,6♥"),
                        (player: "jim", hand: "3♠,3♥")},
                    scores: new [] {
                        (player: "jim", score: 0),
                        (player: "bob", score: 1)}
                ),
                (
                    name: "Scenario 05: 2 Players, Jim win's, pair beats pair (same high card, suit wins)",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "K♦,K♣"),
                        (player: "jim", hand: "K♠,K♥")},
                    scores: new [] {
                        (player: "bob", score: 0),
                        (player: "jim", score: 1)}
                ),
                (
                    name: "Scenario 06: 2 Players, Bob win's, straight beats high card",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "J♦,Q♣"),
                        (player: "jim", hand: "A♠,9♥")},
                    scores: new [] {
                        (player: "jim", score: 0),
                        (player: "bob", score: 1)}
                ),
                (
                    name: "Scenario 07: 2 Players, Jim win's, straight beats pair",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "K♠,K♥"),
                        (player: "jim", hand: "2♦,3♣")},
                    scores: new [] {
                        (player: "bob", score: 0),
                        (player: "jim", score: 1)}
                ),
                (
                    name: "Scenario 08: 2 Players, Bob win's, straight beats straight (high card wins)",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "K♦,A♣"),
                        (player: "jim", hand: "J♠,K♥")},
                    scores: new [] {
                        (player: "jim", score: 0),
                        (player: "bob", score: 1)}
                ),
                (
                    name: "Scenario 09: 2 Players, Jim win's, straight beats straight (same high card, suit wins)",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "J♦,K♣"),
                        (player: "jim", hand: "J♥,K♠")},
                    scores: new [] {
                        (player: "bob", score: 0),
                        (player: "jim", score: 1)}
                ),
                (
                    name: "Scenario 10: 2 Players, Jim win's, flush beats high card",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "3♦,K♣"),
                        (player: "jim", hand: "3♥,5♥")},
                    scores: new [] {
                        (player: "bob", score: 0),
                        (player: "jim", score: 1)}
                ),
                (
                    name: "Scenario 11: 2 Players, Bob win's, flush beats pair",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "5♦,7♦"),
                        (player: "jim", hand: "J♥,J♠")},
                    scores: new [] {
                        (player: "jim", score: 0),
                        (player: "bob", score: 1)}
                ),
                (
                    name: "Scenario 12: 2 Players, Jim win's, flush beats straight",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "J♦,K♣"),
                        (player: "jim", hand: "4♠,6♠")},
                    scores: new [] {
                        (player: "bob", score: 0),
                        (player: "jim", score: 1)}
                ),
                (
                    name: "Scenario 13: 2 Players, Bob win's, flush beats flush (high card wins)",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "8♥,K♥"),
                        (player: "jim", hand: "4♥,7♥")},
                    scores: new [] {
                        (player: "jim", score: 0),
                        (player: "bob", score: 1)}
                ),
                (
                    name: "Scenario 14: 2 Players, Jim win's, flush beats flush (same high card, suit wins)",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "2♦,4♦"),
                        (player: "jim", hand: "3♠,5♠")},
                    scores: new [] {
                        (player: "bob", score: 0),
                        (player: "jim", score: 1)}
                ),
                (
                    name: "Scenario 15: 2 Players, Bob win's, straight flush beats high card",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "3♠,4♠"),
                        (player: "jim", hand: "8♦,A♠")},
                    scores: new [] {
                        (player: "jim", score: 0),
                        (player: "bob", score: 1)}
                ),
                (
                    name: "Scenario 16: 2 Players, Jim win's, straight flush beats pair",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "K♦,K♥"),
                        (player: "jim", hand: "4♠,5♠")},
                    scores: new [] {
                        (player: "bob", score: 0),
                        (player: "jim", score: 1)}
                ),
                (
                    name: "Scenario 17: 2 Players, Bob win's, straight flush beats straight",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "6♦,7♦"),
                        (player: "jim", hand: "Q♠,K♥")},
                    scores: new [] {
                        (player: "jim", score: 0),
                        (player: "bob", score: 1)}
                ),
                (
                    name: "Scenario 18: 2 Players, Jim win's, straight flush beats flush",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "K♦,T♦"),
                        (player: "jim", hand: "6♠,5♠")},
                    scores: new [] {
                        (player: "bob", score: 0),
                        (player: "jim", score: 1)}
                ),
                (
                    name: "Scenario 19: 2 Players, Bob win's, straight flush beats straight flush (high card wins)",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "5♦,6♦"),
                        (player: "jim", hand: "3♦,4♦")},
                    scores: new [] {
                        (player: "jim", score: 0),
                        (player: "bob", score: 1)}
                ),
                (
                    name: "Scenario 20: 2 Players, Jim win's, straight flush beats straight flush (same high card, suit wins)",
                    round: 1,
                    players: new [] {
                        (player: "bob", hand: "5♦,6♦"),
                        (player: "jim", hand: "5♠,6♠")},
                    scores: new [] {
                        (player: "bob", score: 0),
                        (player: "jim", score: 1)}
                )
            };

        #endregion
    }
}
