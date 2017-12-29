using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Advent2017.Solutions
{
    class Day18Part2 : Day18
    {
        public ConcurrentQueue<long> InputQueue = new ConcurrentQueue<long>();
        public ConcurrentQueue<long> OutputQueue = new ConcurrentQueue<long>();
        
        public Func<bool> OtherBlocked;
        
        public bool Waiting { get; set; }
        public int SendCount { get; set; }

        public bool IsBlocked()
        {
            return Waiting;
        }

        protected override void Send(string[] details)
        {
            SendCount++;
            OutputQueue.Enqueue(GetValue(details[1]));
        }

        protected override long? Receive(string[] details, ref long index)
        {
            if (InputQueue.TryDequeue(out long result))
            {
                Waiting = false;
                Registers[details[1]] = result;
            }
            else
            {
                Waiting = true;
                index--;
                if (OtherBlocked()) return 0;
            }
            return null;
        }
    }

    class Day18
    {
        public int Id { get; set; }
        public Dictionary<string, long> Registers = new Dictionary<string, long> { { "a", 0 }, { "b", 0 } };

        public long Speaker;

        protected virtual void Send(string[] details)
        {
            Speaker = GetValue(details[1]);
        }

        protected virtual long? Receive(string[] details, ref long index)
        {
            if (GetValue(details[1]) != 0) return Speaker;
            return null;
        }

        public long ProcessInstructions(string[] instructions)
        {
            for (long index = 0; index < instructions.Length; index++)
            {
                var x = instructions[index];
                //Console.WriteLine($"{Id} - {index} : {x} \t\t{Registers["a"]}\t\t{Registers["b"]}");
                var details = x.Split(' ');
                switch (details[0])
                {
                    case "snd":
                        Send(details);
                        break;
                    case "set":
                        Registers[details[1]] = GetValue(details[2]);
                        break;
                    case "add":
                        Registers[details[1]] = GetValue(details[1]) + GetValue(details[2]);
                        break;
                    case "mul":
                        Registers[details[1]] = GetValue(details[1]) * GetValue(details[2]);
                        break;
                    case "mod":
                        Registers[details[1]] = GetValue(details[1]) % GetValue(details[2]);
                        break;
                    case "rcv":
                        var result = Receive(details, ref index);
                        if (result.HasValue) return result.Value;
                        break;
                    case "jgz":
                        if (GetValue(details[1]) > 0)
                            index = GetValue(details[2]) + index - 1;
                        break;
                    default:
                        throw new NotImplementedException($"Instruction {x} is not supported");
                }
            }

            return 0;
        }

        protected long GetValue(string x)
        {
            if (long.TryParse(x, out long y))
            {
                return y;
            }
            if (!Registers.ContainsKey(x))
            {
                Registers[x] = 0;
            }
            return Registers[x];
        }
    }
}