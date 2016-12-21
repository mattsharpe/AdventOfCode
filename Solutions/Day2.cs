using System;
using AdventOfCode.Utilities;
using System.Text;
using static System.String;

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
            return Convert.ToInt32(result.ToString());
        }

        public int ProcessLine(string input)
        {
            var instructions = input.ToCharArray();
            foreach (var instruction in instructions)
            {
                ProcessInstruction(instruction);
                Console.WriteLine("Processed {0} now at {1},{2}, {3}", instruction, CurrentLocation.X, CurrentLocation.Y,GetCurrentKeyOnRealPad());
            }
            Console.WriteLine("---end of line---");
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

        //Part 2

        private string[,] _actualKeys =
        {
            {null, null, "1", null, null},
            {null, "2", "3", "4", null},
            {"5", "6", "7", "8", "9"},
            {null, "A", "B", "C", null},
            {null, null, "D", null, null}
        };

        public string CalculateRealDoorCode(string input)
        {
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new StringBuilder();
            foreach (var line in lines)
            {
                result.Append(ProcessLineOnRealPad(line));
            }
            return result.ToString();
        }

        public string GetCurrentKeyOnRealPad()
        {
            return _actualKeys[CurrentLocation.Y, CurrentLocation.X];
        }

        public string ProcessLineOnRealPad(string input)
        {
            var instructions = input.ToCharArray();
            foreach (var instruction in instructions)
            {
                ProcessInstructionOnRealPad(instruction);
            }
            return GetCurrentKeyOnRealPad();
        }

        public void ProcessInstructionOnRealPad(char instruction)
        {
            var lastKnownGood = new Location(CurrentLocation.X, CurrentLocation.Y);

            switch (instruction)
            {
                case 'U': CurrentLocation.Y--; break;
                case 'D': CurrentLocation.Y++; break;
                case 'L': CurrentLocation.X--; break;
                case 'R': CurrentLocation.X++; break;
            }

            if (CurrentLocation.X < 0 || CurrentLocation.X > 4 || 
                CurrentLocation.Y < 0 || CurrentLocation.Y > 4 || 
                IsNullOrEmpty(GetCurrentKeyOnRealPad()))
            {
                //not a good place to be - head for open water!
                CurrentLocation = lastKnownGood;
            }
        }


    }
}