using _2CP.Game.Actors;
using _2CP.Game.Model;
using FizzWare.NBuilder;

namespace _2CP.Tests.Builders
{
    public static class PlayerBuilder
    {
        public static ISingleObjectBuilder<Player> WithNameAndHand(this ISingleObjectBuilder<Player> builder, string name, Hand hand = null)
        {
            return builder.WithFactory(() => new Player(name, hand));
        }
    }
}