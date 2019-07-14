using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2018.Solutions
{
    class Day05
    {
        public string ProcessPolymerReaction(string input)
        {
            //build a stack of processed letters, top of the stack is the next to compare against
            var stack = new Stack<char>();
            foreach (var current in input)
            {
                var previous = stack.Count > 0 ? stack.Peek() : ' ';
                
                if (current <= 'Z' && previous == current + 32 || current >= 'a' && previous == current - 32)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(current);
                }
            }

            return string.Join("", stack.Reverse());
        }

        public int FindShortestPolymer(string polymer)
        {
            return Enumerable.Range(65, 24).Select(x =>
                ProcessPolymerReaction(polymer.Replace(Convert.ToChar(x).ToString(), "", StringComparison.CurrentCultureIgnoreCase)).Length)
                .Min();
        }
    }
}
