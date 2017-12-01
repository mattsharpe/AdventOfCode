using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2015.Solutions
{
    class Day7
    {
        public void Part1()
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, ushort> _cache = default;
        private Dictionary<string, string> _wires = default;

        public ushort And(string a, string b)
        {
            return Convert.ToUInt16((GetValue(a) & GetValue(b)));
        }

        public ushort Or(string a, string b)
        {
            return Convert.ToUInt16((GetValue(a) | GetValue(b)));
        }

        public ushort Not(string a)
        {
            return Convert.ToUInt16(~GetValue(a));
        }

        public ushort LShift(string s, string shift)
        {
            GetValue(s);
            GetValue(shift);
            return  (ushort)(GetValue(s) << GetValue(shift));

        }

        private ushort GetValue(string value)
        {
            ushort temp;
            if (UInt16.TryParse(value, out temp))
            {
                return temp;
            }
            else
            {
                return _cache[value];
            }

        }

        public void Solve(string[] instructions)
        {
            _wires = instructions.ToList().ToDictionary(k => k.Split(' ').Last());
            foreach (var instruction in instructions)
            {
                var split = instruction.Split(' ');
                Console.WriteLine(instruction);
                var gate = new LogicGate();
                switch (split.Length)
                {
                    //123 -> a
                    case 3:
                        gate.Left = split[0];
                        gate.Right = split[2];
                        break;
                    
                }
            }
        }
    }

    public class LogicGate
    {
        public string Left { get; set; }
        public string Right { get; set; }
        public ushort Value { get; set; }
    }

    public enum LogicOperator
    {
        And,
        Or,
        LShift,
        RShift,
        Not
    }
}
