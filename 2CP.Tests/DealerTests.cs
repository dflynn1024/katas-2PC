using System;
using _2CP.Tests.Builders;
using _2CP.Tests.Fixtures;
using _2CP.Tests.Shared_Steps.Givens;
using _2CP.Tests.Shared_Steps.Thens;
using _2CP.Tests.Shared_Steps.Whens;
using System.Collections.Generic;
using System.Linq;
using _2CP.Game.Actors;
using _2CP.Game.Model;
using FizzWare.NBuilder;
using Xunit;

namespace _2CP.Tests
{
    public class DealerTests : IClassFixture<SystemUnderTestFixture<Dealer>>
    {
        private readonly IDealer _dealer;

        public DealerTests(SystemUnderTestFixture<Dealer> fixture)
        {
            fixture.RegisterDependency<IShuffler>(new Shuffler());
            _dealer = fixture.SystemUnderTest;
        }
        
        [Theory(DisplayName = "Deal Scenarios")]
        [MemberData(nameof(DealScenarios))]
        public void DealCardsToPlayers((string name, IList<Player> players, int cardsToDeal, int expectedCardsInHand, IList<Hand> expectedHands, int expectedCardsLeft) scenario)
        {
            Given.ANewDeckOfCards(out var deck);
            When.TheDealerDealsXCards(_dealer, deck, scenario.players, scenario.cardsToDeal);
            Then.EachPlayerShouldHaveXCardsInHand(scenario.players, scenario.expectedCardsInHand);
            Then.EachPlayerShouldExpectedCardsInHand(scenario.players, scenario.expectedHands);
            Then.DeckShouldHaveXCardsLeft(deck, scenario.expectedCardsLeft);
        }

        #region Theory Data

        public static TheoryData<(string name, IList<Player> players, int cardsToDeal, int expectedCardsInHand, IList<Hand> expectedHands, int expectedCardsLeft)> DealScenarios =>
            new TheoryData<(string name, IList<Player> players, int cardsToDeal, int expectedCardsInHand, IList<Hand> expectedHands, int expectedCardsLeft)>
            {
                (
                    name: "Scenario 1: Deal 1 card, 2 players, each player should have 1 card in hand and 50 card left",
                    players: CreatePlayers(new []{"bob", "jan"}),
                    cardsToDeal: 1,
                    expectedCardsInHand: 1,
                    expectedHands: CreateHands(new []
                    {
                        "A♠",
                        "K♠"
                    }),
                    expectedCardsLeft: 50
                ),
                (
                    name: "Scenario 2: Deal 2 cards, 7 players, each player should have 2 cards in hand and 40 cards left",
                    players: CreatePlayers(new []{"bob", "jan", "jo", "jez", "zig", "zag", "zog"}),
                    cardsToDeal: 2,
                    expectedCardsInHand: 2,
                    expectedHands: CreateHands(new []
                    {
                        "A♠,7♠",
                        "K♠,6♠",
                        "Q♠,5♠",
                        "J♠,4♠",
                        "T♠,3♠",
                        "9♠,2♠",
                        "8♠,A♣"
                    }),
                    expectedCardsLeft: 38
                ),
                (
                    name: "Scenario 3: Deal 13 cards, 4 players, each player should have 13 cards in hand and zero card left",
                    players: CreatePlayers(new []{"bob", "jan", "jo", "jez"}),
                    cardsToDeal: 13,
                    expectedCardsInHand: 13,
                    expectedHands: CreateHands(new [] {
                        "A♠,T♠,6♠,2♠,J♣,7♣,3♣,Q♥,8♥,4♥,K♦,9♦,5♦",
                        "K♠,9♠,5♠,A♣,T♣,6♣,2♣,J♥,7♥,3♥,Q♦,8♦,4♦",
                        "Q♠,8♠,4♠,K♣,9♣,5♣,A♥,T♥,6♥,2♥,J♦,7♦,3♦",
                        "J♠,7♠,3♠,Q♣,8♣,4♣,K♥,9♥,5♥,A♦,T♦,6♦,2♦"}),
                    expectedCardsLeft: 0
                )
           };

        #endregion

        #region Private Helpers

        private static IList<Player> CreatePlayers(string[] names)
        {
            return Builder<List<Player>>.CreateNew().WithPlayers(names).Build();
        }

        private static IList<Hand> CreateHands(IEnumerable<string> handsOfCards)
        {
            return handsOfCards.Select(h => Builder<Hand>.CreateNew().WithCards(h.Split(',', StringSplitOptions.RemoveEmptyEntries)).Build()).ToList();
        }

        #endregion
    }
}
