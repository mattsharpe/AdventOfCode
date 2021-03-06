﻿using System;
using System.Linq;

namespace Advent2015.Solutions
{
    class Day18
    {

        private int[,] _lights;

        public int CountLit => _lights.Cast<int>().Count(x => x == 1);
        public bool FixedCorners { get; set; }

        public void PrintLights()
        {
            for (var y = 0; y <= _lights.GetUpperBound(1); y++)
            {
                for (var x = 0; x <= _lights.GetUpperBound(0); x++)
                {
                    Console.Write(_lights[x, y] == 1 ? "#" : ".");
                }

                Console.WriteLine();
            }
        }

        public void ParseLights(string[] input)
        {
            _lights = new int[input.Length, input.Length];

            for (var i = 0; i != input.Length; i++)
            {
                var line = input[i];
                for (var j = 0; j != line.Length; j++)
                {
                    //Console.WriteLine(line[j]);
                    _lights[j, i] = line[j] == '#' ? 1 : 0;
                }
            }
            if (FixedCorners)
                TurnCornersOn();
        }

        public void TurnCornersOn()
        {
            _lights[0, 0] = 1;
            _lights[0, _lights.GetUpperBound(1)] = 1;
            _lights[_lights.GetUpperBound(0), 0] = 1;
            _lights[_lights.GetUpperBound(0), _lights.GetUpperBound(1)] = 1;
        }

        public void Step()
        {
            var nextCycle = new int[_lights.GetUpperBound(0) + 1, _lights.GetUpperBound(0) + 1];
            for (var y = 0; y <= _lights.GetUpperBound(1); y++)
            {
                for (var x = 0; x <= _lights.GetUpperBound(0); x++)
                {
                    var nearby = NumberOfOnNeighbours(x, y);
                    var current = _lights[x, y];
                    var lit = false;
                    if (current == 1)
                    {
                        if (nearby == 2 || nearby == 3)
                        {
                            lit = true;
                        }
                    }
                    else
                    {
                        if (nearby == 3)
                            lit = true;
                    }

                    nextCycle[x, y] = lit ? 1 : 0;
                }
            }
            _lights = nextCycle;
            if (FixedCorners)
            {
                TurnCornersOn();
            }
        }

        public int NumberOfOnNeighbours(int x, int y)
        {
            int SafeGet(int a, int b)
            {
                if (a < 0 || b < 0 ||
                    a > _lights.GetUpperBound(0) ||
                    b > _lights.GetUpperBound(1))
                {
                    return 0;
                }

                return _lights[a, b];
            }

            return
                SafeGet(x - 1, y - 1) +
                SafeGet(x - 1, y) +
                SafeGet(x - 1, y + 1) +
                SafeGet(x, y - 1) +
                SafeGet(x, y + 1) +
                SafeGet(x + 1, y - 1) +
                SafeGet(x + 1, y) +
                SafeGet(x + 1, y + 1);
        }
    }
}