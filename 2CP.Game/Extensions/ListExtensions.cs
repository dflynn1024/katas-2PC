using System.Collections.Generic;
using System.Diagnostics;

namespace _2CP.Game.Extensions
{
    internal static class ListExtensions
    {
        /// <summary>
        /// Swap list item in position x with item in position y.
        /// </summary>
        [DebuggerStepThrough]
        public static void Swap<T>(this IList<T> list, int x, int y)
        {
            var value = list[x];
            list[x] = list[y];
            list[y] = value;
        }
    }
}