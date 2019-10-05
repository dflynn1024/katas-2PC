using System.Diagnostics;
using JetBrains.Annotations;

namespace _2CP.Game.Extensions
{
    internal static class ObjectExtensions
    {
        /// <summary>
        /// Returns true if object is null.
        /// </summary>
        [DebuggerStepThrough]
        [ContractAnnotation("obj:null => true")]
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// Returns true if object is NOT null.
        /// </summary>
        [DebuggerStepThrough]
        [ContractAnnotation("obj:null => false")]
        public static bool IsNotNull(this object obj)
        {
            return !obj.IsNull();
        }
    }
}