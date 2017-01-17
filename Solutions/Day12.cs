
using System;
using AdventOfCode.Utilities;

namespace AdventOfCode.Solutions
{
    class Day12
    {
        public int A;
        public int B;
        public int C;
        public int D;

        public void ProcessInstruction(string instruction)
        {
            if (instruction.StartsWith("inc"))
            {
                var details = instruction.Replace("inc ", "");
                Shift(details, 1);
            }
            else if (instruction.StartsWith("dec"))
            {
                var details = instruction.Replace("dec ", "");
                Shift(details, -1);
            }
        }

        public void Shift(string register, int offset)
        {
            switch (register)
            {
                case "a":
                    A += offset;
                    break;
                case "b":
                    B+= offset;
                    break;
                case "c":
                    C+= offset;
                    break;
                case "d":
                    D+= offset;
                    break;
                default:
                    throw new Exception("Not a valid instruction " + register);
            }
        }

        public void Part1()
        {
            var instructions = FileReader.ReadFile("day12 assembunny.txt");
        }
    }
}
