using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2015.Solutions
{
    class Day16
    {
        private static bool Equals(string test, string property, int value)
        {
            var regex = new Regex($@"{property}: (\d+)");
            if (!regex.IsMatch(test)) return true;
            return Convert.ToInt32(regex.Match(test).Groups[1].Value) == value;
        }

        private static bool GreaterThan(string test, string property, int value)
        {
            var regex = new Regex($@"{property}: (\d+)");
            if (!regex.IsMatch(test)) return true;
            return Convert.ToInt32(regex.Match(test).Groups[1].Value) > value;
        }

        private static bool LessThan(string test, string property, int value)
        {
            var regex = new Regex($@"{property}: (\d+)");
            if (!regex.IsMatch(test)) return true;
            return Convert.ToInt32(regex.Match(test).Groups[1].Value) < value;
        }

        public int FilterAuntSue(string[] input, bool part2 = false)
        {
            
            var filters = new List<Func<string, bool>>
            {
                x => Equals(x, "children", 3),
                x => part2 ? GreaterThan(x, "cats", 7) : Equals(x, "cats", 7),
                x => Equals(x, "samoyeds", 2),
                x => part2 ? LessThan(x, "pomeranians", 3) : Equals(x, "pomeranians", 3),
                x => Equals(x, "akitas", 0),
                x => Equals(x, "vizslas", 0),
                x => part2 ? LessThan(x, "goldfish", 5) : Equals(x, "goldfish", 5),
                x => part2 ? GreaterThan(x, "trees", 3) : Equals(x, "trees", 3),
                x => Equals(x, "cars", 2),
                x => Equals(x, "perfumes", 1),
            };

            var filtered = ApplyFilters(input, filters);

            return Convert.ToInt32(filtered.Single().Split(' ')[1].Replace(":", ""));

        }

        public string[] ApplyFilters(string[] input,  List<Func<string, bool>> filters)
        {
            foreach (var filter in filters)
            {
                input = input.Where(filter).ToArray();
            }

            return input;
        }
    }

}
