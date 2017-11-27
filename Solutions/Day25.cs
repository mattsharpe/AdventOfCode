using System;
using System.Linq;
using System.Reflection;

namespace AdventOfCode.Solutions
{
    class Day25
    {
        public int A;
        public int B;
        public int C;
        public int D;
        public string Output { get; set; } = "";

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
                    case "out":
                        Out(details);
                        break;
                    default:
                        throw new InvalidOperationException("Instruction not supported " + instruction);
                }
                if (Output != TargetString(Output.Length))
                    break;

                if (Output.Length == 30) break;
            }
        }

        public string TargetString(int length)
        {
            return string.Join("", Enumerable.Range(0, length)
                .Select(x => x % 2));
        }

        private void Out(string details)
        {
            var parts = details.Split(' ');
            Output += GetValue(parts[0]);
        }

        private void Multiply(string details)
        {
            var parts = details.Split(' ');
            var field = GetField(parts[2]);
            
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
        
        private FieldInfo GetField(string name)
        {
            return GetType().GetField(name.Trim().ToUpper());
        }
    }
}
