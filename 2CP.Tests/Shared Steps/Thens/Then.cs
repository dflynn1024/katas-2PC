using _2CP.Game;
using _2CP.Game.Actors;
using _2CP.Game.Extensions;
using _2CP.Game.Model;
using Castle.Core.Internal;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;

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
                if (!deckBeforeShuffle.Cards[i].Equals(deckAfterShuffle.Cards[i]))
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

        public static void HandRankIs(HandRank actual, HandRank expected)
        {
            actual.Should().Be(expected);
        }

        public static void HandHighCardIs(Card actual, string expectedFromShortName)
        {
            actual.Should().Be(CreateCard(expectedFromShortName));
        }

        public static void TheRoundScoreIs(Round actual, IList<(string player, int score)> scoreNotation)
        {
            var expected = CreateRound(scoreNotation);

            actual.Scores.Should().BeEquivalentTo(expected.Scores, options => 
                options.Excluding(s => s.Player.Id).Excluding(s => s.Player.Hand));
        }

        public static void TheWinnerOfEachRoundIsThePlayerWithHighestScore(IGame game)
        {
            if (game.Status != GameStatus.GameOver)
                return;

            var roundsPlayed = game.Rounds.Where(r => r.Scores.IsNotNull() && r.Scores.Any()).ToList();
            var expectedWinners = roundsPlayed.Select((r,n) => new{ round = n, winner = r.Scores.OrderByDescending(s => s.Total).First().Player.Name}).ToList();
            var actualWinners = roundsPlayed.Select((r, n) => new { round = n, winner = r.Winner().Name }).ToList();

            expectedWinners.Should().BeEquivalentTo(actualWinners);
        }

        public static void TheWinningPlayerIsThePlayerWithHighestScore(IGame game)
        {
            if (game.Status != GameStatus.GameOver)
                return;

            var roundsPlayed = game.Rounds.Where(r => r.Scores.IsNotNull() && r.Scores.Any()).ToList();
            var overallScores = roundsPlayed.SelectMany(r => r.Scores).GroupBy(s => s.Player)
                .Select(s => new { player = s.Key, score = s.Sum(x => x.Total)})
                .ToList();

            var expectedWinner = overallScores.OrderByDescending(s => s.score).FirstOrDefault()?.player;
            game.Winner.Should().Be(expectedWinner);
        }

        #region Private Helpers

        private static Card CreateCard(string cardShortName)
        {
            return new Card(cardShortName);
        }

        private static Round CreateRound(IEnumerable<(string player, int score)> scoresNotation)
        {
            var scores = scoresNotation.Select(s => new Score(new Player(s.player), s.score)).ToList();
            return new Round(scores: scores);
        }

        #endregion
    }
}