using System;
using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day7Fixture
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

        [DataRow("123 -> x", "public const ushort x = unchecked((ushort)(123));")]
        [DataRow("456 -> y", "public const ushort y = unchecked((ushort)(456));")]
        [DataRow("x AND y -> d", "public const ushort d = unchecked((ushort)(x & y));")]
        [DataRow("x OR y -> e", "public const ushort e = unchecked((ushort)(x | y));")]
        [DataRow("x LSHIFT 2 -> f", "public const ushort f = unchecked((ushort)(x << 2));")]
        [DataRow("y RSHIFT 2 -> g", "public const ushort g = unchecked((ushort)(y >> 2));")]
        [DataRow("NOT x -> h", "public const ushort h = unchecked((ushort)(~x));")]
        [DataRow("NOT y -> i", "public const ushort i = unchecked((ushort)(~y));")]
        [DataTestMethod]
        public void Transpile(string input, string expected)
        {
            Assert.AreEqual(expected, _day7.Transpile(input));
        }
        
        [DataRow("d", 72)]
        [DataRow("e", 507)]
        [DataRow("f", 492)]
        [DataRow("g", 114)]
        [DataRow("h", 65412)]
        [DataRow("i", 65079)]
        [DataRow("x", 123)]
        [DataRow("y", 456)]
        [DataTestMethod]
        public void SampleData(string register, int expected)
        {
            Assert.AreEqual(expected, _day7.BuildSolver(_sample, register));
        }

        [TestMethod]
        public void Part1()
        {
            var result = _day7.BuildSolver(FileReader.ReadFile("day7.txt"),"a");
            Assert.AreEqual(16076,result);
        }

        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day7.txt");
            input[54] = "16076 -> b";
            var result = _day7.BuildSolver(input,"a");
            Assert.AreEqual(2797, result);
        }
        
    }
}
