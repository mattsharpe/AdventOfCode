using Advent2015.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day21Fixture
    {
        private Day21 _day21;

        [TestInitialize]
        public void Initialize()
        {
            _day21 = new Day21();
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(78, _day21.MinimumSpendToWin());
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(148, _day21.Part2());
        }

        [TestMethod]
        public void PlayerWins()
        {
            //For example, suppose you have 8 hit points, 5 damage, and 5 armor, and that the boss has 12 hit points, 7 damage, and 2 armor:
            _day21.Boss = new Boss { HitPoints = 12, Damage = 7, Armour = 2 };
            var player = new Fighter { HitPoints = 8, Damage = 5, Armour = 5 };
            
            var result  =_day21.PlayerWins(player);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FailingFirstPass()
        {
            // First run generates 76 as the answer
            //Warhammer; Chainmail; None; Defense + 1 = Armour: 3, Damage: 6, Cost: 76
            
            _day21.Boss = new Boss { HitPoints = 104, Damage = 8, Armour = 1 };
            var player = new Fighter { HitPoints = 100, Damage = 6, Armour = 3 };

            var result = _day21.PlayerWins(player);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void CorrectAnswer()
        {
            //Longsword; Leather; None; Damage + 1 = Armour: 1, Damage: 8, Cost: 78            

            _day21.Boss = new Boss { HitPoints = 104, Damage = 8, Armour = 1 };
            var player = new Fighter { HitPoints = 100, Damage = 8, Armour = 1 };

            var result = _day21.PlayerWins(player);
            Assert.IsTrue(result);
        }
    }
}
