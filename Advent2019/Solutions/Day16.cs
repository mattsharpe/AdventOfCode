using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2019.Solutions
{
    class Day16
    {
        public string ProcessPhase(string input)
        {
            var numbers = input.Select(x=> Convert.ToInt32(x.ToString())).ToArray();
            var result = new List<int>();

            foreach (var digit in Enumerable.Range(0, input.Length))
            {
                var pattern = Pattern(digit).Skip(1);
                var dotProduct = numbers.Zip(pattern, (x1, x2) => x1 * x2).Sum();
                result.Add(Math.Abs(dotProduct) % 10);
            }

            return string.Join("", result);
        }


        private static IEnumerable<int> Pattern(int length)
        {
            //have to skip the first number so generate one more than asked for.
            length++;
            var sequence = new[] {0, 1, 0, -1};
            while (true)
            {
                foreach (var item in sequence)
                {
                    foreach (var count in Enumerable.Range(0, length))
                    {
                        yield return item;
                    }
                }
            }
        }

        public string RunPhases(string input, int count)
        {
            foreach (var i in Enumerable.Range(0,count))
            {
                input = ProcessPhase(input);    
            }

            return input.Substring(0,8);
        }
        
    }
}
