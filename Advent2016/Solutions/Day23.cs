/*
 * --- Day 23: Safe Cracking ---

This is one of the top floors of the nicest tower in EBHQ. The Easter Bunny's private office is here, complete with a safe hidden behind a painting, 
and who wouldn't hide a star in a safe behind a painting?

The safe has a digital screen and keypad for code entry. A sticky note attached to the safe has a password hint on it: "eggs". 
The painting is of a large rabbit coloring some eggs. You see 7.

When you go to type the code, though, nothing appears on the display; instead, the keypad comes apart in your hands, apparently having been smashed. 
Behind it is some kind of socket - one that matches a connector in your prototype computer! You pull apart the smashed keypad and extract the logic circuit, 
plug it into your computer, and plug your computer into the safe.

Now, you just need to figure out what output the keypad would have sent to the safe. You extract the assembunny code from the logic chip (your puzzle input).
The code looks like it uses almost the same architecture and instruction set that the monorail computer used! 
You should be able to use the same assembunny interpreter for this as you did there, but with one new instruction:

tgl x toggles the instruction x away (pointing at instructions like jnz does: positive means forward; negative means backward):

For one-argument instructions, inc becomes dec, and all other one-argument instructions become inc.
For two-argument instructions, jnz becomes cpy, and all other two-instructions become jnz.
The arguments of a toggled instruction are not affected.
If an attempt is made to toggle an instruction outside the program, nothing happens.
If toggling produces an invalid instruction (like cpy 1 2) and an attempt is later made to execute that instruction, skip it instead.
If tgl toggles itself (for example, if a is 0, tgl a would target itself and become inc a), 
    the resulting instruction is not executed until the next time it is reached.
For example, given this program:

cpy 2 a
tgl a
tgl a
tgl a
cpy 1 a
dec a
dec a
cpy 2 a initializes register a to 2.
The first tgl a toggles an instruction a (2) away from it, which changes the third tgl a into inc a.
The second tgl a also modifies an instruction 2 away from it, which changes the cpy 1 a into jnz 1 a.
The fourth line, which is now inc a, increments a to 3.
Finally, the fifth line, which is now jnz 1 a, jumps a (3) instructions ahead, skipping the dec a instructions.
In this example, the final value in register a is 3.

The rest of the electronics seem to place the keypad entry (the number of eggs, 7) in register a, run the code, and then send the value left in register a to the safe.

What value should be sent to the safe?


 */

using System;
using System.Reflection;

namespace Advent2016.Solutions
{
    class Day23
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }

    public void ProcessInstructions(string[] instructions)
        {
            for (int i = 0; i < instructions.Length; i++)
            {
                var instruction = instructions[i];
                
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
                    case "tgl":
                        Toggle(details, instructions, i);
                        break;
                    case "nop":
                        break;
                    case "mul":
                        Multiply(details);
                        break;
                    default:
                        throw new InvalidOperationException("Instruction not supported " + instruction);
                }
            }
        }

        private void Multiply(string details)
        {
            var parts = details.Split(' ');
            var field = GetProperty(parts[2]);
            
            field.SetValue(this, GetValue(parts[0]) * GetValue(parts[1]));
        }

        private void Toggle(string details, string[] instructions, int currentLocation)
        {
            //If tgl toggles itself (for example, if a is 0, tgl a would target itself and become inc a), 
            //the resulting instruction is not executed until the next time it is reached.
            if (GetValue(details) == 0) return; 

            var target = GetValue(details) + currentLocation;

            if (target >= instructions.Length) return;

            var targetInstruction = instructions[target].Substring(0,3);
            switch (targetInstruction)
            {
                case "inc":
                    instructions[target] = instructions[target].Replace("inc", "dec");
                    break;
                case "dec":
                    instructions[target] = instructions[target].Replace("dec", "inc");
                    break;
                case "jnz":
                    instructions[target] = instructions[target].Replace("jnz", "cpy");
                    break;
                case "cpy":
                    instructions[target] = instructions[target].Replace("cpy", "jnz");
                    break;
                case "tgl":
                    instructions[target] = instructions[target].Replace("tgl", "inc");
                    break;
                default:
                    throw new InvalidOperationException("Don't know how to toggle that " + targetInstruction);
            }
        }

        public int Jump(string x, string distance)
        {
            var control = GetValue(x);
            if (control == 0) return 0;
            var modifier = GetValue(distance);
            return modifier - 1;

        }

        public void Shift(string register, int offset)
        {
            var field = GetProperty(register);
            var currentValue = Convert.ToInt32(field.GetValue(this));
            field.SetValue(this, currentValue + offset);
        }

        public void Copy(string input, string target)
        {
            var value = GetValue(input);
            GetProperty(target).SetValue(this, value);

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
                value = Convert.ToInt32(GetProperty(input).GetValue(this));
            }
            return value;
        }
        
        private PropertyInfo GetProperty(string name)
        {
            return GetType().GetProperty(name.Trim().ToUpper());
        }
    }
}
