using FluentAssertions;
using Xunit;
using _2CP.Game;

namespace _2CP.Tests
{

    public class _2CP_Tests : BaseTest<_2CP_Game>
    {
        [Fact]
        public void When_I_Run_Game_Then_Game_Is_Running()
        {
            // Arrange
            // Act
            SystemUnderTest.Run();

            // Assert
            SystemUnderTest.IsRunning.Should().BeTrue();
        }
    }
}
