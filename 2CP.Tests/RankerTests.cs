using _2CP.Game.Actors;
using _2CP.Game.Model;
using _2CP.Tests.Fixtures;
using _2CP.Tests.Shared_Steps.Thens;
using _2CP.Tests.Shared_Steps.Whens;
using Xunit;

namespace _2CP.Tests
{
    public class RankerTests : IClassFixture<SystemUnderTestFixture<Ranker>>
    {
        private readonly IRanker _ranker;

        public RankerTests(SystemUnderTestFixture<Ranker> fixture)
        {
            fixture.RegisterDependency<IRanker>(new Ranker());
            _ranker = fixture.SystemUnderTest;
        }
        
        [Theory(DisplayName = "Rank Scenarios")]
        [MemberData(nameof(RankScenarios))]
        public void RankCardsInHand((string name, string hand, string high, HandRank rank) scenario)
        {
            When.TheHandIsRanked(_ranker, scenario.hand, out var result);
            Then.HandHighCardIs(result.highCard, scenario.high);
            Then.HandRankIs(result.rank, scenario.rank);
        }

        #region Theory Data

        public static TheoryData<(string name, string hand, string high, HandRank rank)> RankScenarios =>
            new TheoryData<(string name, string hand, string high, HandRank rank)>
            {
                (
                    name: "Scenario 1: High Card, A♠ High",
                    hand: "A♠,J♥",
                    high: "A♠",
                    rank: HandRank.HighCard
                ),
                (
                    name: "Scenario 2: High Card, K♥ High",
                    hand: "J♠,K♥",
                    high: "K♥",
                    rank: HandRank.HighCard
                ),
                (
                    name: "Scenario 3: High Card, A♠ High (3 cards)",
                    hand: "J♠,2♥,A♠",
                    high: "A♠",
                    rank: HandRank.HighCard
                ),
                (
                    name: "Scenario 4: Pair, K♥ High",
                    hand: "K♦,K♥",
                    high: "K♥",
                    rank: HandRank.Pair
                ),
                (
                    name: "Scenario 5: Pair, 2♠ High",
                    hand: "2♠,2♥",
                    high: "2♠",
                    rank: HandRank.Pair
                ),
                (
                    name: "Scenario 6: Pair, J♠ High (3 cards)",
                    hand: "2♠,2♥,J♠",
                    high: "J♠",
                    rank: HandRank.Pair
                ),
                (
                    name: "Scenario 7: Straight, 3♥ High",
                    hand: "2♠,3♥",
                    high: "3♥",
                    rank: HandRank.Straight
                ),
                (
                    name: "Scenario 8: Straight, A♠ High",
                    hand: "A♠,K♥",
                    high: "A♠",
                    rank: HandRank.Straight
                ),
                (
                    name: "Scenario 9: Straight, A♠ High (wrap around)",
                    hand: "A♠,2♥",
                    high: "A♠",
                    rank: HandRank.Straight
                ),
                (
                    name: "Scenario 10: Straight, 5♥ High (3 cards)",
                    hand: "5♥,3♠,4♥",
                    high: "5♥",
                    rank: HandRank.Straight
                ),
                (
                    name: "Scenario 11: Flush, 5♠ High",
                    hand: "5♠,2♠",
                    high: "5♠",
                    rank: HandRank.Flush
                ),
                (
                    name: "Scenario 12: Flush, A♠ High",
                    hand: "J♠,A♠",
                    high: "A♠",
                    rank: HandRank.Flush
                ),
                (
                    name: "Scenario 13: Flush, A♦ High (3 cards)",
                    hand: "K♦,A♦,5♦",
                    high: "A♦",
                    rank: HandRank.Flush
                ),
                (
                    name: "Scenario 14: Straight Flush, A♦ High",
                    hand: "K♦,A♦",
                    high: "A♦",
                    rank: HandRank.StraightFlush
                ),
                (
                    name: "Scenario 15: Straight Flush, A♦ High (wrap around)",
                    hand: "2♦,A♦",
                    high: "A♦",
                    rank: HandRank.StraightFlush
                ),
                (
                    name: "Scenario 16: Straight Flush, 9♦ High (3 cards)",
                    hand: "7♦,8♦,9♦",
                    high: "9♦",
                    rank: HandRank.StraightFlush
                )
           };

        #endregion
    }
}
