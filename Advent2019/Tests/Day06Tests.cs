using System;
using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day06Tests
    {
        private Day06 _day6;
        private string[] _sampleInput = new[]
        {
            "COM)B",
            "B)C",
            "C)D",
            "D)E",
            "E)F",
            "B)G",
            "G)H",
            "D)I",
            "E)J",
            "J)K",
            "K)L",
        };

        [TestInitialize]
        public void Initialize() => _day6 = new Day06();

        [DataTestMethod]
        [DataRow("D", 3)]
        [DataRow("L", 7)]
        [DataRow("COM", 0)]
        public void GetPathLength(string node, int length)
        {
            _day6.BuildGraph(_sampleInput);
            var parents = _day6.GetParents(node);
            Console.WriteLine(string.Join(",",parents));
            Assert.AreEqual(length, parents.Count());
            
        }

        [TestMethod]
        public void TotalOrbitsSample()
        {
            _day6.BuildGraph(_sampleInput);
            Assert.AreEqual(42, _day6.Orbits());
        }

        [TestMethod]
        public void TotalOrbits()
        {
            _day6.BuildGraph(FileReader.ReadFile("day06.txt"));
            Assert.AreEqual(314702, _day6.Orbits());
        }
    }
}
