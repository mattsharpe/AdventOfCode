using System;
using System.Linq;
using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day03Tests
    {
        private Day03 _day3;

        [TestInitialize] 
        public void Initialize() => _day3 = new Day03();

        [TestMethod]
        public void BuildVisitedSet()
        {
            var result = _day3.GetVisited(new [] {"R8","U5","L5","D3"});
            foreach (var valueTuple in result)
            {
                Console.WriteLine($"{valueTuple.x}, {valueTuple.y}");
            }

        }

        [DataTestMethod]
        [DataRow("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [DataRow("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [DataRow("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void CrossedWireIntersection(string first, string second, int expected)
        {
            Assert.AreEqual(expected, _day3.FindMostCentralIntersection(first,second));
        }

        [TestMethod]
        public void CrossedWireIntersectionPart1()
        {
            var input = FileReader.ReadFile("day03.txt");
            Assert.AreEqual(1983, _day3.FindMostCentralIntersection(input.First(), input.Last()));
        }

    }
}
