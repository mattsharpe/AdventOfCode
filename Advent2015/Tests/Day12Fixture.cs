using System.Linq;
using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day12Fixture
    {
        private Day12 _day12;

        [TestInitialize]
        public void TestInitialize() => _day12 = new Day12();

        [DataTestMethod]
        [DataRow("[1,2,3]", 6)]
        [DataRow(@"{""a"":2,""b"":4}", 6)]
        [DataRow("[[[3]]]", 3)]
        [DataRow(@"{""a"":{""b"":4},""c"":-1}", 3)]
        [DataRow(@"{""a"":[-1,1]}", 0)]
        [DataRow(@"[-1,{""a"":1}]", 0)]
        [DataRow(@"[]", 0)]
        [DataRow(@"{}", 0)]
        public void NumberSamples(string json, int expected)
        {
            Assert.AreEqual(expected, _day12.SumNumbers(json));
        }

        [TestMethod]
        public void Part1()
        {
            var input = FileReader.ReadFile("day12.txt").First();
            Assert.AreEqual(191164, _day12.SumNumbers(input));
        }

        [DataTestMethod]
        [DataRow("[1,2,3]", 6)]
        [DataRow(@"[1,{""c"":""red"",""b"":2},3]", 4)]
        [DataRow(@"{""d"":""red"",""e"":[1,2,3,4],""f"":5}", 0)]
        [DataRow(@"[1,""red"",5]", 6)]
        public void SamplesWithRedExcluded(string json, int expected)
        {
            Assert.AreEqual(expected, _day12.SumNumbersWithoutRed(json));
        }

        [TestMethod]
        public void Part2()
        {
            var input = FileReader.ReadFile("day12.txt").First();
            Assert.AreEqual(87842, _day12.SumNumbersWithoutRed(input));
        }
}
}
