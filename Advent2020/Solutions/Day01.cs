using System.Linq;

namespace Advent2020.Solutions
{
    class Day01
    {
        public int ProductOfSum(int[] input)
        {
            var result = from x in input
                from y in input
                where x + y == 2020
                select x * y;

            return result.First();
        }

        public int GroupOfThree(int[] input)
        {
            var result = from x in input
                from y in input
                from z in input
                where x + y + z == 2020
                select x * y * z;

            return result.First();
        }
    }
}
