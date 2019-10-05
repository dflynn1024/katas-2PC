using System.Collections.Generic;
using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    public class Dealer : IDealer
    {
        private readonly IShuffler _shuffler;

        public Dealer(IShuffler shuffler)
        {
            _shuffler = shuffler;
        }

        public Deck Shuffle(Deck deck)
        {
            return _shuffler.Shuffle(deck);
        }

        public void Deal(Deck deck, IList<Player> players, int cardsToDeal)
        {
            while (cardsToDeal > 0)
            {
                foreach (var player in players)
                {
                    player.AssignCard(deck.Pop());
                }

                cardsToDeal--;
            }
        }
    }
}