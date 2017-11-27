using System;
using AdventOfCode.Solutions;
using AdventOfCode.Utilities;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day25Fixture
    {
        private Day25 _day25 = new Day25();

        [Test]
        public void TargetString()
        {
            Console.WriteLine(_day25.TargetString(1));
            Console.WriteLine(_day25.TargetString(2));
            Console.WriteLine(_day25.TargetString(3));
            Console.WriteLine(_day25.TargetString(10));
            Console.WriteLine(_day25.TargetString(20));
        }

        [Test]
        public void Part1()
        {
            var instructions = FileReader.ReadFile("day 25.txt");
            
            for (int i = 0; i < 250; i++)
            {
                var computer = new Day25();
                computer.A = i;

                computer.ProcessInstructions(instructions);
                if(computer.Output.Length>30)
                    Console.WriteLine(i + ": " + computer.Output);
            }
        }
    }
}
