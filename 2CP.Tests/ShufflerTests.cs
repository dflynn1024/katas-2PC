using _2CP.Tests.Fixtures;
using _2CP.Tests.Shared_Steps.Givens;
using _2CP.Tests.Shared_Steps.Thens;
using _2CP.Tests.Shared_Steps.Whens;
using _2CP.Game.Actors;
using Xunit;

namespace _2CP.Tests
{
    public class ShufflerTests : IClassFixture<SystemUnderTestFixture<Shuffler>>
    {
        private readonly Shuffler _shuffler;

        public ShufflerTests(SystemUnderTestFixture<Shuffler> fixture)
        {
            _shuffler = fixture.SystemUnderTest;
        }

        [Theory(DisplayName = "Shuffle Scenarios")]
        [MemberData(nameof(ShuffleScenarios))]
        public void ShuffleTheDeck((string name, int shuffles, int expectAtLeastXCardsDifferent) scenario)
        {
            Given.ANewDeckOfCards(out var deck);
            When.TheShufflerShufflesTheDeckXTimes(_shuffler, deck, out var shuffledDeck, scenario.shuffles);
            Then.XCardsShouldBeInDifferentPositions(deck, shuffledDeck, scenario.expectAtLeastXCardsDifferent);
        }

        #region Theory Data

        public static TheoryData<(string name, int shuffles, int expectAtLeastXCardsDifferent)> ShuffleScenarios =>
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
