using Advent2015.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day14Fixture
    {
        private Day14 _day14;

        [TestInitialize]
        public void Initialize() => _day14 = new Day14();
        
        private readonly string[] _sample = 
        {
            "Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.",
            "Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds."
        };

        private readonly string[] _input = 
        {
            "Rudolph can fly 22 km/s for 8 seconds, but then must rest for 165 seconds.",
            "Cupid can fly 8 km/s for 17 seconds, but then must rest for 114 seconds.",
            "Prancer can fly 18 km/s for 6 seconds, but then must rest for 103 seconds.",
            "Donner can fly 25 km/s for 6 seconds, but then must rest for 145 seconds.",
            "Dasher can fly 11 km/s for 12 seconds, but then must rest for 125 seconds.",
            "Comet can fly 21 km/s for 6 seconds, but then must rest for 121 seconds.",
            "Blitzen can fly 18 km/s for 3 seconds, but then must rest for 50 seconds.",
            "Vixen can fly 20 km/s for 4 seconds, but then must rest for 75 seconds.",
            "Dancer can fly 7 km/s for 20 seconds, but then must rest for 119 seconds."
        };

        [TestMethod]
        public void SampleDataOneSecond()
        {
            _day14.ParseReindeer(_sample);
            _day14.Simulate(1);
            Assert.AreEqual(16, _day14.DistanceWinningReindeerHasTraveled());
        }

        [TestMethod]
        public void SampleDataTenSeconds()
        {
            _day14.ParseReindeer(_sample);
            _day14.Simulate(10);
            Assert.AreEqual(160, _day14.DistanceWinningReindeerHasTraveled());
        }

        [TestMethod]
        public void SampleDataThousandSeconds()
        {
            _day14.ParseReindeer(_sample);
            _day14.Simulate(1000);
            Assert.AreEqual(1120, _day14.DistanceWinningReindeerHasTraveled());
        }

        [TestMethod]
        public void ReindeerRacePart1()
        {
            _day14.ParseReindeer(_input);
            _day14.Simulate(2503);
            Assert.AreEqual(2696, _day14.DistanceWinningReindeerHasTraveled());
        }

        [TestMethod]
        public void Part2Sample()
        {
            _day14.ParseReindeer(_sample);
            _day14.Simulate(1000);
            Assert.AreEqual(689, _day14.WinningReindeerScore());
        }

        [TestMethod]
        public void Part2()
        {
            _day14.ParseReindeer(_input);
            _day14.Simulate(2503);
            Assert.AreEqual(1084, _day14.WinningReindeerScore());
        }
    }
}