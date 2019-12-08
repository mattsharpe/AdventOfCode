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

        public IntCodeComputer()
        {
            
        }

        public IntCodeComputer(string program, int input)
        {
            InitializePositions(program);
            Inputs.Enqueue(input);
        }

        public void RunProgram()
        {
            for (var instructionPointer = 0; instructionPointer < Addresses.Length;)
            {
                var instruction = Addresses[instructionPointer];
                var opCode = (OpCode)(instruction % 100);

                int FirstValue()
                {
                    return (instruction / 100) % 10  > 0
                        ? Addresses[instructionPointer + 1]
                        : Addresses[Addresses[instructionPointer + 1]];
                }

                int SecondValue()
                {
                    return (instruction / 1000) % 10 > 0
                        ? Addresses[instructionPointer + 2]
                        : Addresses[Addresses[instructionPointer + 2]];
                }
                
                switch (opCode)
                {
                    case OpCode.Add:
                        Addresses[Addresses[instructionPointer + 3]] = FirstValue() + SecondValue();
                        instructionPointer += 4;
                        break;
                    case OpCode.Multiply: 
                        Addresses[Addresses[instructionPointer + 3]] = FirstValue() * SecondValue();
                        instructionPointer += 4;
                        break;
                    case OpCode.Input:
                        Addresses[Addresses[instructionPointer + 1]] = Inputs.Dequeue();
                        instructionPointer += 2;
                        break;
                    case OpCode.Output:
                        Outputs.Add(FirstValue());
                        instructionPointer += 2;
                        break;
                    case OpCode.JumpIfTrue:
                        instructionPointer = FirstValue() != 0 ? SecondValue() : instructionPointer + 3;
                        break;
                    case OpCode.JumpIfFalse:
                        instructionPointer = FirstValue() == 0 ? SecondValue() : instructionPointer + 3;
                        break;
                    case OpCode.LessThan:
                        Addresses[Addresses[instructionPointer + 3]] = FirstValue() < SecondValue() ? 1 : 0;
                        instructionPointer += 4;
                        break;
                    case OpCode.Equals:
                        Addresses[Addresses[instructionPointer + 3]] = FirstValue() == SecondValue() ? 1 : 0;
                        instructionPointer += 4;
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
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        Halt = 99
    }
}
