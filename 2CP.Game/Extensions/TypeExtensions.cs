using System;
using System.Collections.Generic;
using System.Reflection;

namespace _2CP.Game.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<TAttrib> GetFieldAttributes<TAttrib>(this FieldInfo field)
            where TAttrib : Attribute
        {
            return field.GetCustomAttributes<TAttrib>(true);
        }
    }
}