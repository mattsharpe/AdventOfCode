using System;
using Advent2015.Solutions;
using Advent2015.Utilities;
using NUnit.Framework;

namespace Advent2015.Tests
{
    [TestFixture]
    class Day7Fixture
    {
        private Day7 _day7 = new Day7();

        private string[] _sample = {
            "123 -> x",
            "456 -> y",
            "x AND y -> d",
            "x OR y -> e",
            "x LSHIFT 2 -> f",
            "y RSHIFT 2 -> g",
            "NOT x -> h",
            "NOT y -> i"
        };

        [TestCase("123 -> x", "public const ushort x = unchecked((ushort)(123));")]
        [TestCase("456 -> y", "public const ushort y = unchecked((ushort)(456));")]
        [TestCase("x AND y -> d", "public const ushort d = unchecked((ushort)(x & y));")]
        [TestCase("x OR y -> e", "public const ushort e = unchecked((ushort)(x | y));")]
        [TestCase("x LSHIFT 2 -> f", "public const ushort f = unchecked((ushort)(x << 2));")]
        [TestCase("y RSHIFT 2 -> g", "public const ushort g = unchecked((ushort)(y >> 2));")]
        [TestCase("NOT x -> h", "public const ushort h = unchecked((ushort)(~x));")]
        [TestCase("NOT y -> i", "public const ushort i = unchecked((ushort)(~y));")]
        public void Transpile(string input, string expected)
        {
            Assert.AreEqual(expected, _day7.Transpile(input));
        }
        
        [TestCase("d", 72)]
        [TestCase("e", 507)]
        [TestCase("f", 492)]
        [TestCase("g", 114)]
        [TestCase("h", 65412)]
        [TestCase("i", 65079)]
        [TestCase("x", 123)]
        [TestCase("y", 456)]
        public void SampleData(string register, int expected)
        {
            Assert.AreEqual(expected, _day7.BuildSolver(_sample, register));
        }

        [Test]
        public void Part1()
        {
            var result = _day7.BuildSolver(FileReader.ReadFile("day7.txt"),"a");
            Console.WriteLine(result);
        }

        [Test]
        public void Part2()
        {
            var input = FileReader.ReadFile("day7.txt");
            input[54] = "16076 -> b";
            var result = _day7.BuildSolver(input,"a");
            Console.WriteLine(result);
        }
        
    }
}
