using System;
using _2CP.Game.Extensions;

namespace _2CP.Game.Model
{
    public class Card : ICloneable
    {
        public Rank Rank { get; }
        public Suit Suit { get; }
        public string ShortName => $"{Rank.ShortName()}{Suit.ShortName()}";
    
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public Card(string shortName)
        {
            if(shortName.Length != 2)
                throw new ArgumentException($"ShortName must be 2 characters only. '{shortName}' has {shortName.Length} chars!");

            Rank = shortName[0].FromShortName<Rank>();
            Suit = shortName[1].FromShortName<Suit>();
        }

        public object Clone()
        {
            return new Card(Rank, Suit);
        }

        public override string ToString()
        {
            return this.ShortName;
        }

        public override bool Equals(object obj)
        {
            return this.Equals((Card)obj);
        }

        protected bool Equals(Card other)
        {
            return Rank == other.Rank && Suit == other.Suit;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Rank * 397) ^ (int) Suit;
            }
        }
    }
}