using _2CP.Game;
using Autofac.Extras.Moq;

namespace _2CP.Tests.Fixtures
{
    public class GameServerFixture        
    {
        /// <summary>
        /// Game Server Fixture (auto mocked dependencies)
        /// </summary>
        public GameServer GameServer { get; }

        public GameServerFixture()
        {
            using (var mock = AutoMock.GetLoose())
            {
                GameServer = mock.Create<GameServer>();
            }
        }
    }
}
