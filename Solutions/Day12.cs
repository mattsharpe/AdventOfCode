using System;
using System.Reflection;
using AdventOfCode2016.Utilities;

namespace AdventOfCode2016.Solutions
{
    /*
    --- Day 12: Leonardo's Monorail ---

    You finally reach the top floor of this building: a garden with a slanted glass ceiling. Looks like there are no more stars to be had.

    While sitting on a nearby bench amidst some tiger lilies, you manage to decrypt some of the files you extracted from the servers downstairs.

    According to these documents, Easter Bunny HQ isn't just this building - it's a collection of buildings in the nearby area. They're all connected by a local monorail, and there's another building not far from here! Unfortunately, being night, the monorail is currently not operating.

    You remotely connect to the monorail control systems and discover that the boot sequence expects a password. The password-checking logic (your puzzle input) is easy to extract, but the code it uses is strange: it's assembunny code designed for the new computer you just assembled. You'll have to execute the code and get the password.

    The assembunny code you've extracted operates on four registers (a, b, c, and d) that start at 0 and can hold any integer. However, it seems to make use of only a few instructions:

    cpy x y copies x (either an integer or the value of a register) into register y.
    inc x increases the value of register x by one.
    dec x decreases the value of register x by one.
    jnz x y jumps to an instruction y away (positive means forward; negative means backward), but only if x is not zero.
    The jnz instruction moves relative to itself: an offset of -1 would continue at the previous instruction, 
    while an offset of 2 would skip over the next instruction.

    For example:

    cpy 41 a
    inc a
    inc a
    dec a
    jnz a 2
    dec a
    The above code would set register a to 41, increase its value by 2, decrease its value by 1, 
    and then skip the last dec a (because a is not zero, so the jnz a 2 skips it), 
    leaving register a at 42. When you move past the last instruction, the program halts.

    After executing the assembunny code in your puzzle input, what value is left in register a?

    --- Part Two ---

    As you head down the fire escape to the monorail, you notice it didn't start; register c needs to be initialized to the position of the ignition key.

    If you instead initialize register c to be 1, what value is now left in register a?
    */
    class Day12
    {
        public int A;
        public int B;
        public int C;
        public int D;

        public void ProcessInstructions(string[] instructions)
        {
            
            for (int i = 0; i < instructions.Length; i++)
            {
                var instruction = instructions[i];
                //Console.WriteLine($"{i}\t{instruction}\t\t\tA:{A} B:{B} C:{C} D:{D}");
                var details = instruction.Substring(4);
                switch (instruction.Substring(0, 3))
                {
                    case "inc":
                        Shift(details, 1);
                        break;
                    case "dec":
                        Shift(details, -1);
                        break;
                    case "cpy":
                        Copy(details.Split(' ')[0], details.Split(' ')[1]);
                        break;
                    case "jnz":
                        var modifier = Jump(details.Split(' ')[0], details.Split(' ')[1]);
                        i += modifier;
                        break;
                    default:
                        throw new InvalidOperationException("Instruction not supported " + instruction);
                }
            }
        }

        public int Jump(string x, string distance)
        {
            var control = GetValue(x);
            if (control == 0) return 0;
            var modifier = Convert.ToInt32(distance);
            return modifier - 1;

        }

        public void Shift(string register, int offset)
        {
            var field = GetField(register);
            var currentValue = Convert.ToInt32(field.GetValue(this));
            field.SetValue(this, currentValue + offset);
        }

        public void Copy(string input, string target)
        {
            var value = GetValue(input);
            GetField(target).SetValue(this, value);

        }

        /// <summary>
        /// Returns the int value of the instruction, or the value in the register specified
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private int GetValue(string input)
        {
            int value;
            var isValue = int.TryParse(input, out value);
            
            if (!isValue)
            {
                value = Convert.ToInt32(GetField(input).GetValue(this));
            }
            return value;
        }

        public void Part1()
        {
            var input = FileReader.ReadFile("day12 assembunny.txt");
            ProcessInstructions(input);
        }
        public void Part2()
        {
            var input = FileReader.ReadFile("day12 assembunny.txt");
            C = 1;
            ProcessInstructions(input);
        }

        private FieldInfo GetField(string name)
        {
            return GetType().GetField(name.Trim().ToUpper());
        }
    }
}
