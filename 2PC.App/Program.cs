using System;
using _2CP.Game;
using _2CP.Game.Validators;

namespace _2PC.App
{
    internal class Program
    {
        private static int Main()
        {
            try
            {
                Output("Two-Card Poker v0.1 (beta)", OutputType.Title);

                var players = PromptNumber("Enter number of players (2-6): ");
                var rounds = PromptNumber("Enter number of rounds (1-5): ");
                var server = new GameServer(new TwoCardPokerGameValidator());
                var game = server.NewGame(players, rounds);

                if (game.Status == GameStatus.Invalid)
                {
                    ShowGameErrors(game);
                    return ExitGame(ExitCode.Fail);
                }

                JoinPlayersLoop(game);
                GameLoop(game);
                ShowGameSummary(game);

                Prompt("Press any key to continue...");

                return ExitGame();
            }
            catch (Exception e)
            {
                GlobalErrorHandler(e);
                return ExitGame(ExitCode.Fail);
            }
        }

        #region Private Helpers

        private static void ShowGameErrors(IGame game)
        {
            foreach (var gameError in game.Errors)
            {
                Output(gameError, OutputType.Warning);
            }
        }

        private static void Output(string message, OutputType outputType = OutputType.Info, bool newLine = true)
        {
            SetupColours(outputType);

            if (newLine)
                Console.WriteLine(message);
            else
                Console.Write(message);
        }

        private static string Prompt(string prompt)
        {
            Output(prompt, OutputType.Prompt, false);
            return Console.ReadLine();
        }

        private static int PromptNumber(string prompt)
        {
            while (true)
            {
                var input = Prompt(prompt);

                if (uint.TryParse(input, out var number))
                    return (int)number;
            }
        }

        public static void SetupColours(OutputType outputType = OutputType.Info)
        {
            switch (outputType)
            {
                case OutputType.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case OutputType.Warning:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case OutputType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case OutputType.Prompt:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case OutputType.Title:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }
        }

        private static int ExitGame(ExitCode exitCode = ExitCode.Success)
        {
            Console.ResetColor();
            return (int)exitCode;
        }

        private static void GlobalErrorHandler(Exception e)
        {
            Output($"Exception: {e.Message}\nSource: {e.Source}\nStack Trace: {e.StackTrace}", OutputType.Error);
        }


        private static void JoinPlayersLoop(IGame game)
        {
            while (game.Status == GameStatus.AwaitingPlayers)
            {
                var currentPlayer = game.Players.Count + 1;
                var playerName =  Prompt($"Enter short name for player #{currentPlayer}: ");
                game.Join(playerName);
            }

            Prompt($"All {game.RequiredPlayers} players have now joined, let's play!");
        }

        private static void GameLoop(IGame game)
        {
            while (game.Status != GameStatus.GameOver)
            {
                var currentRound = game.Rounds.Count + 1;
                Prompt($"Play Round {currentRound}");
                game.PlayRound();

                ShowRoundSummary(game, currentRound);
            }
        }

        private static void ShowRoundSummary(IGame game, int round)
        {
            Output($"Round {game.Rounds[round-1].Number} complete.");
        }

        private static void ShowGameSummary(IGame game)
        {
            Output("Game Over!");
            Output($"All {game.Rounds.Count} rounds have been completed.");
            Output($"And the winner is {game.Winner.Name}");
        }

        #endregion
    }
}
