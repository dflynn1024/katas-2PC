using _2CP.Game;
using _2CP.Tests.Fixtures;
using _2CP.Tests.Shared_Steps.Givens;
using _2CP.Tests.Shared_Steps.Thens;
using _2CP.Tests.Shared_Steps.Whens;
using Xunit;

namespace _2CP.Tests
{
    public class DealerTests : IClassFixture<SystemUnderTestFixture<Dealer>>
    {
        private readonly Dealer _dealer;

        public DealerTests(SystemUnderTestFixture<Dealer> fixture)
        {
            _dealer = fixture.SystemUnderTest;
        }

        [Theory(DisplayName = "Dealer Scenarios")]
        [MemberData(nameof(TheoryDataForDealerScenarios))]
        public void DealerScenarios((string name, int shuffles, int expectAtLeastXCardsDifferent) scenario)
        {
            Given.ANewDeckOfCards(out var deck);
            When.TheDealerShufflesTheDeckXTimes(_dealer, deck, out var shuffledDeck, scenario.shuffles);
            Then.XCardsShouldBeInDifferentPositions(deck, shuffledDeck, scenario.expectAtLeastXCardsDifferent);
        }

        #region Theory Data

        public static TheoryData<(string name, int shuffles, int expectAtLeastXCardsDifferent)> TheoryDataForDealerScenarios =>
            new TheoryData<(string name, int shuffles, int expectAtLeastXCardsDifferent)>
            {
                (
                    name: "Scenario 1: Deck should be the same when no shuffles",
                    shuffles: 0,
                    expectAtLeastXCardsDifferent: 0
                ),
                (
                    name: "Scenario 2: Expect at least 26 Cards different after 1 shuffle",
                    shuffles: 1,
                    expectAtLeastXCardsDifferent: 26
                ),
                (
                    name: "Scenario 3: Expect at least 26 Cards different after 9 shuffles",
                    shuffles: 9,
                    expectAtLeastXCardsDifferent: 26
                )
           };

        #endregion


    }
}
