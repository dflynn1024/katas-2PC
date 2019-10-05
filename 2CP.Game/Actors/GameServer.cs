using _2CP.Game.Model;
using FluentValidation;

namespace _2CP.Game.Actors
{
    public class GameServer : IGameServer
    {
        private readonly IValidator<TwoCardPokerGame> _twoCardPokerGameValidator;

        public GameServer(IValidator<TwoCardPokerGame> twoCardPokerGameValidator)
        {
            _twoCardPokerGameValidator = twoCardPokerGameValidator;
        }

        public IGame NewGame(int players, int rounds)
        {
            return new TwoCardPokerGame(_twoCardPokerGameValidator, players, rounds);
        }
    }
}
