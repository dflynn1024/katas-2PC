using System.Collections.Generic;
using System.Linq;
using _2CP.Game.Actors;
using FizzWare.NBuilder;

namespace _2CP.Tests.Builders
{
    public static class PlayersBuilder
    {
        public static ISingleObjectBuilder<List<Player>> WithPlayers(this ISingleObjectBuilder<List<Player>> builder, string [] names)
        {
            return builder
                    .WithFactory(() => CreatePlayersFromNames(names));
        }

        #region Private Helpers

        private static List<Player> CreatePlayersFromNames(IEnumerable<string> names)
        {
            return names.Select(name => new Player(name)).ToList();
        }

        #endregion
    }
}