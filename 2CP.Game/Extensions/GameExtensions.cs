namespace _2CP.Game.Extensions
{
    public static class GameExtensions
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
