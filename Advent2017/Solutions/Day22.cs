namespace Advent2017.Solutions
{
    internal class Day22
    {
        public int Part1(string[] input, int bursts)
        {
            var infected = ParseInput(input);
            var position = (row: 0, col: 0);
            var direction = (-1, 0); // Up
            int infectionsCount = 0;

            for (int i = 0; i < bursts; i++)
            {
                if (infected.Contains(position))
                {
                    // Current node is infected - turn right
                    direction = TurnRight(direction);
                    infected.Remove(position);
                }
                else
                {
                    // Current node is clean - turn left and infect
                    direction = TurnLeft(direction);
                    infected.Add(position);
                    infectionsCount++;
                }

                // Move forward
                position = (position.row + direction.Item1, position.col + direction.Item2);
            }

            return infectionsCount;
        }

        public int Part2(string[] input, int bursts)
        {
            var infected = ParseInput(input);
            var weakened = new HashSet<(int, int)>();
            var flagged = new HashSet<(int, int)>();
            var position = (row: 0, col: 0);
            var direction = (-1, 0); // Up
            int infectionsCount = 0;

            for (int i = 0; i < bursts; i++)
            {
                if (infected.Contains(position))
                {
                    // Infected - turn right and flag
                    direction = TurnRight(direction);
                    infected.Remove(position);
                    flagged.Add(position);
                }
                else if (weakened.Contains(position))
                {
                    // Weakened - don't turn and infect
                    weakened.Remove(position);
                    infected.Add(position);
                    infectionsCount++;
                }
                else if (flagged.Contains(position))
                {
                    // Flagged - reverse direction and clean
                    direction = Reverse(direction);
                    flagged.Remove(position);
                }
                else
                {
                    // Clean - turn left and weaken
                    direction = TurnLeft(direction);
                    weakened.Add(position);
                }

                // Move forward
                position = (position.row + direction.Item1, position.col + direction.Item2);
            }

            return infectionsCount;
        }

        private (int, int) Reverse((int row, int col) direction)
        {
            return (-direction.row, -direction.col);
        }

        private (int, int) TurnLeft((int row, int col) direction)
        {
            return direction switch
            {
                (-1, 0) => (0, -1),  // Up -> Left
                (0, -1) => (1, 0),   // Left -> Down
                (1, 0) => (0, 1),    // Down -> Right
                (0, 1) => (-1, 0),   // Right -> Up
                _ => direction
            };
        }

        private (int, int) TurnRight((int row, int col) direction)
        {
            return direction switch
            {
                (-1, 0) => (0, 1),   // Up -> Right
                (0, 1) => (1, 0),    // Right -> Down
                (1, 0) => (0, -1),   // Down -> Left
                (0, -1) => (-1, 0),  // Left -> Up
                _ => direction
            };
        }

        public HashSet<(int, int)> ParseInput(string[] input)
        {
            var infected = new HashSet<(int, int)>();
            int centerRow = input.Length / 2;
            int centerCol = input[0].Length / 2;

            for (int row = 0; row < input.Length; row++)
            {
                for (int col = 0; col < input[row].Length; col++)
                {
                    if (input[row][col] == '#')
                    {
                        infected.Add((row - centerRow, col - centerCol));
                    }
                }
            }

            return infected;
        }
    }
}
