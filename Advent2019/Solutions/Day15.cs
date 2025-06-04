using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advent2019.Solutions
{
    class Day15
    {
        public bool InteractiveMode { get; set; }
        private IntCodeComputer _computer;
        private readonly Dictionary<(int x, int y), int> _map = new Dictionary<(int, int), int>();
        private RobotDirection _currentDirection = RobotDirection.North;
        private (int x, int y) _currentLocation;
        private (int x, int y) _oxygenLocation;

        private readonly Dictionary<RobotDirection, (int x, int y, RobotDirection reverse)> _displacement =
            new Dictionary<RobotDirection, (int x, int y, RobotDirection reverse)>
            {
                {RobotDirection.North, (0, -1, RobotDirection.South)},
                {RobotDirection.East, (1, 0, RobotDirection.West)},
                {RobotDirection.South, (0, 1, RobotDirection.North)},
                {RobotDirection.West, (-1, 0, RobotDirection.East)},
            };


        public void PrintMap()
        {
            if (InteractiveMode)
            {
                Console.Clear();
            }

            var minY = _map.Keys.Min(a => a.y);
            var maxY = _map.Keys.Max(a => a.y);

            var minX = _map.Keys.Min(a => a.x);
            var maxX = _map.Keys.Max(a => a.x);
            Console.WriteLine($"Map ranges from  {minX},{minY} to {maxX},{maxY}");

            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    if (_map.TryGetValue((x, y), out var value))
                    {
                        if (_currentLocation == (x, y))
                        {
                            switch (_currentDirection)
                            {
                                case RobotDirection.North:
                                    Console.Write("^");
                                    break;
                                case RobotDirection.East:
                                    Console.Write(">");
                                    break;
                                case RobotDirection.South:
                                    Console.Write("v");
                                    break;
                                case RobotDirection.West:
                                    Console.Write("<");
                                    break;
                            }
                        }
                        else if (value == 0)
                        {
                            Console.Write("#");
                        }
                        else if (value == 1)
                        {
                            Console.Write(".");
                        }
                        else if (value == 2)
                        {
                            Console.Write("$");
                        }
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }

            //Console.Write(sb.ToString());
        }

        public void BuildMaze(string input)
        {
            _computer = new IntCodeComputer();
            _computer.InitializePositions(input);

            Task.Run(_computer.RunProgram);

            (int x, int y) startLocation = (0, 0);
            _map.Add(startLocation, 1);
            ExploreCell(startLocation);

            PrintMap();
        }

        private int MoveRobot(RobotDirection direction)
        {
            _currentDirection = direction;
            _computer.Inputs.Add((int) direction);
            return (int) _computer.Outputs.Take();
        }

        private void ExploreCell((int x, int y) cell)
        {
            _currentLocation = cell;
            if (InteractiveMode)
                PrintMap();

            foreach (var move in _displacement)
            {
                var next = (cell.x + move.Value.x, cell.y + move.Value.y);
                //if we've already explored here
                if (_map.ContainsKey(next)) continue;

                var moveResult = MoveRobot(move.Key);
                _map.Add(next, moveResult);

                //hit a wall so stop.
                if (moveResult == 0) continue;

                ExploreCell(next);
                MoveRobot(move.Value.reverse);

                //if we've not found O2, move on to the next square
                if (moveResult != 2) continue;

                _map[next] = 2;
                _oxygenLocation = next;
            }
        }

        private Dictionary<(int x, int y), int> ShortestPaths((int x, int y) startPoint)
        {
            var toExplore = new Queue<(int x, int y)>();
            var explored = new HashSet<(int x, int y)>();
            toExplore.Enqueue(startPoint);
            var shortestPaths = new Dictionary<(int x, int y), int>
            {
                {startPoint, 0}
            };

            while (toExplore.Count > 0)
            {
                var current = toExplore.Dequeue();
                var possiblePoints = _displacement.Select(move => (x: current.x + move.Value.x, y: current.y + move.Value.y));

                foreach (var point in possiblePoints)
                {
                    if (_map[point] == 0 || explored.Contains(point)) continue;
                    shortestPaths[point] = shortestPaths[current] + 1;
                    toExplore.Enqueue(point);
                }

                explored.Add(current);
            }

            return shortestPaths;
        }


        public int TimeToFillWithOxygen()
        {
            return ShortestPaths(_oxygenLocation).Max(x=>x.Value);
        }

        public int FindPathToOxygen()
        {
            var result = ShortestPaths((0, 0))[_oxygenLocation];
            return result;
        }
    }

    enum RobotDirection
    {
        North = 1,
        South = 2,
        West = 3,
        East = 4
    }
}