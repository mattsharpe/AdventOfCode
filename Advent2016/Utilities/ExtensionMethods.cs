using System;
using System.Collections.Generic;

namespace Advent2016.Utilities
{
    public static class ExtensionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var thing in collection)
            {
                action(thing);
            }
        }
    }
}