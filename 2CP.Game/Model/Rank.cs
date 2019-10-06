using _2CP.Game.Attributes;

namespace _2CP.Game.Model
{
    public enum Rank
    {
        [ShortName("2")]
        Two=2,
        [ShortName("3")]
        Three =3,
        [ShortName("4")]
        Four =4,
        [ShortName("5")]
        Five =5,
        [ShortName("6")]
        Six =6,
        [ShortName("7")]
        Seven =7,
        [ShortName("8")]
        Eight =8,
        [ShortName("9")]
        Nine =9,
        [ShortName("T")]
        Ten =10,
        [ShortName("J")]
        Jack =11,
        [ShortName("Q")]
        Queen =12,
        [ShortName("K")]
        King =13,
        [ShortName("A")]
        Ace =14
    }
}