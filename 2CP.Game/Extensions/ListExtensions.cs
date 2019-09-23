using System;
using System.Collections.Generic;

namespace _2CP.Game.Extensions
{
    public static class ListExtensions
    {
        private static readonly Random RandomNumberGenerator = new Random();

        /// <summary>
        /// Shuffle a the order or items in a list.
        /// </summary>
        /// <remarks>
        /// Based on a Fisher-Yates shuffle. https://stackoverflow.com/questions/273313/randomize-a-list
        /// </remarks>
        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;

            while (n > 1)
            {
                n--;
                var k = RandomNumberGenerator.Next(n + 1);
                list.Swap(k, n);
            }
        }

        /// <summary>
        /// Swap list item in position x with item in position y.
        /// </summary>
        public static void Swap<T>(this IList<T> list, int x, int y)
        {
            var value = list[x];
            list[x] = list[y];
            list[y] = value;
        }
    }
}