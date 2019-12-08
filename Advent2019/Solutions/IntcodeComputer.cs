using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Advent2019.Solutions
{
    class IntCodeComputer
    {
        public int[] Addresses { get; private set; }
        public ConcurrentQueue<int> Inputs { get; set; } = new ConcurrentQueue<int>();
        public ConcurrentQueue<int> Outputs { get; set; } = new ConcurrentQueue<int>();

        public IntCodeComputer()
        {
            
        }

        public IntCodeComputer(string program, int input, ConcurrentQueue<int> inputQueue = null)
        {
            InitializePositions(program);
            Inputs = inputQueue ?? new ConcurrentQueue<int>();
            Inputs.Enqueue(input);
        }
        public Task RunProgram()
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
                        if(Inputs.TryDequeue(out var next))
                        {
                            Addresses[Addresses[instructionPointer + 1]] = next;
                            instructionPointer += 2;
                        }
                        break;
                    case OpCode.Output:
                        var nextValue = FirstValue();
                        Outputs.Enqueue(nextValue);
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
                        return Task.CompletedTask;
                    default:
                        throw new Exception($"Unrecognised Op Code {opCode}");
                }
            }

            return Task.CompletedTask;
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
