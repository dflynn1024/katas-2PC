using _2CP.Game.Actors;
using _2CP.Game.Model;
using FizzWare.NBuilder;
using System.Collections.Generic;
using System.Linq;

namespace _2CP.Tests.Builders
{
    public static class PlayersBuilder
    {
        public static ISingleObjectBuilder<List<Player>> WithPlayers(this ISingleObjectBuilder<List<Player>> builder, string [] names)
        {
            return builder
                .WithFactory(() => names.Select(name => new Player(name)).ToList());
        }

        public static ISingleObjectBuilder<List<Player>> WithPlayers(this ISingleObjectBuilder<List<Player>> builder, IList<(string player, string hand)> players)
        {
            return builder
                .WithFactory(() => players.Select(p => new Player(p.player, new Hand(p.hand))).ToList());
        }
    }
}