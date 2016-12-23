using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Utilities;

namespace AdventOfCode.Solutions
{
    public class Day7
    {
        private Regex _abba = new Regex(@"(\w)(\w)\2\1(?!\])");
        private Regex _abbaInsideHyperNet = new Regex(@"(\w)(\w)\2\1\w*(?=\])");

        public bool SupportsTLS(string input)
        {
            //look for Autonomous Bridge Bypass Annotation outside of hypernet sequences
            if (_abbaInsideHyperNet.IsMatch(input)) return false;

            var abbaMatches = _abba.Matches(input);
            if (abbaMatches.Count == 0) return false;

            //if we've matched and it's all the same letter then discard.
            foreach (Match match in abbaMatches)
            {
                if (match.Groups[1].Value == match.Groups[2].Value) return false;
            }
            return true;
        }

        public int Part1()
        {
            var data = FileReader.ReadFile("day7 ip addresses.txt");
            return data.Where(SupportsTLS).Count();
        }
    }
}
