using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2019.Solutions
{
    class Day07
    {
        public int RunAmplifiers(int[] phases, string program)
        {
            var amplifierA = new IntCodeComputer(program, phases[0]);
            var amplifierB = new IntCodeComputer(program, phases[1]);
            var amplifierC = new IntCodeComputer(program, phases[2]);
            var amplifierD = new IntCodeComputer(program, phases[3]);
            var amplifierE = new IntCodeComputer(program, phases[4]);
            
            amplifierA.Inputs.Enqueue(0);
            amplifierA.RunProgram();

            amplifierB.Inputs.Enqueue(amplifierA.Outputs.Single());
            amplifierB.RunProgram();

            amplifierC.Inputs.Enqueue(amplifierB.Outputs.Single());
            amplifierC.RunProgram();

            amplifierD.Inputs.Enqueue(amplifierC.Outputs.Single());
            amplifierD.RunProgram();

            amplifierE.Inputs.Enqueue(amplifierD.Outputs.Single());
            amplifierE.RunProgram();

            return amplifierE.Outputs.Single();

        }

        public int FindLargestSignal(string program)
        {
            return GetPermutations(new[] {0, 1, 2, 3, 4}, 5)
                .Select(x=> RunAmplifiers(x.ToArray(), program))
                .OrderByDescending(x=>x)
                .First();
        }

        public IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

    }
}
