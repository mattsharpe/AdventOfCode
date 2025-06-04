using System;
using System.Collections.Generic;

namespace Advent2015.Solutions
{
    class Day23
    {
        public Dictionary<char, int> Registers = new Dictionary<char, int>
        {
            {'a', 0},
            {'b', 0}
        };

        public int ProcessInstruction(string command)
        {
            
            var split = command.Split(' ');
            string instruction = split[0];
            char register = split[1][0];

            switch (instruction)
            {
                case "hlf": //hlf a
                    Registers[register] /= 2;
                    break;
                case "tpl": //tpl a
                    Registers[register] *= 3;
                    break;
                case "inc": //inc a
                    Registers[register]++;
                    break;
                case "jmp": //jmp +19
                    return Convert.ToInt32(split[1]);
                case "jie": //jio a, +4
                    return Registers[register] % 2 == 0 ? Convert.ToInt32(split[2]) : 0;
                case "jio": //jio a, +4
                    return Registers[register] == 1 ? Convert.ToInt32(split[2]) : 0;
                default:
                    throw new ArgumentException($"Unrecognised command {command}");
            }

            return 0;
        }

        public void ProcessInstructions(string[] input)
        {
            int position = 0;

            while (position < input.Length)
            {
                var instruction = input[position];
                var jump = ProcessInstruction(instruction);
                if (jump == 0)
                {
                    position++;
                }
                else
                {
                    position += jump;
                }
            }
        }


    }
}