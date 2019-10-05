using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    public interface IShuffler
    {
        Deck Shuffle(Deck deck);
    }
}