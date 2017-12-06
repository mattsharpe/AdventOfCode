﻿using System;
using System.Linq;
using Advent2015.Solutions;
using Advent2015.Utilities;
using NUnit.Framework;

namespace Advent2015.Tests
{
    [TestFixture]
    class Day9Fixture
    {
        private Day9 _day9 = new Day9();

        private string[] _sample =
        {
            "London to Dublin = 464",
            "London to Belfast = 518",
            "Dublin to Belfast = 141"
        };

        [Test]
        public void BuildMap()
        {
            _day9.BuildDistances(_sample);
            foreach (var kvp in _day9.AdjacencyMatrix.OrderBy(x=>x.Key))
            {
                Console.Write("\t\t" + kvp.Key);
            }
            Console.WriteLine();
            foreach (var kvp in _day9.AdjacencyMatrix.OrderBy(x => x.Key))
            {
                Console.Write(kvp.Key+ "\t\t");
                foreach (var value in kvp.Value.OrderBy(x=>x.Key))
                {
                    Console.Write(value.Value + "\t\t");
                }
                Console.WriteLine();
            }
        }

        [Test]
        public void GetPaths()
        {
            _day9.BuildDistances(_sample);
            _day9.GeneratePaths();
        }

        [Test]
        public void Sample()
        {
            Assert.AreEqual(605, _day9.Part1(_sample));
        }

        [Test]
        public void Part1()
        {
            Assert.AreEqual(117, _day9.Part1(FileReader.ReadFile("day9.txt")));
        }

        [Test]
        public void Sample_Part2()
        {
            Assert.AreEqual(982, _day9.Part2(_sample));
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual(909, _day9.Part2(FileReader.ReadFile("day9.txt")));
        }
    }
}