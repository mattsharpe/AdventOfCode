using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Advent2019.Solutions
{
    class IntCodeComputer
    {
        public long[] Addresses { get; private set; }
        public ConcurrentQueue<long> Inputs { get; set; } = new ConcurrentQueue<long>();
        public ConcurrentQueue<long> Outputs { get; set; } = new ConcurrentQueue<long>();
        public long RelativeBase { get; set; }

        public Task RunProgram()
        {
            for (long instructionPointer = 0; instructionPointer < Addresses.Length;)
            {
                var instruction = Addresses[instructionPointer];
                var opCode = (OpCode)(instruction % 100);

                long GetValue(long offset, InstructionMode instructionMode)
                {
                    switch (instructionMode)
                    {
                        case InstructionMode.Position:
                            return Addresses[Addresses[instructionPointer + offset]];
                        case InstructionMode.Immediate:
                            return Addresses[instructionPointer + offset]; 
                        case InstructionMode.Relative:
                            return Addresses[Addresses[instructionPointer + offset] + RelativeBase];
                        default:
                            throw new Exception($"Invalid Instruction mode {instructionMode}");
                    }
                }
                var firstInstructionMode = (InstructionMode)(instruction / 100 % 10);
                var secondInstructionMode = (InstructionMode)(instruction / 1000 % 10);
                var thirdInstructionMode = (InstructionMode)(instruction / 10000 % 10);

                void WriteToAddress(int offset, long valueToWrite, InstructionMode instructionMode = InstructionMode.Position)
                {
                    switch (instructionMode)
                    {
                        case InstructionMode.Position:
                            Addresses[Addresses[instructionPointer + offset]] = valueToWrite;
                            break;
                        case InstructionMode.Relative:
                            Addresses[Addresses[instructionPointer + offset] + RelativeBase] = valueToWrite;
                            break;
                        default:
                            throw new Exception($"Unknown Instruction mode for writing {instructionMode}");
                    }
                }

                long value;
                switch (opCode)
                {
                    case OpCode.Add:
                        value = GetValue(1, firstInstructionMode) + GetValue(2, secondInstructionMode);
                        WriteToAddress(3, value, thirdInstructionMode);
                        instructionPointer += 4;
                        break;
                    case OpCode.Multiply:
                        value = GetValue(1, firstInstructionMode) * GetValue(2, secondInstructionMode);
                        WriteToAddress(3, value, thirdInstructionMode);
                        instructionPointer += 4;
                        break;
                    case OpCode.Input:
                        if (Inputs.TryDequeue(out var next))
                        {
                            WriteToAddress(1, next, firstInstructionMode);
                            instructionPointer += 2;
                        }
                        else
                        {
                            WaitingForInput = true;
                        }
                        break;
                    case OpCode.Output:
                        var nextValue = GetValue(1, firstInstructionMode);
                        Outputs.Enqueue(nextValue);
                        instructionPointer += 2;
                        break;
                    case OpCode.JumpIfTrue:
                        instructionPointer = GetValue(1, firstInstructionMode) != 0 ? GetValue(2, secondInstructionMode) : instructionPointer + 3;
                        break;
                    case OpCode.JumpIfFalse:
                        instructionPointer = GetValue(1, firstInstructionMode) == 0 ? GetValue(2, secondInstructionMode) : instructionPointer + 3;
                        break;
                    case OpCode.LessThan:
                        value = GetValue(1, firstInstructionMode) < GetValue(2, secondInstructionMode) ? 1 : 0;
                        WriteToAddress(3, value, thirdInstructionMode);
                        instructionPointer += 4;
                        break;
                    case OpCode.Equals:
                        value = GetValue(1, firstInstructionMode) == GetValue(2, secondInstructionMode) ? 1 : 0;
                        WriteToAddress(3, value, thirdInstructionMode);
                        instructionPointer += 4;
                        break;
                    case OpCode.AdjustRelativeBase:
                        RelativeBase += GetValue(1, firstInstructionMode);
                        instructionPointer += 2;
                        break;
                    case OpCode.Halt:
                        return Task.CompletedTask;
                    default:
                        throw new Exception($"Unknown Op Code {opCode}");
                }
            }

            return Task.CompletedTask;
        }

        public bool WaitingForInput { get; set; }

        public void InitializePositions(string program)
        {
            var input = program.Split(',').Select(x => Convert.ToInt64(x)).ToArray();
            Addresses = new long[100000];
            input.CopyTo(Addresses,0);
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
        AdjustRelativeBase = 9,
        Halt = 99,
    }

    enum InstructionMode : long
    {
        Position = 0,
        Immediate = 1,
        Relative = 2
    }
}
