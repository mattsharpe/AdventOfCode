using Advent2018.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day9Tests
    {
        private readonly Day9 _day9 = new Day9();
        
        //9 players; last marble is worth 23 points: high score is 32
        [TestMethod]
        public void SampleData()
        {
            Assert.AreEqual(32, _day9.PlayMarbles(9, 25));
        }

        [DataTestMethod]
        [DataRow(10, 1618, 8317)]
        [DataRow(13, 7999, 146373)]
        [DataRow(17, 1104, 2764)]
        [DataRow(21, 6111, 54718)]
        [DataRow(30, 5807, 37305)]
        public void SampleDataSet(int players, int lastMarble, int score)
        {
            Assert.AreEqual(score, _day9.PlayMarbles(players, lastMarble));
        }

        [TestMethod]
        public void PlayingMarbles()
        {
            //416 players; last marble is worth 71617 points
            Assert.AreEqual(436720, _day9.PlayMarbles(416, 71617));
        }

        [TestMethod]
        public void PlayingMarblesPart2()
        {
            //416 players; last marble is worth 71617 points
            Assert.AreEqual(3527845091, _day9.PlayMarbles(416, 7161700));
        }
    }
}
