using _2CP.Game.Model;

namespace _2CP.Game.Facts
{
    internal static class GameFacts
    {
        public static bool CanPlayRound(this IGame game)
        {
            return (game.Status == GameStatus.ReadyToBegin || game.Status == GameStatus.InProgress) 
                   && (game.Rounds.Count < game.NumberOfRounds);
        }

        public static bool CanAddMorePlayers(this IGame game)
        {
            return game.Status == GameStatus.AwaitingPlayers;
        }
    }
}
