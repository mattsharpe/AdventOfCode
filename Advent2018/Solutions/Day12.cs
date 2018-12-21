using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Advent2018.Solutions
{
    class Day12
    {
        public string InitialState { get; set; } = ".#..##..#.....######.....#....####.##.#.#...#...##.#...###..####.##.##.####..######......#..##.##.##";
        public Dictionary<string,string> Rules = new Dictionary<string, string>();

        public void ParseRules(string[] rules)
        {
            Rules = rules.Select(x => x.Split(" ")).ToDictionary(x => x[0], x => x[2]);
        }

        public PlantGeneration SolveForGenerations(int generations)
        {
            var result = new PlantGeneration {PlantPots = InitialState};
            
            return Enumerable.Range(0, generations).Aggregate(result, (current, generation) => EvolveGeneration(current));
        }

        public long CountPlantsBasedOnPattern(long generations)
        {
            if (generations <= 100)
                return CountPlants(SolveForGenerations(Convert.ToInt32(generations)));

            var hundred = CountPlants(SolveForGenerations(100));

            var stableState = CountPlants(SolveForGenerations(101)) - hundred;
            
            long result = (generations - 100) * stableState + hundred;
            
            return result;
        }

        public PlantGeneration EvolveGeneration(PlantGeneration generation)
        {
            var pots = $"....{generation.PlantPots}....";
            //foreach pot (where there are at least 2 pots before it or after it)
            //get the pot sequence i-2, i-1, i, i+1, i+2
            //lookup the rule 
            //append the answer to the output
            //also need to track the offset...
            var builder = new StringBuilder();
            for (var i = 2; i < pots.Length-2; i++)
            {
                var pot = Enumerable.Range(-2, 5).Aggregate(new StringBuilder(),(sb,x)=> sb.Append(pots[i + x])).ToString();
                builder.Append(Rules.TryGetValue(pot, out var plant) ? plant : ".");
            }

            var next = builder.ToString();
            
            var result  = new PlantGeneration
            {
                Offset = generation.Offset,
                PlantPots = next
            };
            
            result.Offset -= 2;
            
            return result;
        }

        public long CountPlants(PlantGeneration generation)
        {
            return Enumerable.Range(0, generation.PlantPots.Length)
                .Sum(x => generation.PlantPots[x] == '#' ? x + generation.Offset : 0);
        }
    }

    public class PlantGeneration
    {
        public int Offset { get; set; }
        public string PlantPots { get; set; }
    }
}
