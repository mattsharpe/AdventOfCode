using System;
using System.Linq;

namespace Advent2015.Solutions
{
    class Day24
    {
        public decimal Solve(int[] input)
        {
            var sum = input.Sum();
            var weightLimit = sum / 3;

            return MinimumQuantumEntanglement(input, weightLimit, 0, 1, 0).result;
        }

        public decimal SolvePart2(int[] input)
        {
            var sum = input.Sum();
            var weightLimit = sum / 4;

            return MinimumQuantumEntanglement(input, weightLimit, 0, 1, 0).result;
        }

        private (decimal result, bool valid) MinimumQuantumEntanglement(int[] parcels, int weightLimit, int i, decimal quantumEntanglement, int totalWeight)
        {
            if (totalWeight == weightLimit)
                return (quantumEntanglement, true);
            
            if (i >= parcels.Length || totalWeight > weightLimit)
            {
                return (0, false);
            }
            var packed = MinimumQuantumEntanglement(parcels, weightLimit, i + 1, quantumEntanglement * parcels[i], totalWeight + parcels[i]);
            var remaining = MinimumQuantumEntanglement(parcels, weightLimit, i + 1, quantumEntanglement, totalWeight);

            if (!packed.valid) return remaining;
            if (!remaining.valid) return packed;

            return (Math.Min(packed.result, remaining.result), true);
        }
    }
}
