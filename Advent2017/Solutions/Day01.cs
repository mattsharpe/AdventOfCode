using System;

namespace Advent2017.Solutions
{
    class Day01
    {
        public int GetSum(string sequence)
        {
            int sum = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                int current = Convert.ToInt32(sequence[i].ToString());
                int next = Convert.ToInt32(i == sequence.Length - 1 ? sequence[0].ToString() : sequence[i + 1].ToString());
                if (current == next) sum += current;
            }
            return sum;
        }

        public int GetSum2(string sequence)
        {
            int sum = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                int current = Convert.ToInt32(sequence[i].ToString());

                int nextIndex = ((sequence.Length / 2) + i) % sequence.Length;
                int next = Convert.ToInt32(sequence[nextIndex].ToString());

                if (current == next) sum += current;
            }
            return sum;
        }
    }
}
