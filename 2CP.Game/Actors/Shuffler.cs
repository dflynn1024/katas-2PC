using System;
using _2CP.Game.Extensions;
using _2CP.Game.Model;

namespace _2CP.Game.Actors
{
    /// <summary>
    /// Shuffler shuffles a deck of cards using the Fisher-Yates shuffle. https://stackoverflow.com/questions/273313/randomize-a-list.
    /// </summary>
    public class Shuffler : IShuffler
    {
        private readonly Random _randomizer;

        public Shuffler()
        {
            _randomizer = new Random();
        }

        /// <summary>
        /// Shuffle a Deck of Cards
        /// </summary>
        /// <param name="deck">Deck to shuffle</param>
        /// <returns>Shuffled deck (cloned from deck to shuffle)</returns>
        public Deck Shuffle(Deck deck)
        {
            return FisherYatesShuffle((Deck)deck.Clone());
        }

        #region Private Helpers

        private Deck FisherYatesShuffle(Deck deck)
        {
            var n = deck.Cards.Count;

            while (n > 1)
            {
                n--;
                var k = _randomizer.Next(n + 1);
                deck.Cards.Swap(k, n);
            }

            return deck;
        }

        #endregion
    }
}