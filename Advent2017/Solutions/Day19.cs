using System.Numerics;

namespace Advent2017.Solutions
{
    class Day19
    {
        public string Part1(string[] input)
        {
            var map = ParseInput(input);
            var solver = new NetworkPacketSolver(map);
            return solver.Solve().Letters;
        }

        public int Part2(string[] input)
        {
            var map = ParseInput(input);
            var solver = new NetworkPacketSolver(map);
            return solver.Solve().Steps;
        }

        public Dictionary<Vector2, string> ParseInput(string[] input)
        {
            Dictionary<Vector2, string> map = new Dictionary<Vector2, string>();

            foreach (var y in Enumerable.Range(0, input.Length))
                foreach (var x in Enumerable.Range(0, input[0].Length))
                {
                    map.Add(new Vector2(x, y), input[y][x].ToString());
                }
            return map;
        }
    }

    class NetworkPacketSolver(Dictionary<Vector2, string> map)
    {
        private Vector2 _position = map.Single(kvp => kvp.Key.Y == 0 && kvp.Value == "|").Key;
        private Vector2 _direction = new Vector2(0, 1);
        private string _letters = "";
        private int _steps = 0;

        public (string Letters, int Steps) Solve()
        {
            while (true)
            {
                _position += _direction;
                _steps++;

                if (!map.TryGetValue(_position, out string value) || value == " ")
                    break;

                var current = map[_position];

                if (current == "+")
                {
                    if (_direction.X == 0)
                    {
                        if (map.ContainsKey(_position + new Vector2(1, 0)) && map[_position + new Vector2(1, 0)] != " ")
                            _direction = new Vector2(1, 0);
                        else if (map.ContainsKey(_position + new Vector2(-1, 0)) && map[_position + new Vector2(-1, 0)] != " ")
                            _direction = new Vector2(-1, 0);
                    }
                    else
                    {
                        if (map.ContainsKey(_position + new Vector2(0, 1)) && map[_position + new Vector2(0, 1)] != " ")
                            _direction = new Vector2(0, 1);
                        else if (map.ContainsKey(_position + new Vector2(0, -1)) && map[_position + new Vector2(0, -1)] != " ")
                            _direction = new Vector2(0, -1);
                    }
                }
                else if (current != "|" && current != "-")
                {
                    _letters += current;
                }
            }
            return (_letters, _steps);
        }
    }
}