using FluentValidation;

namespace _2CP.Game.Validators
{
    public class TwoCardPokerGameValidator : AbstractValidator<TwoCardPokerGame>
    {
        public TwoCardPokerGameValidator()
        {
            RuleFor(x => x.NumberOfRounds).InclusiveBetween(1,5);
            RuleFor(x => x.RequiredPlayers).InclusiveBetween(2, 6);
        }
    }
}
