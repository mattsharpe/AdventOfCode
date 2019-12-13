using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2019.Solutions
{
    class Day11
    {
        private IntCodeComputer _brain = new IntCodeComputer();
        private Direction _direction = Direction.Up;
        private (int x, int y) _currentLocation = (0, 0);
        Dictionary<(int x, int y), long> _map = new Dictionary<(int x, int y), long>();
        private RobotAction _currentAction = RobotAction.Scan;

        private Dictionary<Direction, (int x,int y)> _displacement = new Dictionary<Direction, (int x, int y)>
        {
            {Direction.Up, (0 , -1)},
            {Direction.Right, (1 , 0)},
            {Direction.Down, (0 , 1)},
            {Direction.Left, (-1 , 0)},
        };

        public void Initialize(string program)
        {
            _brain.InitializePositions(program);
        }

        public int PaintedSquares() => _map.Keys.Count;

        public void DrawRegistration()
        {
            var task = Task.Run(() => _brain.RunProgram());
            while (!task.IsCompleted)
            {
                if (_currentAction == RobotAction.Paint &&_brain.Outputs.TryDequeue(out var paint))
                {
                        _map[_currentLocation] = paint;
                        _currentAction = RobotAction.Move;
                }
                else if (_currentAction == RobotAction.Scan)
                {
                    if (!_map.TryGetValue(_currentLocation, out long input))
                    {
                        input = 0;
                        _map.Add(_currentLocation, input);
                    }

                    _brain.Inputs.Enqueue(input);
                    _currentAction = RobotAction.Paint;
                }
                else if (_currentAction == RobotAction.Move && _brain.Outputs.TryDequeue(out var turn))
                {
                        // 0 = left 90, 1 = right 90
                        _currentAction = RobotAction.Scan;
                        if (turn == 0)
                        {
                            turn = -1;
                        }

                        turn = ((int) _direction) + turn;
                        if (turn < 0) turn += 4;
                        _direction = (Direction) (turn % 4);
                        var displacement = _displacement[_direction];
                        _currentLocation.x += displacement.x;
                        _currentLocation.y += displacement.y;

                        _currentAction = RobotAction.Scan;
                    
                }
            }

        }

        public void Print()
        {
            var minX = Math.Min(_currentLocation.x, _map.Keys.Min(k => k.x));
            var maxX = Math.Max(_currentLocation.x,_map.Keys.Max(k => k.x));

            var minY = Math.Min(_currentLocation.y, _map.Keys.Min(k => k.y));
            var maxY = Math.Max(_currentLocation.y, _map.Keys.Max(k => k.y));

            for (int y = minY; y <= maxY; y++)
            {
                var sb = new StringBuilder();
                for (int x = minX; x <= maxX ; x++)
                {
                    if (_currentLocation == (x, y))
                    {
                        switch (_direction)
                        {
                            case Direction.Up:
                                sb.Append("^");
                                break;
                            case Direction.Down:
                                sb.Append("V");
                                break;
                            case Direction.Left:
                                sb.Append("<");
                                break;
                            case Direction.Right:
                                sb.Append(">");
                                break;
                        }
                    }
                    else
                    {
                        if (_map.TryGetValue((x,y), out long output))
                        {
                            sb.Append(output == 0 ? "." : "#");
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }
                }
                Console.WriteLine(sb.ToString());
            }
        }

        public void AddInput(long input)
        {
            _brain.Inputs.Enqueue(input);
        }
    }

    enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }

    enum RobotAction
    {
        Scan,
        Paint,
        Move
    }
}
