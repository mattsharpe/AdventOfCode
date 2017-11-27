using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode2016.Utilities;

namespace AdventOfCode2016.Solutions
{
    /*
    --- Day 6: Signals and Noise ---

Something is jamming your communications with Santa. Fortunately, your signal is only partially jammed, and protocol in situations like this is to switch to a simple repetition code to get the message through.

In this model, the same message is sent repeatedly. You've recorded the repeating message signal (your puzzle input), but the data seems quite corrupted - almost too badly to recover. Almost.

All you need to do is figure out which character is most frequent for each position. For example, suppose you had recorded the following messages:

eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar
The most common character in the first column is e; in the second, a; in the third, s, and so on. Combining these characters returns the error-corrected message, easter.

Given the recording in your puzzle input, what is the error-corrected version of the message being sent?

Your puzzle answer was ursvoerv.

The first half of this puzzle is complete! It provides one gold star: *

--- Part Two ---

Of course, that would be the message - if you hadn't agreed to use a modified repetition code instead.

In this modified code, the sender instead transmits what looks like random data, but for each character, the character they actually want to send is slightly less likely than the others. Even after signal-jamming noise, you can look at the letter distributions in each column and choose the least common letter to reconstruct the original message.

In the above example, the least common character in the first column is a; in the second, d, and so on. Repeating this process for the remaining characters produces the original message, advent.

Given the recording in your puzzle input and this new decoding methodology, what is the original
    */
    public class Day6
    {
        public string ErrorCorrect(string[] input, string sortOrder = "desc")
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
                if(sortOrder == "desc")
                    sb.Append(character.OrderByDescending(x => x.Value).First().Key);
                else
                    sb.Append(character.OrderBy(x => x.Value).First().Key);
            }
            return sb.ToString();
        }

        public string Challenge1()
        {
            var input = FileReader.ReadFile("day6 messages.txt");
            return ErrorCorrect(input);
        }
        public string Challenge2()
        {
            var input = FileReader.ReadFile("day6 messages.txt");
            return ErrorCorrect(input, "asc");
        }
        
    }
}
