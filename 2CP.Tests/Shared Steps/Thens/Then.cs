using System;
using _2CP.Game;
using FluentAssertions;
using System.Collections.Generic;
using _2CP.Game.Actors;
using _2CP.Game.Model;
using Castle.Core.Internal;

namespace _2CP.Tests.Shared_Steps.Thens
{
    public static class Then
    {
        public static void GameStatusIs(IGame game, GameStatus expected)
        {
            game.Status.Should().Be(expected);
        }

        public static void GameHasExpectedNumberOfPlayers(IGame game, int expected)
        {
            game.Players?.Count.Should().Be(expected);
        }

        public static void GameHasExpectedNumberOfRoundsScored(IGame game, int expected)
        {
            game.Rounds?.Count.Should().Be(expected);
        }

        public static void GameHasExpectedNumberOfErrors(IGame game, int expected)
        {
            game.Errors?.Count.Should().Be(expected);
        }

        public static void XCardsShouldBeInDifferentPositions(Deck deckBeforeShuffle, Deck deckAfterShuffle, int cardsInDifferentPositions)
        {

            var notSame = 0;

            for (var i = 0; i < 52; i++)
            {
                if (deckBeforeShuffle.Cards[i] != deckAfterShuffle.Cards[i])
                    notSame++;
            }

            notSame.Should().BeGreaterOrEqualTo(cardsInDifferentPositions);
        }

        public static void EachPlayerShouldHaveXCardsInHand(IList<Player> players, int cards)
        {
            if (players.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(players), "players required for assertion!");

            foreach (var player in players)
            {
                player.Hand.Cards.Should().HaveCount(cards, $"{player.Name} has been dealt {cards} cards.");
            }
        }

        public static void EachPlayerShouldExpectedCardsInHand(IList<Player> players, IList<Hand> hands)
        {
            if(players.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(players), "players required for assertion!");

            if (hands.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(hands), "hands required for assertion!");

            if (players.Count != hands.Count)
                throw new ArgumentNullException(nameof(hands), "same player & hand count required for assertion!");

            for (var n=0; n<players.Count; n++)
            {
                players[n].Hand.Should().BeEquivalentTo(hands[n], $"{players[n].Name} has been dealt {players[n].Hand} cards.");
            }
        }

        public static void DeckShouldHaveXCardsLeft(Deck deck, int cardsLeft)
        {
            deck.Cards.Should().HaveCount(cardsLeft);
        }
    }
}