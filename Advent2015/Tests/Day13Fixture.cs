using Advent2015.Solutions;
using Advent2015.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day13Fixture
    {
        private Day13 _day13;

        private static readonly string[] SampleData = 
        {
            "Alice would gain 54 happiness units by sitting next to Bob",
            "Alice would lose 79 happiness units by sitting next to Carol.",
            "Alice would lose 2 happiness units by sitting next to David.",
            "Bob would gain 83 happiness units by sitting next to Alice.",
            "Bob would lose 7 happiness units by sitting next to Carol.",
            "Bob would lose 63 happiness units by sitting next to David.",
            "Carol would lose 62 happiness units by sitting next to Alice.",
            "Carol would gain 60 happiness units by sitting next to Bob.",
            "Carol would gain 55 happiness units by sitting next to David.",
            "David would gain 46 happiness units by sitting next to Alice.",
            "David would lose 7 happiness units by sitting next to Bob.",
            "David would gain 41 happiness units by sitting next to Carol."
        };
        
        [TestInitialize]
        public void Initialize() => _day13 = new Day13();
        
        [TestMethod]
        public void PotentialHappinessSample()
        {
            _day13.CalculatePotentialHappiness(SampleData);
            Assert.AreEqual(330, _day13.FindBestOption());
        }

        [TestMethod]
        public void CalculateHappinessForDiners()
        {
            var input = FileReader.ReadFile("day13.txt");
            _day13.CalculatePotentialHappiness(input);
            Assert.AreEqual(664, _day13.FindBestOption());
        }

        [TestMethod]
        public void CalculateHappinessForDinersIfTheyHaveToEatWithMattAsWell()
        {
            var input = FileReader.ReadFile("day13.txt");
            _day13.CalculatePotentialHappinessWithMatt(input);
            Assert.AreEqual(640, _day13.FindBestOption());
        }
    }
}