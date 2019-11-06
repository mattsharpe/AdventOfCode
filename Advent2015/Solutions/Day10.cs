using System.Linq;
using System.Text;

namespace Advent2015.Solutions
{
    class Day10
    {
        public string LookAndSay(string input)
        {
            
            var output = new StringBuilder();
            var character = input.First();
            var count = 0;
            input += " ";
            foreach (var number in input)
            {
                if (number != character)
                {
                    output.Append($"{count}{character}");
                    count = 1;
                    character = number;
                }
                else
                {
                    count++;
                }
                
            }
            return output.ToString();
        }

        public int Solve(string input, int iterations = 40)
        {
            input = Enumerable.Range(0, iterations).Aggregate(input, (current, x) => LookAndSay(current));

            return input.Length;
        }
    }
}
