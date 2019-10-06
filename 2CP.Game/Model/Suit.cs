using _2CP.Game.Attributes;

namespace _2CP.Game.Model
{
    public enum Suit
    {
        [ShortName("♦")]
        Diamonds =1,
        [ShortName("♥")]
        Hearts =2,
        [ShortName("♣")]
        Clubs =3,
        [ShortName("♠")]
        Spades =4
    }
}