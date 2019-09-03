using _2CP.Game;
using FluentAssertions;

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
    }
}