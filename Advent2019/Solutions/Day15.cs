using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Advent2019.Solutions
{
    class Day15
    {
        public bool InteractiveMode { get; set; }
        private IntCodeComputer _computer;
        private readonly Dictionary<(long x, long y), long> _map = new Dictionary<(long, long), long>();
        private readonly HashSet<(long x, long y)> _unexplored = new HashSet<(long x, long y)>();
        private (long x, long y) _currentLocation = (0, 0);
        private RobotDirection _currentDirection = RobotDirection.North;
        

        private readonly Dictionary<RobotDirection, (int x, int y)> _displacement =
            new Dictionary<RobotDirection, (int x, int y)>
            {
                {RobotDirection.North, (0, -1)},
                {RobotDirection.East, (1, 0)},
                {RobotDirection.South, (0, 1)},
                {RobotDirection.West, (-1, 0)}
            };

        private readonly Dictionary<RobotDirection, List<RobotDirection>> _moveSequence =
            new Dictionary<RobotDirection, List<RobotDirection>>
            {
                {
                    RobotDirection.North, new List<RobotDirection> {RobotDirection.East, RobotDirection.North, RobotDirection.West, RobotDirection.South}
                },
                {  
                    RobotDirection.East, new List<RobotDirection> {RobotDirection.South, RobotDirection.East, RobotDirection.North, RobotDirection.West}
                },
                {   
                    RobotDirection.South, new List<RobotDirection> {RobotDirection.West, RobotDirection.South, RobotDirection.East, RobotDirection.North}
                },
                {   
                    RobotDirection.West, new List<RobotDirection> {RobotDirection.North, RobotDirection.West, RobotDirection.South, RobotDirection.East}
                }
            };

        public void BuildMaze(string program)
        {
            _computer = new IntCodeComputer();
            _computer.InitializePositions(program);
            _map.Add(_currentLocation, 1);
            _unexplored.UnionWith(UnexploredSquares().Select(val => (val.x, val.y)));

            var task = Task.Run(_computer.RunProgram);
            int count = 0;

            while (!task.IsCompleted && _unexplored.Any())
            {
                MakeNextMove();
                ReportOnCurrentSquare();

                count++;
                if (InteractiveMode)
                {
                    Thread.Sleep(30);
                    PrintMap();
                }
            }

            Console.WriteLine(count);

            PrintMap();
        }

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

            for (long y = minY; y <= maxY; y++)
            {
                for (long x = minX; x <= maxX; x++)
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

        private IEnumerable<(long x, long y)> UnexploredSquares()
        {
            foreach (var location in _displacement)
            {
                var next = (_currentLocation.x + location.Value.x, _currentLocation.y + location.Value.y);
                if (!_map.ContainsKey(next))
                {
                    yield return next;
                }
            }
        }

        private RobotDirection CalculateNextMove()
        {

            if (UnexploredSquares().Any())
            {
                return (from location in _displacement
                        let next = (_currentLocation.x + location.Value.x, _currentLocation.y + location.Value.y)
                        where !_map.ContainsKey(next)
                        select location.Key).First();
            }

            bool CanIMove(RobotDirection direction)
            {
                var move = _displacement[direction];
                (long x, long y) nextLocation = (_currentLocation.x + move.x, _currentLocation.y + move.y);
                if (_map.TryGetValue(nextLocation, out var next))
                {
                    if (next == 0)
                    {
                        return false;
                    }
                }

                return true;
            }

            foreach (var move in _moveSequence[_currentDirection])
            {
                if (CanIMove(move))
                {
                    return move;
                }
            }

            return RobotDirection.North;
        }

        private void MakeNextMove()
        {
            var nextInstruction = CalculateNextMove();
            _currentDirection = nextInstruction;

            _computer.Inputs.Add((int) nextInstruction);
        }

        private void ReportOnCurrentSquare()
        {
            var result = _computer.Outputs.Take();
            var (x, y) = _displacement[_currentDirection];
            var location = (_currentLocation.x + x, _currentLocation.y + y);
            _map[location] = result;
            _unexplored.Remove(location);

            if (result > 0)
            {
                _currentLocation = location;
            }
            
            var unexplored = UnexploredSquares().ToArray();
            _unexplored.UnionWith(unexplored);
        }

        public int FindPathToOxygen()
        {
            var destination = _map.Single(x => x.Value == 2).Key;
            Console.WriteLine(destination);
            return 1;
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