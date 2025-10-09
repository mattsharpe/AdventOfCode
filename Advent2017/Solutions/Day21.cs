namespace Advent2017.Solutions
{
    internal class Day21
    {
        public int Part1(string[] input, int iterations)
        {
            var rules = ParseInput(input);
            var grid = new char[][]
            {
                ['.', '#', '.'],
                ['.', '.', '#'],
                ['#', '#', '#']
            };

            for (int i = 0; i < iterations; i++)
            {
                grid = EnhanceGrid(grid, rules);
            }

            return CountPixels(grid);
        }

        public int Part2(string[] input, int iterations)
        {
            return Part1(input, iterations);
        }

        private char[][] EnhanceGrid(char[][] grid, Dictionary<string, string> rules)
        {
            int size = grid.Length;
            int blockSize = size % 2 == 0 ? 2 : 3;
            int blocksPerRow = size / blockSize;
            int newBlockSize = blockSize + 1;
            int newSize = blocksPerRow * newBlockSize;

            var newGrid = new char[newSize][];
            for (int i = 0; i < newSize; i++)
            {
                newGrid[i] = new char[newSize];
            }

            // Process each block
            for (int blockRow = 0; blockRow < blocksPerRow; blockRow++)
            {
                for (int blockCol = 0; blockCol < blocksPerRow; blockCol++)
                {
                    // Extract block
                    var block = ExtractBlock(grid, blockRow * blockSize, blockCol * blockSize, blockSize);
                    var pattern = GridToPattern(block);

                    // Get enhanced pattern
                    var enhanced = PatternToGrid(rules[pattern]);

                    // Place enhanced block in new grid
                    PlaceBlock(newGrid, enhanced, blockRow * newBlockSize, blockCol * newBlockSize);
                }
            }

            return newGrid;
        }

        private char[][] ExtractBlock(char[][] grid, int startRow, int startCol, int size)
        {
            var block = new char[size][];
            for (int i = 0; i < size; i++)
            {
                block[i] = new char[size];
                for (int j = 0; j < size; j++)
                {
                    block[i][j] = grid[startRow + i][startCol + j];
                }
            }
            return block;
        }

        private void PlaceBlock(char[][] grid, char[][] block, int startRow, int startCol)
        {
            int size = block.Length;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[startRow + i][startCol + j] = block[i][j];
                }
            }
        }

        private int CountPixels(char[][] grid)
        {
            return grid.Sum(row => row.Count(cell => cell == '#'));
        }

        public Dictionary<string, string> ParseInput(string[] input)
        {
            var rules = new Dictionary<string, string>();

            foreach (var line in input)
            {
                var parts = line.Split(" => ");
                var inputPattern = parts[0];
                var outputPattern = parts[1];

                // Generate all rotations and flips of the input pattern
                // and map them all to the same output pattern
                foreach (var variant in GetAllVariants(inputPattern))
                {
                    rules[variant] = outputPattern;
                }
            }

            return rules;
        }

        private IEnumerable<string> GetAllVariants(string pattern)
        {
            var grid = PatternToGrid(pattern);
            var variants = new HashSet<string>();

            // Add all 4 rotations
            for (int i = 0; i < 4; i++)
            {
                variants.Add(GridToPattern(grid));
                grid = RotateGrid(grid);
            }

            // Flip and add all 4 rotations of the flipped version
            grid = FlipGrid(grid);
            for (int i = 0; i < 4; i++)
            {
                variants.Add(GridToPattern(grid));
                grid = RotateGrid(grid);
            }

            return variants;
        }

        private char[][] PatternToGrid(string pattern)
        {
            var rows = pattern.Split('/');
            return rows.Select(row => row.ToCharArray()).ToArray();
        }

        private string GridToPattern(char[][] grid)
        {
            return string.Join("/", grid.Select(row => new string(row)));
        }

        private char[][] RotateGrid(char[][] grid)
        {
            int size = grid.Length;
            return [.. Enumerable.Range(0, size)
                .Select(j => Enumerable.Range(0, size)
                    .Select(i => grid[size - 1 - i][j])
                    .ToArray())];
        }

        private char[][] FlipGrid(char[][] grid)
        {
            return [.. grid.Select(row => row.Reverse().ToArray())];
        }
    }
}
