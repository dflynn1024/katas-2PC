using System.Collections.Generic;
using _2CP.Game.Extensions;

namespace _2CP.Game
{
    public class Dealer : IDealer
    {
        public Deck Shuffle(Deck deck)
        {
            return deck.Shuffle();
        }

        public void Deal(Deck deck, IList<Player> players)
        {
            throw new System.NotImplementedException();
        }
    }
}