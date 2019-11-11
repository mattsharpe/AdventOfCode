
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2015.Solutions
{
    class Day13
    {
        private Dictionary<string, Dictionary<string, int>> _dinerPreferences;

        public void CalculatePotentialHappiness(string[] sampleData)
        {
            BuildAttendeeList(sampleData);
            GetPermutations(_dinerPreferences.Keys, _dinerPreferences.Count);
        }

        public void CalculatePotentialHappinessWithMatt(string[] sampleData)
        {
            BuildAttendeeList(sampleData);
            var guests = _dinerPreferences.Keys.ToList();

            foreach (var diner in _dinerPreferences)
            {
                diner.Value.Add("Matt", 0);
            }
            
            _dinerPreferences.Add("Matt", guests.ToDictionary(x=>x,y=>0));

            GetPermutations(_dinerPreferences.Keys, _dinerPreferences.Count);
        }

        public IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        
        public int CalculatePreference(List<string> paths)
        {
            var score = 0;

            for (var i = 0; i != paths.Count - 1; i++)
            {
                score += _dinerPreferences[paths[i]][paths[i + 1]];
                score += _dinerPreferences[paths[i + 1]][paths[i]];
            }

            //handle the loop round
            score += _dinerPreferences[paths.Last()][paths.First()];
            score += _dinerPreferences[paths.First()][paths.Last()];
            return score;
            
        }

        private void BuildAttendeeList(string[] input)
        {
            _dinerPreferences = input.Select(x => x.Split(' ').First())
                .Distinct().ToDictionary(x=>x, x=> new Dictionary<string, int>());

            foreach (var line in input)
            {
                var split = line.Split(' ');

                var diner1 = split[0];
                var diner2 = split[10].Replace(".", "");
                var opinion = Convert.ToInt32(split[3]);
                if (split[2] == "lose")
                {
                    opinion *= -1;
                }

                _dinerPreferences[diner1][diner2] = opinion;
            }
        }

        public int FindBestOption()
        {
            var options = GetPermutations(_dinerPreferences.Keys, _dinerPreferences.Count);
            return options.Max(x => CalculatePreference(x.ToList()));
        }
    }
}
