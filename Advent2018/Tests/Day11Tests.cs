using Advent2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day11Tests
    {
        private Day11 _day11;

        [TestInitialize]
        public void Setup()
        {
            _day11 = new Day11();
        }

        [DataTestMethod]
        [DataRow(3, 5, 8, 4)]
        [DataRow(122, 79, 57, -5)]
        [DataRow(217, 196, 39, 0)]
        [DataRow(101, 153, 71, 4)]
        public void FuelCellPowerLevels(int x, int y, int serialNumber, int expected)
        {
            _day11.SerialNumber = serialNumber;
            var power = _day11.CalculatePower(x, y);
            Assert.AreEqual(expected, power);
        }
        
        [TestMethod]
        public void FindMaxPowerSample()
        {
            _day11.SerialNumber = 18;
            var result = _day11.Solve();

            Assert.AreEqual(29, result.Power);
            Assert.AreEqual(33, result.X);
            Assert.AreEqual(45, result.Y);
        }

        [TestMethod]
        public void FindMaxPowerSample2()
        {
            _day11.SerialNumber = 42;
            var result = _day11.Solve();

            Assert.AreEqual(30, result.Power);
            Assert.AreEqual(21, result.X);
            Assert.AreEqual(61, result.Y);
        }

        [TestMethod]
        public void FindMaxPower()
        {
            _day11.SerialNumber = 9306;
            var result = _day11.Solve();

            Assert.AreEqual(30, result.Power);
            Assert.AreEqual(235, result.X);
            Assert.AreEqual(38, result.Y);
        }

        [TestMethod]
        public void Solve()
        {
            _day11.SerialNumber = 18;
            var result = _day11.Solve();
            
            Assert.AreEqual(33, result.X);
            Assert.AreEqual(45, result.Y);
            Assert.AreEqual(3, result.Size);
        }

        [TestMethod]
        public void SolvePart2()
        {
            _day11.SerialNumber = 9306;
            var result = _day11.Solve(300);
            
            Assert.AreEqual(233, result.X);
            Assert.AreEqual(146, result.Y);
            Assert.AreEqual(13, result.Size);
        }
    }
}