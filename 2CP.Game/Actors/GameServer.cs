using _2CP.Game.Validators;
using FluentValidation;

namespace _2CP.Game.Actors
{
    public class GameServer : IGameServer
    {
        private readonly IValidator<TwoCardPokerGame> _validator;
        private readonly IDealer _dealer;

        public GameServer()
            : this(new TwoCardPokerGameValidator(), new Dealer(new Shuffler(), new Scorer(new Ranker())))
        {
        }

        public GameServer(IValidator<TwoCardPokerGame> validator, IDealer dealer)
        {
            _validator = validator;
            _dealer = dealer;
        }

        public IGame NewGame(int players, int rounds)
        {
            return new TwoCardPokerGame(players, rounds, _validator, _dealer);
        }
    }
}
