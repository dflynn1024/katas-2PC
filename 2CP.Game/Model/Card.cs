using System;

namespace _2CP.Game.Model
{
    public class Card : ICloneable
    {
        public Rank Rank { get; }
        public Suit Suit { get; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public object Clone()
        {
            return new Card(Rank, Suit);
        }
    }
}