using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Solutions;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day15Fixture
    {
        private Day15 _day15;
            

        [SetUp]
        public void Setup()
        {
            _day15 = new Day15();
        }

        [Test]
        public void SampleData()
        {
            var sculpture = new List<Disc>
            {
                new Disc {Positions = 5, StartingPosition = 4 }, //t + 1 % 5
                new Disc {Positions = 2, StartingPosition = 1}, //t + 2 % 2
            };

            _day15.Sculpture = sculpture;
            var result = _day15.Part1();
            
            Assert.AreEqual(5, result);
            Console.WriteLine(result);
            
        }

        [Test]
        public void Part1()
        {
            /*
            Disc #1 has 5 positions; at time=0, it is at position 2.
            Disc #2 has 13 positions; at time=0, it is at position 7.
            Disc #3 has 17 positions; at time=0, it is at position 10.
            Disc #4 has 3 positions; at time=0, it is at position 2.
            Disc #5 has 19 positions; at time=0, it is at position 9.
            Disc #6 has 7 positions; at time=0, it is at position 0.
            */
            var sculpture = new List<Disc>
            {
                new Disc {Positions = 5, StartingPosition = 2 },
                new Disc {Positions = 13, StartingPosition = 7 },
                new Disc {Positions = 17, StartingPosition = 10 },
                new Disc {Positions = 3, StartingPosition = 2 },
                new Disc {Positions = 19, StartingPosition = 9 },
                new Disc {Positions = 7, StartingPosition = 0 },
            };

            _day15.Sculpture = sculpture;
            var result = _day15.Part1();

            Assert.AreEqual(148737, result);
            Console.WriteLine(result);
        }

        [Test]
        public void Part2()
        {
            var sculpture = new List<Disc>
            {
                new Disc {Positions = 5, StartingPosition = 2 },
                new Disc {Positions = 13, StartingPosition = 7 },
                new Disc {Positions = 17, StartingPosition = 10 },
                new Disc {Positions = 3, StartingPosition = 2 },
                new Disc {Positions = 19, StartingPosition = 9 },
                new Disc {Positions = 7, StartingPosition = 0 },
                new Disc {Positions = 11, StartingPosition = 0 },
            };

            _day15.Sculpture = sculpture;
            var result = _day15.Part1();

            Assert.AreEqual(2353212, result);
            Console.WriteLine(result);
        }

    }
}
