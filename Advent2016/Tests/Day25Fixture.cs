using System;
using Advent2016.Solutions;
using Advent2016.Utilities;
using NUnit.Framework;

namespace Advent2016.Tests
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

        [Test]
        public void Bonus()
        {
            var instructions = FileReader.ReadFile("bonus.txt");
            _day25.ProcessInstructions(instructions);
            Console.WriteLine(_day25.Output);
        }
    }
}
