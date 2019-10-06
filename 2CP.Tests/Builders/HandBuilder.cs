using _2CP.Game.Model;
using FizzWare.NBuilder;

namespace _2CP.Tests.Builders
{
    public static class HandBuilder
    {
        public static ISingleObjectBuilder<Hand> WithCards(this ISingleObjectBuilder<Hand> builder, string [] cardShortNames)
        {
            return builder.WithFactory(() => new Hand(cardShortNames));
        }
    }
}