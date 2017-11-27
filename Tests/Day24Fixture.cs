using System;
using System.Collections.Generic;
using Advent2016.Solutions;
using Advent2016.Utilities;
using NUnit.Framework;

namespace Advent2016.Tests
{

    [TestFixture]
    class Day24Fixture
    {
        private Day24 _day24 = new Day24();

        private readonly string[] _sampleData = 
        {
            "###########",
            "#0.1.....2#",
            "#.#######.#",
            "#4.......3#",
            "###########"
        };

        [SetUp]
        public void Setup()
        {
            _day24 = new Day24();
        }

        [Test]
        public void BuildMap()
        {
            _day24.BuildMap(_sampleData);
            _day24.PrintMap();
        }

        [Test]
        public void StartStateIsPopulatedCorrectly_SampleData()
        {
            _day24.BuildMap(_sampleData);
            Assert.AreEqual(1,_day24.StartState.X);
            Assert.AreEqual(1,_day24.StartState.Y);
        }

        [Test]
        public void GetNextStates()
        {
            _day24.BuildMap(_sampleData);
            var next = _day24.GetNextStates(_day24.Goals[0]);
            Console.WriteLine(next.Count);
        }

        [Test]
        public void ShortestDistance()
        {
            _day24.BuildMap(_sampleData);
            _day24.PrintMap();
            Console.WriteLine();
            var first = _day24.Goals[0];
            var second = _day24.Goals[4];
            
            var distance = _day24.MinimumDistanceBetween(first.X, first.Y, second.X, second.Y);

            _day24.PrintMap();

            Assert.AreEqual(2, distance);
        }

        [Test]
        public void GetAllDistances()
        {
            _day24.GetAllDistances(_sampleData);
        }

        [Test]
        public void Solve_Sample()
        {
            var result = _day24.SolveForShortestPath(_sampleData, 0);
            Assert.AreEqual(14, result);
        }

        [Test]
        public void Solve_Part1()
        {
            var result = _day24.SolveForShortestPath(FileReader.ReadFile("day 24.txt"), 0);
            Assert.AreEqual(428, result);
        }

        [Test]
        public void Solve_Part2()
        {
            var result = _day24.SolveForShortestPath(FileReader.ReadFile("day 24.txt"), 0, true);
            Assert.AreEqual(680, result);
        }

        [Test]
        public void GetPermuations()
        {
            var result = _day24.GetPermutations<int>(new List<int>(new []{1,2,3}), 3);
            result.ForEach(x=> Console.WriteLine(string.Join(",",x)));
        }

        [Test]
        public void CalculateShortest()
        {
            _day24.GetAllDistances(_sampleData);

            var length = _day24.CalculatePathLength(new List<int>(new[] {0, 4, 1, 2, 3}));
            Assert.AreEqual(14, length);
        }

    }

 
}
