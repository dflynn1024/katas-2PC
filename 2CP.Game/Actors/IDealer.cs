using System.Collections.Generic;
using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    public interface IDealer
    {
        Deck Shuffle(Deck deck);
        void Deal(Deck deck, IList<Player> players, int cards);
    }
}