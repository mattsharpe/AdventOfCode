using System;
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

        public int ShortestPathToE(string molecule)
        {            
            var steps = 0;
            _substitutions = _substitutions.OrderByDescending(x => x.replacement.Length).ToList();
            while (!molecule.Equals("e"))
            {
                foreach (var (key, value) in  _substitutions)
                {
                    if (molecule.Contains(value))
                    {
                        //if this replacement would yield an e but not clear the whole string then we're stuck
                        if (key == "e" && value.Length != molecule.Length)
                        {
                            continue;
                        }
                        var regex = new Regex(value);
                        molecule = regex.Replace(molecule, key, 1);
                        Console.WriteLine(molecule);
                        steps++;
                    }
                }
            }
            return steps;
        }
    }
}
