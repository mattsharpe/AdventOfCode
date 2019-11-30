using System;
using System.Linq;
using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day18Fixture
    {
        private Day18 _day18;

        [TestInitialize]
        public void Initialize() => _day18 = new Day18();

        private readonly string[] _sample = 
        {
            ".#.#.#",
            "...##.",
            "#....#",
            "..#...",
            "#.#..#",
            "####.."
        };

        [TestMethod]
        public void ParseInput()
        {
            _day18.ParseLights(_sample);
            _day18.PrintLights();
        }

        [TestMethod]
        public void CountNeighbouringLights()
        {
            _day18.ParseLights(_sample);
            Assert.AreEqual(1, _day18.NumberOfOnNeighbours(0,0));
            Assert.AreEqual(0, _day18.NumberOfOnNeighbours(1,0));
            Assert.AreEqual(3, _day18.NumberOfOnNeighbours(2,0));
        }

        [TestMethod]
        public void SimulateLightsSample()
        {
            _day18.ParseLights(_sample);
            _day18.PrintLights();

            foreach (var i in Enumerable.Range(0,4))
            {
                _day18.Step();
                Console.WriteLine();
                _day18.PrintLights();
            }

            Assert.AreEqual(4, _day18.CountLit);
        }

        [TestMethod]
        public void SimulateLightsPartOne()
        {
            _day18.ParseLights(FileReader.ReadFile("day18.txt"));

            foreach (var i in Enumerable.Range(0,100))
            {
                _day18.Step();
            }

            Assert.AreEqual(1061, _day18.CountLit);
        }

        
        [TestMethod]
        public void SimulateLightsSamplePart2()
        {
            _day18.FixedCorners = true;
            _day18.ParseLights(_sample);
            _day18.PrintLights();

            foreach (var i in Enumerable.Range(0, 5))
            {
                _day18.Step();
                Console.WriteLine();
                _day18.PrintLights();
            }

            Assert.AreEqual(17, _day18.CountLit);
        }

        
        [TestMethod]
        public void SimulateLightsPartTwo()
        {
            _day18.FixedCorners = true;
            _day18.ParseLights(FileReader.ReadFile("day18.txt"));

            foreach (var i in Enumerable.Range(0,100))
            {
                _day18.Step();
            }

            Assert.AreEqual(1006, _day18.CountLit);
        }
    }
}