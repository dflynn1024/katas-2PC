using System.Diagnostics;
using JetBrains.Annotations;

namespace _2CP.Game.Extensions
{
    public static class StringExtensions
    {
        [DebuggerStepThrough]
        [ContractAnnotation("null => true")]
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        [DebuggerStepThrough]
        [ContractAnnotation("null => false")]
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        [DebuggerStepThrough]
        [ContractAnnotation("null => true")]
        public static bool IsNullOrWhitespace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        [DebuggerStepThrough]
        [ContractAnnotation("null => false")]
        public static bool IsNotNullOrWhitespace(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}