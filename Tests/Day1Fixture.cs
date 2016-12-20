using System;
using AdventOfCode.Codes;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day1Fixture
    {
        [Test]
        public void R2_L3()
        {
            var result = Day1.Distance("R2, L3");
            Assert.AreEqual(5, result);
        }

        [Test]
        public void R2_R2_R2()
        {
            var result = Day1.Distance("R2, R2, R2");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void R5_L5_R5_R3()
        {
            var result = Day1.Distance("R5, L5, R5, R3");
            Assert.AreEqual(12, result);
        }

        [Test]
        public void R5_L123()
        {
            var result = Day1.Distance("R5, L123");
            Assert.AreEqual(128, result);
        }

        [Test]
        public void Part1()
        {
            var input = "R3, L5, R2, L1, L2, R5, L2, R2, L2, L2, L1, R2, L2, R4, R4, R1, L2, L3, R3, L1, R2, L2, L4, R4, R5, L3, R3, L3, L3, R4, R5, L3, R3, L5, L1, L2, R2, L1, R3, R1, L1, R187, L1, R2, R47, L5, L1, L2, R4, R3, L3, R3, R4, R1, R3, L1, L4, L1, R2, L1, R4, R5, L1, R77, L5, L4, R3, L2, R4, R5, R5, L2, L2, R2, R5, L2, R194, R5, L2, R4, L5, L4, L2, R5, L3, L2, L5, R5, R2, L3, R3, R1, L4, R2, L1, R5, L1, R5, L1, L1, R3, L1, R5, R2, R5, R5, L4, L5, L5, L5, R3, L2, L5, L4, R3, R1, R1, R4, L2, L4, R5, R5, R4, L2, L2, R5, R5, L5, L2, R4, R4, L4, R1, L3, R1, L1, L1, L1, L4, R5, R4, L4, L4, R5, R3, L2, L2, R3, R1, R4, L3, R1, L4, R3, L3, L2, R2, R2, R2, L1, L4, R3, R2, R2, L3, R2, L3, L2, R4, L2, R3, L4, R5, R4, R1, R5, R3";
            var result = Day1.Distance(input);
            Assert.AreEqual(243,result);
        }

        [Test]
        public void Test()
        {
            Console.WriteLine((Direction)((-90+360)%360));
            Console.WriteLine((Direction)(0%360));
            Console.WriteLine((Direction)(90%360));
            Console.WriteLine((Direction)(180%360));
            Console.WriteLine((Direction)(270%360));
            Console.WriteLine((Direction)(360%360));
            Console.WriteLine((Direction)(450%360));
            Console.WriteLine((Direction)(540%360));
            Console.WriteLine((Direction)(630%360));
        }

        [Test]
        public void Clockwise_NewDirection()
        {
            Assert.AreEqual(Direction.East,Day1.GetNewDirection(Direction.North,90));
            Assert.AreEqual(Direction.South,Day1.GetNewDirection(Direction.East,90));
            Assert.AreEqual(Direction.West,Day1.GetNewDirection(Direction.South,90));
            Assert.AreEqual(Direction.North,Day1.GetNewDirection(Direction.West,90));
        }

        [Test]
        public void CounterClockwise_NewDirection()
        {
            Assert.AreEqual(Direction.West,Day1.GetNewDirection(Direction.North,-90));
            Assert.AreEqual(Direction.North,Day1.GetNewDirection(Direction.East,-90));
            Assert.AreEqual(Direction.East,Day1.GetNewDirection(Direction.South,-90));
            Assert.AreEqual(Direction.South,Day1.GetNewDirection(Direction.West,-90));
        }

        [Test]
        public void CalculateNewLocation_North()
        {
            var location = new Location(0,0);
            var updated = Day1.UpdateLocation(Direction.North, location, 3);
            Assert.AreEqual(3, updated.Y);
            Assert.AreEqual(0, updated.X);
        }

        [Test]
        public void CalculateNewLocation_East()
        {
            var location = new Location(0,0);
            var updated = Day1.UpdateLocation(Direction.East, location, 3);
            Assert.AreEqual(0,updated.Y);
            Assert.AreEqual(3,updated.X);
        }

        [Test]
        public void CalculateNewLocation_South()
        {
            var location = new Location(0,0);
            var updated = Day1.UpdateLocation(Direction.South, location, 3);
            Assert.AreEqual(-3, updated.Y);
            Assert.AreEqual(0, updated.X);
        }

        [Test]
        public void CalculateNewLocation_West()
        {
            var location = new Location(0,0);
            var updated = Day1.UpdateLocation(Direction.West, location, 3);
            Assert.AreEqual(0, updated.Y);
            Assert.AreEqual(-3, updated.X);
        }
    }
}
