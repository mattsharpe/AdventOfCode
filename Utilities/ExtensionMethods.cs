using System;
using System.Collections.Generic;

namespace AdventOfCode.Utilities
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