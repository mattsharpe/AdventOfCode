using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2015.Solutions
{
    class Day19
    {
        private List<(string key, string replacement)> _substitutions = new List<(string key, string replacement)>();

        public HashSet<string> GenerateReplacements(string input)
        {
            HashSet<string> options = new HashSet<string>();

            foreach (var substitution in _substitutions)
            {
                var matches = Regex.Matches(input, substitution.key); //RegexOptions Compiled
                foreach (Match  match in matches)
                {
                    options.Add(input.Remove(match.Index, match.Length)
                        .Insert(match.Index, substitution.replacement));
                }
            }

            return options;
        }

        public void ParseSubstitutionRules(string[] rules)
        {
            _substitutions = rules.Select(x =>
            {
                var match = Regex.Match(x, @"(\w+)\s=\>\s(\w+)");
                return (match.Groups[1].Value, match.Groups[2].Value);
            }).ToList();
        }
    }
}
