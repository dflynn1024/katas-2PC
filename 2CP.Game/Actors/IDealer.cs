using System.Collections.Generic;
using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    public interface IDealer
    {
        void Deal(Deck deck, IList<Player> players, int cards);
        Deck Shuffle(Deck deck);
        IList<Score> ScorePlayers(IList<Player> players);
    }
}