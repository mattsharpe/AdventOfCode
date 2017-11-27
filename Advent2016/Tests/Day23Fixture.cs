using System;
using Advent2016.Solutions;
using Advent2016.Utilities;
using NUnit.Framework;

namespace Advent2016.Tests
{
    [TestFixture]
    class Day23Fixture
    {
        private Day23 _day23 = new Day23();

        [Test]
        public void SampleData()
        {
            var input = new[]{"cpy 2 a",
                "tgl a",
                "tgl a",
                "tgl a",
                "cpy 1 a",
                "dec a",
                "dec a"};

            _day23.ProcessInstructions(input);

            Console.WriteLine(_day23.A);
            Assert.AreEqual(3, _day23.A);
        }

        [Test]
        public void Part1()
        {
            var input = FileReader.ReadFile("day 23.txt");

            _day23.A = 7;
            _day23.ProcessInstructions(input);

            Assert.AreEqual(11500, _day23.A);
        }

        [Test]
        public void Part2()
        {
            var instructions = new[]
            {
                "cpy a b",
                "dec b",

                "nop ", //"cpy a d",
                "nop ", //"cpy 0 a",
                "nop ", //"cpy b c",
                "nop ", //"inc a",
                "nop ", //"dec c",
                "nop ", //"jnz c -2",
                "nop ", //"dec d",
                "mul b a a", //"jnz d -5",

                "dec b",
                "cpy b c",
                "cpy c d",
                "dec d",
                "inc c",
                "jnz d -2",
                "tgl c",
                "cpy -16 c",
                "jnz 1 c",
                "cpy 85 c",
                "jnz 76 d",
                "inc a",
                "inc d",
                "jnz d -2",
                "inc c",
                "jnz c -5"
            };

            _day23.A = 12;
            _day23.ProcessInstructions(instructions);

            Assert.AreEqual(479008060, _day23.A);
        }
    }
}
