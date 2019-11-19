using Advent2015.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day15Fixture
    {
        private Day15 _day15;

        private readonly string[] _sample =
        {
            "Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8",
            "Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3"
        };

        private readonly string[] _input =
        {
            "Sugar: capacity 3, durability 0, flavor 0, texture -3, calories 2",
            "Sprinkles: capacity -3, durability 3, flavor 0, texture 0, calories 9",
            "Candy: capacity -1, durability 0, flavor 4, texture 0, calories 1",
            "Chocolate: capacity 0, durability 0, flavor -2, texture 2, calories 8"
        };

        [TestInitialize]
        public void Initialize() => _day15 = new Day15();


        [TestMethod]
        public void BestCookieRecipeSample()
        {
            Assert.AreEqual(62842880, _day15.BakeBestCookie(_sample));
        }

        [TestMethod]
        public void BestCookieRecipePart1()
        {
            Assert.AreEqual(222870, _day15.BakeBestCookie(_input));
        }

        
        [TestMethod]
        public void BestLowCalorieCookieRecipeSample()
        {
            Assert.AreEqual(57600000, _day15.BakeBestCookie(_sample, true));
        }

        [TestMethod]
        public void BestLowCalorieCookieRecipePart1()
        {
            Assert.AreEqual(117936, _day15.BakeBestCookie(_input, true));
        }
    }
}
