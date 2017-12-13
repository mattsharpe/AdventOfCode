using System.Linq;
using Advent2017.Solutions;
using NUnit.Framework;

namespace Advent2017.Tests
{
    [TestFixture]
    class Day10Fixture
    {
        private Day10 _day10;
        private readonly int[] _puzzleInput = {63,144,180,149,1,255,167,84,125,65,188,0,2,254,229,24};
        private string _part2 = "63,144,180,149,1,255,167,84,125,65,188,0,2,254,229,24";

        [SetUp]
        public void Setup()
        {
            _day10 = new Day10();
        }

        [Test]
        public void Sample()
        {
            //list of 0,1,2,3,4
            _day10.List = Enumerable.Range(0, 5).ToList();
            int[] input = {3, 4, 1, 5};
            _day10.ApplyInput(input);

            Assert.AreEqual(12, _day10.List.Take(2).Aggregate((x,y)=> x*y));
        }

        [Test]
        public void Part1()
        {
            _day10.List = Enumerable.Range(0, 256).ToList();
            _day10.ApplyInput(_puzzleInput);

            Assert.AreEqual(4480, _day10.List.Take(2).Aggregate((x,y)=> x*y));
        }

        [TestCase("", "a2582a3a0e66e6e86e3812dcb672a272")]
        [TestCase("AoC 2017", "33efeb34ea91902bb2f59c9920caa6cd")]
        [TestCase("1,2,3", "3efbe78a8d82f29979031a4aa0b16a9d")]
        [TestCase("1,2,4", "63960835bcdc130f0b66d7ff4f6a5a8e")]
        public void Part2_Sample(string test, string expected)
        {

            Assert.AreEqual(expected,_day10.KnotHash(test.Select(x => (int)x).ToArray()));
        }

        [Test]
        public void Part2()
        {
            Assert.AreEqual("c500ffe015c83b60fad2e4b7d59dabc4", _day10.KnotHash(_part2.Select(x => (int)x).ToArray()));
        }
    }
}
