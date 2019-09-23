using System.Collections.Generic;

namespace _2CP.Game
{
    public interface IDealer
    {
        Deck Shuffle(Deck deck);
        void Deal(Deck deck, IList<Player> players, int cards);
    }
}