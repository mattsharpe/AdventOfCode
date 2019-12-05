using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2019.Solutions
{
    class IntCodeComputer
    {
        public int[] Addresses { get; private set; }
        public Queue<int> Inputs { get; } = new Queue<int>();
        public List<int> Outputs { get; } = new List<int>();

        public void RunProgram()
        {
            for (var instructionPointer = 0; instructionPointer < Addresses.Length;)
            {
                var instruction = Addresses[instructionPointer];
                var opCode = (OpCode)(instruction % 100);
                bool immediate1 = (instruction / 100) % 10  > 0;
                bool immediate2 = (instruction / 1000) % 10 > 0;
                bool immediate3 = (instruction / 10000) % 10 > 0;

                switch (opCode)
                {
                    case OpCode.Add:
                        var first = immediate1 ? Addresses[instructionPointer + 1] : Addresses[Addresses[instructionPointer + 1]];
                        var second = immediate2 ? Addresses[instructionPointer + 2] : Addresses[Addresses[instructionPointer + 2]];

                        Addresses[Addresses[instructionPointer + 3]] = first + second;
                        instructionPointer += 4;
                        break;
                    case OpCode.Multiply: 
                        first = immediate1 ? Addresses[instructionPointer + 1] : Addresses[Addresses[instructionPointer + 1]];
                        second = immediate2 ? Addresses[instructionPointer + 2] : Addresses[Addresses[instructionPointer + 2]];

                        Addresses[Addresses[instructionPointer + 3]] = first * second;
                        instructionPointer += 4;
                        break;
                    case OpCode.Input:
                        Addresses[Addresses[instructionPointer + 1]] = Inputs.Dequeue();
                        instructionPointer += 2;
                        break;
                    case OpCode.Output:
                        first = immediate1 ? Addresses[instructionPointer + 1] : Addresses[Addresses[instructionPointer + 1]];
                        Outputs.Add(first);
                        instructionPointer += 2;
                        break;
                    case OpCode.Halt:
                        return;
                    default:
                        throw new Exception($"Unrecognised Op Code {opCode}");
                }
            }
        }

        public void InitializePositions(string program)
        {
            Addresses = program.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
        }


    }
    
    enum OpCode
    {
        Add = 1, 
        Multiply= 2,
        Input = 3,
        Output= 4, 
        Halt = 99
    }
}
