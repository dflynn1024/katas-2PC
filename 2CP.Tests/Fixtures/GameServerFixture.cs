using _2CP.Game;
using Autofac.Extras.Moq;
using System;

namespace _2CP.Tests.Fixtures
{
    /// <summary>
    /// Game Server Fixture (auto mocked dependencies)
    /// </summary>
    /// <remarks>
    /// Use for testing Game Server scenarios. Register any specific dependencies
    /// you want to use. All others will be auto-mocked.
    /// </remarks>
    public class GameServerFixture : IDisposable
    {
        private readonly AutoMock _mock;
        private GameServer _gameServer;

        public GameServer GameServer => _gameServer ?? (_gameServer = _mock.Create<GameServer>());

        public GameServerFixture()
        {
            _mock = AutoMock.GetLoose();
        }

        public void RegisterDependency<TDependency>(TDependency dependency)
            where TDependency : class
        {
            _mock.Provide(dependency);
        }

        public void Dispose()
        {
            _mock.Dispose();
        }
    }
}
