using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Utilities;

namespace AdventOfCode.Solutions
{
    public class Day6
    {
        public string ErrorCorrect(string[] input)
        {
            Dictionary<char,int>[] lookup = new Dictionary<char, int>[input.First().Length];

            foreach(var message in input)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    var letter = message[i];
                    if (lookup[i] == null)
                    {
                        lookup[i] = new Dictionary<char, int>();
                    }
                    if (lookup[i].ContainsKey(letter))
                    {
                        lookup[i][letter]++;
                    }
                    else
                    {
                        lookup[i][letter] = 1;
                    }
                }
            }

            var sb = new StringBuilder();
            foreach (var character in lookup)
            {
                sb.Append(character.OrderByDescending(x => x.Value).First().Key);
            }
            return sb.ToString();
        }

        public string Challenge1()
        {
            var input = FileReader.ReadFile("day6 messages.txt");
            return ErrorCorrect(input);
        }
   
    }
}
