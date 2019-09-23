using System;
using System.Collections.Generic;
using System.Linq;

namespace _2CP.Game.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<TEnum> GetValues<TEnum>()
            where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }
    }
}