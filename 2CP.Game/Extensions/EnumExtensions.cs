using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using _2CP.Game.Attributes;

namespace _2CP.Game.Extensions
{
    internal static class EnumExtensions
    {
        [DebuggerStepThrough]
        public static IEnumerable<TEnum> GetValues<TEnum>()
            where TEnum : Enum
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }

        /// <summary>
        /// Get Enum value's short name.
        /// </summary>
        [DebuggerStepThrough]
        public static string ShortName(this Enum value)
        {
            return value.IsNull() 
                ? default 
                : value.GetType().GetField(value.ToString())?.GetCustomAttribute<ShortNameAttribute>()?.Name;
        }

        /// <summary>
        /// Get Enum value from short name
        /// </summary>
        [DebuggerStepThrough]
        public static TEnum FromShortName<TEnum>(this string shortName)
            where TEnum : struct, IConvertible
        {
            if (shortName.IsNullOrEmpty() || shortName.IsNullOrWhitespace())
                return default;

            return new TEnum().GetEnumByShortName(shortName);
        }

        /// <summary>
        /// Get Enum value from short name
        /// </summary>
        [DebuggerStepThrough]
        public static TEnum FromShortName<TEnum>(this char shortName)
            where TEnum : struct, IConvertible
        {
            return new TEnum().GetEnumByShortName(shortName.ToString());
        }

        #region Private Helpers

        private static TEnum GetEnumByShortName<TEnum>(this TEnum source, string shortName)
            where TEnum : struct, IConvertible
        {
            var match = source.GetType().GetFields()
                .FirstOrDefault(f => f.GetFieldAttributes<ShortNameAttribute>().Any(a => a.Name == shortName));

            if (match.IsNull())
                throw new Exception($"{nameof(source)} does not contain a value with short name: {shortName}");

            return (TEnum)match.GetValue(null);
        }

        #endregion


    }
}