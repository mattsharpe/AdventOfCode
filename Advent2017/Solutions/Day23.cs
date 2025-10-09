namespace Advent2017.Solutions
{
    internal class Day23
    {
        public int Part1(string[] input)
        {
            var registers = Enumerable.Range('a', 8).ToDictionary(c => (char)c, _ => 0L);
            var instructions = ParseInput(input);
            var mulCount = ProcessInstructions(instructions, registers);
            return mulCount;
        }

        public long Part2(string[] input)
        {
            var initialB = int.Parse(input[0].Split(' ')[2]);
            int b = initialB * 100 + 100000;

            return Enumerable.Range(0, 1001)
                .Select(i => b + i * 17)
                .Count(n => !IsPrime(n));
        }

        private bool IsPrime(int n)
        {
            for (int j = 2; j * j <= n; j++)
            {
                if (n % j == 0) return false;
            }
            return true;
        }

        public List<Instruction> ParseInput(string[] input)
        {
            return input.Select(line =>
            {
                var parts = line.Split(' ');
                return new Instruction(parts[0], parts[1], parts.Length > 2 ? parts[2] : null);
            }).ToList();
        }

        private int ProcessInstructions(List<Instruction> instructions, Dictionary<char, long> registers)
        {
            int mulCount = 0;
            int pc = 0;

            while (pc >= 0 && pc < instructions.Count)
            {
                var instruction = instructions[pc];

                long GetValue(string operand)
                {
                    return char.IsLetter(operand[0])
                        ? registers[operand[0]]
                        : long.Parse(operand);
                }

                switch (instruction.Op)
                {
                    case "set":
                        registers[instruction.X[0]] = GetValue(instruction.Y);
                        pc++;
                        break;
                    case "sub":
                        registers[instruction.X[0]] -= GetValue(instruction.Y);
                        pc++;
                        break;
                    case "mul":
                        registers[instruction.X[0]] *= GetValue(instruction.Y);
                        mulCount++;
                        pc++;
                        break;
                    case "jnz":
                        if (GetValue(instruction.X) != 0)
                        {
                            pc += (int)GetValue(instruction.Y);
                        }
                        else
                        {
                            pc++;
                        }
                        break;
                }
            }

            return mulCount;
        }
    }
    internal record Instruction(string Op, string X, string Y);
}
