using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2015.Solutions
{
    class Day06
    {
        private int[,] _lights = new int[1000, 1000];

        public void PrintLights()
        {
            for (int y = 0; y < _lights.GetUpperBound(1); y++)
            {
                for (int x = 0; x < _lights.GetUpperBound(0); x++)
                {
                    Console.Write(_lights[x,y]);
                }
            }
        }

        public int CountLit()
        {
            return _lights.Cast<int>().Count(x=>x==1);
        }

        public int SumLights()
        {
            return _lights.Cast<int>().Sum(x=>x);
        }

        public void ProcessInstructions(string[] instructions, bool part2 = false)
        {
            var parseInstruction = new Regex(@"(turn off|toggle|turn on) (\d*,\d*) through (\d*,\d*)");
            //turn off 994,939 through 998,988
            //toggle 467,662 through 555,957
            //turn on 952,417 through 954,845
            foreach (var instruction in instructions)
            {
                var match = parseInstruction.Match(instruction);
                var command = match.Groups[1].Value;
                var start = new Coordinate(match.Groups[2].Value);
                var stop = new Coordinate(match.Groups[3].Value);
                
                switch (command)
                {
                    case "turn on":
                        TurnOn(start, stop, part2);
                        break;
                    case "turn off":
                        TurnOff(start, stop, part2);
                        break;
                    case "toggle":
                        Toggle(start, stop, part2);
                        break;
                }
            }
        }

        public void TurnOn(Coordinate start, Coordinate stop, bool part2)
        {
            PerformOperation(start, stop, (x,y) =>
            {
                if(part2)
                    _lights[x, y]++;
                else
                    _lights[x, y] = 1;
            });
        }

        public void TurnOff(Coordinate start, Coordinate stop, bool part2)
        {
            PerformOperation(start, stop, (x, y) =>
            {
                if (part2 && _lights[x,y] > 0)
                    _lights[x, y]--;
                else
                    _lights[x, y] = 0;
                
            });
        }

        public void Toggle(Coordinate start, Coordinate stop, bool part2)
        {
            PerformOperation(start, stop, (x, y) =>
            {
                if (part2)
                    _lights[x, y] = _lights[x, y] + 2;
                else
                    _lights[x, y] = _lights[x, y] == 0 ? 1 : 0;
            });
        }

        public void PerformOperation(Coordinate start, Coordinate stop, Action<int, int> action)
        {
            for (var y = start.Y; y <= stop.Y; y++)
            {
                for (var x = start.X; x <= stop.X; x++)
                {
                    action(x, y);
                }
            }
        }


    }

    struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(string input)
        {
            var parts = input.Split(',');
            X = Convert.ToInt32(parts[0]);
            Y = Convert.ToInt32(parts[1]);
        }
    }
}
