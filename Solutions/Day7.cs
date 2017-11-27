using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Advent2016.Utilities;

namespace Advent2016.Solutions
{
    /*
    --- Day 7: Internet Protocol Version 7 ---

While snooping around the local network of EBHQ, you compile a list of IP addresses (they're IPv7, of course; IPv6 is much too limited). You'd like to figure out which IPs support TLS (transport-layer snooping).

An IP supports TLS if it has an Autonomous Bridge Bypass Annotation, or ABBA. An ABBA is any four-character sequence which consists of a pair of two different characters followed by the reverse of that pair, such as xyyx or abba. However, the IP also must not have an ABBA within any hypernet sequences, which are contained by square brackets.

For example:

abba[mnop]qrst supports TLS (abba outside square brackets).
abcd[bddb]xyyx does not support TLS (bddb is within square brackets, even though xyyx is outside square brackets).
aaaa[qwer]tyui does not support TLS (aaaa is invalid; the interior characters must be different).
ioxxoj[asdfgh]zxcvbn supports TLS (oxxo is outside square brackets, even though it's within a larger string).
How many IPs in your puzzle input support TLS?

Your puzzle answer was 105.

The first half of this puzzle is complete! It provides one gold star: *

--- Part Two ---

You would also like to know which IPs support SSL (super-secret listening).

An IP supports SSL if it has an Area-Broadcast Accessor, or ABA, anywhere in the supernet sequences (outside any square bracketed sections), and a corresponding Byte Allocation Block, or BAB, anywhere in the hypernet sequences. An ABA is any three-character sequence which consists of the same character twice with a different character between them, such as xyx or aba. A corresponding BAB is the same characters but in reversed positions: yxy and bab, respectively.

For example:

aba[bab]xyz supports SSL (aba outside square brackets with corresponding bab within square brackets).
xyx[xyx]xyx does not support SSL (xyx, but no corresponding yxy).
aaa[kek]eke supports SSL (eke in supernet with corresponding kek in hypernet; the aaa sequence is not related, because the interior character must be different).
zazbz[bzb]cdb supports SSL (zaz has no corresponding aza, but zbz has a corresponding bzb, even though zaz and zbz overlap).
How many IPs in your puzzle input support SSL?

*/
    public class Day7
    {
        private Regex _abba = new Regex(@"(\w)(\w)\2\1(?!\])");
        private Regex _abbaInsideHyperNet = new Regex(@"(\w)(\w)\2\1\w*(?=\])");
        private Regex _babInsideHyperNet = new Regex(@"(\w)(\w)\1");
        private Regex _hypernet = new Regex(@"\[(\w*)\]");

        public bool SupportsTLS(string input)
        {
            //look for Autonomous Bridge Bypass Annotation outside of hypernet sequences
            if (_abbaInsideHyperNet.IsMatch(input)) return false;

            var abbaMatches = _abba.Matches(input);
            if (abbaMatches.Count == 0) return false;

            //if we've matched and it's all the same letter then discard.
            return abbaMatches.Cast<Match>()
                .All(match => match.Groups[1].Value != match.Groups[2].Value);
        }

        public bool SupportsSSL(string input)
        {
            var superNet = new List<string>();
            var hyperNet = new List<string>();

            var ipParts = _hypernet.Split(input);

            for (int i = 0; i < ipParts.Length; i++)
            {
                if (i%2 == 0)
                {
                    superNet.Add(ipParts[i]);
                }
                else
                {
                    hyperNet.Add(ipParts[i]);    
                }
            }
            //now we've got a list of supernets and hypernets
            var superNetAbas = superNet.SelectMany(FindAbas);
            var hypernetBabs = hyperNet.SelectMany(x => FindAbas(x).Select(ReverseABA));
            var intersection = hypernetBabs.Intersect(superNetAbas);
            
            var result = intersection.Any();

            return result;
        }

        private string ReverseABA(string aba)
        {
            return aba[1].ToString() + aba[0] + aba[1];
        }

        public List<string> FindAbas(string input)
        {
            var results = new List<string>();

            for (int index = 0; index < input.Length; index++)
            {
                if (index + 2 < input.Length && input[index] != input[index+1])
                {
                    var currentChar = input[index];
                    if (currentChar == input[index + 2])
                    {
                        string abba = $"{currentChar}{input[index + 1]}{input[index + 2]}";
                        results.Add(abba);
                    }
                }
            }
            
            return results;
        }

        public int Part1()
        {
            var data = FileReader.ReadFile("day7 ip addresses.txt");
            return data.Where(SupportsTLS).Count();
        }
        public int Part2()
        {
            var data = FileReader.ReadFile("day7 ip addresses.txt");
            var valid = data.Where(SupportsSSL);
            return valid.Count();
        }
    }
}
