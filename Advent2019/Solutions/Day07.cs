using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent2019.Solutions
{
    class Day07
    {
        public long RunAmplifiers(int[] phases, string program)
        {
            var amplifiers = BuildAmplifiers(phases, program);
            amplifiers.ForEach(x => x.RunProgram());

            return amplifiers.Last().Outputs.Single();
        }

        public long FindLargestSignal(string program)
        {
            return GetPermutations(new[] {0, 1, 2, 3, 4}, 5)
                .Select(x=> RunAmplifiers(x.ToArray(), program))
                .OrderByDescending(x=>x)
                .First();
        }

        public IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new [] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new [] { t2 }));
        }

        private List<IntCodeComputer> BuildAmplifiers(int[] phases, string program, bool loopback = false)
        {
            var amplifiers = new List<IntCodeComputer>();
            for (var index = 0; index < phases.Length; index++)
            {
                var phase = phases[index];
                amplifiers.Add(new IntCodeComputer(program, phase, 
                    index > 0 ? amplifiers[index-1].Outputs : null));
            }

            if (loopback)
            {
                amplifiers.Last().Outputs = amplifiers.First().Inputs;
            }

            amplifiers.First().Inputs.Enqueue(0);
            
            return amplifiers;
        }

        public async Task<long> RunFeedbackLoopAsync(int[] phases, string program)
        {
            var amplifiers = BuildAmplifiers(phases, program, true);

            var tasks = amplifiers.Select(x => Task.Run(x.RunProgram)).ToList();
            
            await Task.WhenAll(tasks);

            return amplifiers.Last().Outputs.First();
        }

        public long FindLargestSignalWithFeedbackLoop(string program)
        {
            var tasks = GetPermutations(new[] {9, 8, 7, 6, 5}, 5)
                .Select(async x => await RunFeedbackLoopAsync(x.ToArray(), program));

            var result = Task.WhenAll(tasks);
            return result.Result.Max();
        }
    }
}
