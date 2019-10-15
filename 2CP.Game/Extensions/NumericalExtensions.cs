using System;
using System.Diagnostics;

namespace _2CP.Game.Extensions
{
    public static class NumericalExtensions
    {
        /// <summary>
        /// The difference between 2 integers.
        /// </summary>
        [DebuggerStepThrough]
        public static int Difference(this int left, int right)
        {
            return Math.Abs(left - right);
        }
    }
}
