using Advent2019.Solutions;
using Advent2019.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2019.Tests
{
    [TestClass]
    public class Day01Tests
    {
        private Day01 _day1;

        [TestInitialize] 
        public void Initialize() => _day1 = new Day01();

        [TestMethod]
        public void TotalFuelRequirement()
        {
            var input = FileReader.ReadFile("day01.txt");
            Assert.AreEqual(3372695,_day1.TotalFuelRequirement(input));
        }

        [DataTestMethod]
        [DataRow(12, 2)]
        [DataRow(14, 2)]
        [DataRow(1969, 654)]
        [DataRow(100756, 33583)]
        public void FuelForModule(int mass, int expected)
        {
            Assert.AreEqual(expected, _day1.CalculateFuel(mass));
        }

        [DataTestMethod]
        [DataRow(14, 2)]
        [DataRow(1969, 966)]
        [DataRow(100756, 50346)]
        public void FuelForModuleWithExtraFuel(int mass, int expected)
        {
            Assert.AreEqual(expected, _day1.CalculateFuelWithExtra(mass));
        }

        
        [TestMethod]
        public void TotalFuelRequirementWithAdditionalFuel()
        {
            var input = FileReader.ReadFile("day01.txt");
            Assert.AreEqual(5056172, _day1.TotalFuelRequirementWithExtra(input));
        }
    }
}
