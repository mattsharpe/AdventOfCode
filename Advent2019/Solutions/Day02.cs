using System;
using System.Linq;

namespace Advent2019.Solutions
{
    class Day02
    {
        public int[] Addresses { get; set; }

        public void RunIntCodeProgram()
        {
            for (var instructionPointer = 0; instructionPointer < Addresses.Length; instructionPointer += 4)
            {
                switch (Addresses[instructionPointer])
                {
                    case 1:
                        Addresses[Addresses[instructionPointer + 3]] = 
                            Addresses[Addresses[instructionPointer + 1]] + Addresses[Addresses[instructionPointer + 2]];
                        break;
                    case 2: 
                        Addresses[Addresses[instructionPointer + 3]] = 
                            Addresses[Addresses[instructionPointer + 1]] * Addresses[Addresses[instructionPointer + 2]];
                        break;
                    case 99:
                        return;
                }
            }
        }

        public void InitializePositions(string program)
        {
            Addresses = program.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
        }
    }
}
