using _2CP.Game.Model;

namespace _2CP.Game.Extensions
{
    public static class DeckExtensions
    {
     
        /// <summary>
        /// Shuffle the cards in the deck. Returns a new deck with cards shuffled.
        /// </summary>
        public static Deck Shuffle(this Deck deck)
        {
            var newDeck = (Deck)deck.Clone();

            newDeck.Cards.Shuffle();

            return newDeck;
        }
    }
}