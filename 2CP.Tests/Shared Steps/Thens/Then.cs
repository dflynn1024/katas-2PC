using _2CP.Game;
using FluentAssertions;

namespace _2CP.Tests.Shared_Steps.Thens
{
    public static class Then
    {
        public static void GameStatusIs(IGame game, GameStatus expectedStatus)
        {
            game.Status.Should().Be(expectedStatus);
        }

        public static void GameHasExpectedNumberOfPlayers(IGame game, int expectedNumberOfPlayers)
        {
            game.Players.Count.Should().Be(expectedNumberOfPlayers);
        }

        public static void GameHasExpectedNumberOfRoundsScored(IGame game, int expectedNumberOfRounds)
        {
            game.Rounds.Count.Should().Be(expectedNumberOfRounds);
        }
    }
}