using System;
using System.Linq;
using _2CP.Game.Extensions;

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
            return $"{nameof(Rank).First()}{nameof(Suit).First()}";
        }
    }
}