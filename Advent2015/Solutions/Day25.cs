

using System.Runtime.CompilerServices;

namespace Advent2015.Solutions
{
    class Day25
    {
        public long Solve(int row, int column)
        {
            long a = 20151125;
            int x = 1;
            int y = 1;

            while (x != row || y != column)
            {
                x--;
                y++;
                if (x == 0)
                {
                    x = y;
                    y = 1;
                }
                a = (a * 252533L) % 33554393L;
            }

            return a;
        }

    }
}
