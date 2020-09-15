using System;

namespace Advent2015.Solutions
{
    class Day20
    {
        public int Solve(int input)
        {
            var houses = new int[1000000];

            for (var i = 1; i < houses.Length; i++) 
            {
                for(var j = i; j< houses.Length; j+= i) 
                {
                    houses[j] += i * 10;
                }
            }

            for (var i = 0; i < houses.Length; i++) {
                if (houses[i] >= input) {
                    return i;
                }
            }

            return -1;
        }

        public int Part2(int input)
        {
            var houses = new int[1000000];

            for (var i = 1; i < houses.Length; i++) {
                var housesVisited = 0;
            
                for(var j = i; j< houses.Length; j+= i)
                {
                    if (housesVisited == 50) break;
                    houses[j] += i * 11;
                    housesVisited++;
                }
            
            }

            for (var i = 0; i < houses.Length; i++) {
                if (houses[i] >= input) {
                    return i;
                }
            }
            return -1;
        }

    }
}
