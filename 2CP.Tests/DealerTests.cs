using _2CP.Game;
using _2CP.Tests.Fixtures;
using _2CP.Tests.Shared_Steps.Givens;
using _2CP.Tests.Shared_Steps.Thens;
using _2CP.Tests.Shared_Steps.Whens;
using System.Collections.Generic;
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

        [Theory(DisplayName = "Shuffle Scenarios")]
        [MemberData(nameof(TheoryDataForShuffleScenarios))]
        public void ShuffleScenarios((string name, int shuffles, int expectAtLeastXCardsDifferent) scenario)
        {
            Given.ANewDeckOfCards(out var deck);
            When.TheDealerShufflesTheDeckXTimes(_dealer, deck, out var shuffledDeck, scenario.shuffles);
            Then.XCardsShouldBeInDifferentPositions(deck, shuffledDeck, scenario.expectAtLeastXCardsDifferent);
        }

        [Theory(DisplayName = "Deal Scenarios")]
        [MemberData(nameof(TheoryDataForDealScenarios))]
        public void DealScenarios((string name, IList<Player> players, int cardsToDeal, int expectedCardsInHand, int expectedCardsLeft) scenario)
        {
            Given.ANewDeckOfCards(out var deck);
            When.TheDealerDealsXCards(_dealer, deck, scenario.players, scenario.cardsToDeal);
            Then.EachPlayerShouldHaveXCardsInHand(scenario.players, scenario.expectedCardsInHand);
            Then.DeckShouldHaveXCardsLeft(deck, scenario.expectedCardsLeft);
        }

        #region Theory Data

        public static TheoryData<(string name, int shuffles, int expectAtLeastXCardsDifferent)> TheoryDataForShuffleScenarios =>
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

        public static TheoryData<(string name, IList<Player> players, int cardsToDeal, int expectedCardsInHand, int expectedCardsLeft)> TheoryDataForDealScenarios =>
            new TheoryData<(string name, IList<Player> players, int cardsToDeal, int expectedCardsInHand, int expectedCardsLeft)>
            {
                (
                    name: "Scenario 1: Deal 1 card, 2 players, each player should have 1 card in hand and 50 card left",
                    players: new List<Player> {
                                new Player("bob"),
                                new Player("jan")
                            },
                    cardsToDeal: 1,
                    expectedCardsInHand: 1,
                    expectedCardsLeft: 50
                ),
                (
                    name: "Scenario 2: Deal 2 cards, 6 players, each player should have 2 cards in hand and 40 cards left",
                    players: new List<Player> {
                        new Player("bob"),
                        new Player("jan"),
                        new Player("jo"),
                        new Player("jez"),
                        new Player("zig"),
                        new Player("zag")
                    },
                    cardsToDeal: 2,
                    expectedCardsInHand: 2,
                    expectedCardsLeft: 40
                ),
                (
                    name: "Scenario 3: Deal 13 cards, 4 players, each player should have 13 cards in hand and zero card left",
                    players: new List<Player> {
                        new Player("bob"),
                        new Player("jan"),
                        new Player("jo"),
                        new Player("jez")
                    },
                    cardsToDeal: 13,
                    expectedCardsInHand: 13,
                    expectedCardsLeft: 0
                )
           };

        #endregion


    }
}
