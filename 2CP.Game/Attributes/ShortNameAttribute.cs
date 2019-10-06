using System;

namespace _2CP.Game.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ShortNameAttribute : Attribute
    {
        public string Name { get; }

        public ShortNameAttribute(string name)
        {
            Name = name;
        }
    }
}