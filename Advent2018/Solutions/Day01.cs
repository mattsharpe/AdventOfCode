using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2018.Solutions
{
    public class Day01
    {
        public int CurrentFrequency { get; set; }
        public HashSet<int> VisitedFrequencies = new HashSet<int>();

        public int ProcessInstructions(string[] input)
        {
            return input.Sum(Convert.ToInt32);
        }

        public int? FindFirstVisited(string[] input)
        {
            VisitedFrequencies.Add(CurrentFrequency);
            int? firstRevisit = null;
            foreach (var line in input)
            {
                var delta = Convert.ToInt32(line);
                CurrentFrequency += delta;
                if (VisitedFrequencies.Contains(CurrentFrequency))
                {
                    firstRevisit = CurrentFrequency;
                    return firstRevisit.Value;
                }

                VisitedFrequencies.Add(CurrentFrequency);

            }

            if (!firstRevisit.HasValue)
                return FindFirstVisited(input);

            return firstRevisit.Value;
        }
    }
}
