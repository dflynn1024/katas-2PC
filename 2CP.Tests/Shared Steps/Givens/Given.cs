using _2CP.Game;
using _2CP.Game.Actors;
using _2CP.Game.Model;

// ReSharper disable InconsistentNaming

namespace _2CP.Tests.Shared_Steps.Givens
{
    public static class Given
    {
        public static void IAmStartingANewGame(IGameServer gameServer, int players, int rounds, out IGame game)
        {
            game = gameServer.NewGame(players, rounds);
        }

        public static void TheFollowingPlayersJoinGame(IGame game, string[] players)
        {
            foreach (var player in players)
            {
                game.Join(player);
            }
        }

        public static void ANewDeckOfCards(out Deck deck)
        {
            deck = new Deck();
        }
    }
}
