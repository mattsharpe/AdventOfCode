using System;
using System.Collections.Generic;

namespace Advent2018.Utilities
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var x in list)
            {
                action(x);
            }
        }
    }
}
