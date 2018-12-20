using System;

namespace Advent2018.Solutions
{
    public class PowerCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Power { get; set; }
        public int Size { get; set; }
    }

    class Day11
    {
        private readonly int[,] _powerGrid = new int[300, 300];

        public int CalculatePower(int x, int y)
        {
            var rackId = x + 10;
            return (rackId * y + SerialNumber) * rackId / 100 % 10 - 5;
        }

        public int SerialNumber { get; set; }

        public void PopulateGrid()
        {
            Iterate(300, (x, y) =>  _powerGrid[x, y] = CalculatePower(x, y));
        }

        void Iterate(int range, Action<int, int> action)
        {
            for (var x = 0; x < range; x++)
            {
                for (var y = 0; y < range; y++)
                {
                    action(x, y);
                }
            }
        }

        public PowerCell Solve(int size = 3)
        {
            PopulateGrid();
            var result = new PowerCell();
            
            var grid = new int[300, 300];
            for (var i = 1; i <= size; i++)
            {
                //build up the power grid
                Iterate(300 - i, (x, y) =>
                {
                    grid[x, y] += _powerGrid[x + i - 1, y];
                });

                Iterate(300 - i, (x, y) =>
                {
                    var power = 0;

                    for (var j = 0; j < i; j++)
                    {
                        power += grid[x, y + j];
                    }

                    if (power > result.Power)
                    {
                        result.Power = power;
                        result.X = x;
                        result.Y = y;
                        result.Size = i;
                    }
                });
            }
            return result;
        }
    }
}
