using AdventOfCode.Utilities;
using System.Text;

namespace AdventOfCode.Solutions
{
    public class Day2
    {
        // 1 2 3
        // 4 5 6
        // 7 8 9
        public int CurrentKey { get; set; }
        public Location CurrentLocation { get; set; } = new Location(1, 1);
        private int[,] _keys = new int[3, 3]
        {
            {1,2,3},
            {4,5,6},
            {7,8,9},
        };
        
        public int CalculateDoorCode(string input)
        {
            var lines = input.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            var result = new StringBuilder();
            foreach(var line in lines)
            {
                ProcessLine(line);
                result.Append(GetCurrentKeyPadNumber());
            }
            return System.Convert.ToInt32(result.ToString());
        }

        public int ProcessLine(string input)
        {
            var instructions = input.ToCharArray();
            foreach (var instruction in instructions)
            {
                ProcessInstruction(instruction);
                System.Console.WriteLine("Processed {0} now at {1},{2}", instruction, CurrentLocation.X, CurrentLocation.Y);
            }
            return GetCurrentKeyPadNumber();
        }

        public void ProcessInstruction(char instruction)
        {
            switch (instruction)
            {
                case 'U': CurrentLocation.Y--; break;
                case 'D': CurrentLocation.Y++; break;
                case 'L': CurrentLocation.X--; break;
                case 'R': CurrentLocation.X++; break;
            }

            CurrentLocation.X = Fixify(CurrentLocation.X);
            CurrentLocation.Y = Fixify(CurrentLocation.Y);
        }
        private int Fixify(int x)
        {
            return x < 0 ? 0 : x > 2 ? 2 : x;
        }
        public int GetCurrentKeyPadNumber()
        {
            return _keys[CurrentLocation.Y, CurrentLocation.X];
        }

        
    }
}