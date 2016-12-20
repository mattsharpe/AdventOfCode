using AdventOfCode.Codes;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day1Fixture
    {
        private Day1 _day1;

        [SetUp]
        public void Setup()
        {
            _day1 = new Day1 {CurrentDirection = Direction.North, CurrentLocation = new Location(0,0)};
        }

        [Test]
        public void R2_L3()
        {
            var result = _day1.Distance("R2, L3");
            Assert.AreEqual(5, result);
        }

        [Test]
        public void R2_R2_R2()
        {
            var result = _day1.Distance("R2, R2, R2");
            Assert.AreEqual(2, result);
        }

        [Test]
        public void R5_L5_R5_R3()
        {
            var result = _day1.Distance("R5, L5, R5, R3");
            Assert.AreEqual(12, result);
        }

        [Test]
        public void R5_L123()
        {
            var result = _day1.Distance("R5, L123");
            Assert.AreEqual(128, result);
        }

        [Test]
        public void Part1()
        {
            var input = "R3, L5, R2, L1, L2, R5, L2, R2, L2, L2, L1, R2, L2, R4, R4, R1, L2, L3, R3, L1, R2, L2, L4, R4, R5, L3, R3, L3, L3, R4, R5, L3, R3, L5, L1, L2, R2, L1, R3, R1, L1, R187, L1, R2, R47, L5, L1, L2, R4, R3, L3, R3, R4, R1, R3, L1, L4, L1, R2, L1, R4, R5, L1, R77, L5, L4, R3, L2, R4, R5, R5, L2, L2, R2, R5, L2, R194, R5, L2, R4, L5, L4, L2, R5, L3, L2, L5, R5, R2, L3, R3, R1, L4, R2, L1, R5, L1, R5, L1, L1, R3, L1, R5, R2, R5, R5, L4, L5, L5, L5, R3, L2, L5, L4, R3, R1, R1, R4, L2, L4, R5, R5, R4, L2, L2, R5, R5, L5, L2, R4, R4, L4, R1, L3, R1, L1, L1, L1, L4, R5, R4, L4, L4, R5, R3, L2, L2, R3, R1, R4, L3, R1, L4, R3, L3, L2, R2, R2, R2, L1, L4, R3, R2, R2, L3, R2, L3, L2, R4, L2, R3, L4, R5, R4, R1, R5, R3";
            var result = _day1.Distance(input);
            Assert.AreEqual(243,result);
        }

        [Test]
        public void Part2()
        {
            var input = "R3, L5, R2, L1, L2, R5, L2, R2, L2, L2, L1, R2, L2, R4, R4, R1, L2, L3, R3, L1, R2, L2, L4, R4, R5, L3, R3, L3, L3, R4, R5, L3, R3, L5, L1, L2, R2, L1, R3, R1, L1, R187, L1, R2, R47, L5, L1, L2, R4, R3, L3, R3, R4, R1, R3, L1, L4, L1, R2, L1, R4, R5, L1, R77, L5, L4, R3, L2, R4, R5, R5, L2, L2, R2, R5, L2, R194, R5, L2, R4, L5, L4, L2, R5, L3, L2, L5, R5, R2, L3, R3, R1, L4, R2, L1, R5, L1, R5, L1, L1, R3, L1, R5, R2, R5, R5, L4, L5, L5, L5, R3, L2, L5, L4, R3, R1, R1, R4, L2, L4, R5, R5, R4, L2, L2, R5, R5, L5, L2, R4, R4, L4, R1, L3, R1, L1, L1, L1, L4, R5, R4, L4, L4, R5, R3, L2, L2, R3, R1, R4, L3, R1, L4, R3, L3, L2, R2, R2, R2, L1, L4, R3, R2, R2, L3, R2, L3, L2, R4, L2, R3, L4, R5, R4, R1, R5, R3";
            var result = _day1.FirstVisitedDistance(input);
            Assert.AreEqual(142, result);
        }

        [Test]
        public void Clockwise_NewDirection()
        {
            Assert.AreEqual(Direction.North, _day1.CurrentDirection);
            _day1.SetNewDirection(90);
            Assert.AreEqual(Direction.East,_day1.CurrentDirection);
            _day1.SetNewDirection(90);
            Assert.AreEqual(Direction.South, _day1.CurrentDirection);
            _day1.SetNewDirection(90);
            Assert.AreEqual(Direction.West, _day1.CurrentDirection);
            _day1.SetNewDirection(90);
            Assert.AreEqual(Direction.North, _day1.CurrentDirection);
        }

        [Test]
        public void CounterClockwise_NewDirection()
        {
            Assert.AreEqual(Direction.North, _day1.CurrentDirection);
            _day1.SetNewDirection(-90);
            Assert.AreEqual(Direction.West, _day1.CurrentDirection);
            _day1.SetNewDirection(-90);
            Assert.AreEqual(Direction.South, _day1.CurrentDirection);
            _day1.SetNewDirection(-90);
            Assert.AreEqual(Direction.East, _day1.CurrentDirection);
            _day1.SetNewDirection(-90);
            Assert.AreEqual(Direction.North, _day1.CurrentDirection);
            
        }

        [Test]
        public void CalculateNewLocation_North()
        {
            _day1.CurrentDirection = Direction.North;
            _day1.UpdateLocation(3);
            Assert.AreEqual(3, _day1.CurrentLocation.Y);
            Assert.AreEqual(0, _day1.CurrentLocation.X);
        }

        [Test]
        public void CalculateNewLocation_East()
        {
            _day1.CurrentDirection = Direction.East;
            _day1.UpdateLocation(3);
            Assert.AreEqual(0, _day1.CurrentLocation.Y);
            Assert.AreEqual(3, _day1.CurrentLocation.X);
        }

        [Test]
        public void CalculateNewLocation_South()
        {
            _day1.CurrentDirection = Direction.South;
            _day1.UpdateLocation(3);
            Assert.AreEqual(-3, _day1.CurrentLocation.Y);
            Assert.AreEqual(0, _day1.CurrentLocation.X);
        }

        [Test]
        public void CalculateNewLocation_West()
        {
            _day1.CurrentDirection = Direction.West;
            _day1.UpdateLocation(3);
            Assert.AreEqual(0, _day1.CurrentLocation.Y);
            Assert.AreEqual(-3, _day1.CurrentLocation.X);
        }

        [Test]
        public void FirstVisitedDistance()
        {
            var result = _day1.FirstVisitedDistance("R8, R4, R4, R8");
            Assert.AreEqual(4, result);
        }
    }
}
