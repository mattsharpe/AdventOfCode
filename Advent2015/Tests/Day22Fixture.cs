using System;
using System.Collections.Generic;
using System.Linq;
using Advent2015.Solutions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2015.Tests
{
    [TestClass]
    public class Day22Fixture
    {
        private Day22 _day22;

        [TestInitialize]
        public void Initialize()
        {
            _day22 = new Day22();
        }

        [TestMethod]
        public void NarrowVictory()
        {
            var state = new GameState
            {
                PlayerHitPoints = 10,
                PlayerMana = 250,
                BossHitPoints = 13,
                BossDamage = 8,
                Debug = true
            };

            var spellChain = new[] { "Poison", "Magic Missile" };

            foreach (var spell in spellChain)
            {
                state.ProcessTurn(_day22.Grimoire.Single(x => x.Name == spell));
            }

            CollectionAssert.AreEqual(spellChain, state.SpellChain.Select(spell => spell.Name).ToList());
            Assert.AreEqual(state.ManaSpent, 226);
        }

        [TestMethod]
        public void LongerFightVictory()
        {
            var state = new GameState
            {
                PlayerHitPoints = 10,
                PlayerMana = 250,
                BossHitPoints = 14,
                BossDamage = 8,
                Debug = true
            };

            var spellChain = new[] { "Recharge", "Shield", "Drain", "Poison", "Magic Missile" };

            foreach (var spell in spellChain)
            {
                state.ProcessTurn(_day22.Grimoire.Single(x => x.Name == spell));
            }

            CollectionAssert.AreEqual(spellChain, state.SpellChain.Select(spell => spell.Name).ToList());
            Assert.AreEqual(state.ManaSpent, 641);

        }


        [TestMethod]
        public void WinningFight()
        {
            var state = new GameState
            {
                PlayerHitPoints = 50,
                PlayerMana = 500,
                BossHitPoints = 58,
                BossDamage = 9,
                Debug = true
            };

            var spellChain = new[] { "Poison", "Magic Missile", "Recharge", "Poison", "Shield", "Recharge", "Poison", "Drain", "Magic Missile" };

            foreach (var spell in spellChain)
            {
                state.ProcessTurn(_day22.Grimoire.Single(x => x.Name == spell));
            }

            CollectionAssert.AreEqual(spellChain, state.SpellChain.Select(spell => spell.Name).ToList());
            
            Assert.AreEqual(state.ManaSpent, 1269);
        }

        [TestMethod]
        public void AvailableSpellsExcludesThoseThatAreActive()
        {
            var state = new GameState{PlayerMana = 300};
            state.ActiveSpells.Add(new Spell("Poison", 173, 3, duration: 6), 6);

            var spells = _day22.AvailableSpells(state).ToList();

            Assert.AreEqual(4, spells.Count());
            Assert.IsFalse(spells.Any(x=>x.Name == "Poison"));
        }

        [TestMethod]
        public void AvailableSpellsIncludesAboutToExpire()
        {
            var state = new GameState{PlayerMana = 300};
            state.ActiveSpells.Add(new Spell ("Poison", 173, 3, duration: 1), 1);

            var spells = _day22.AvailableSpells(state).ToList();

            Assert.AreEqual(5, spells.Count());
            Assert.IsTrue(spells.Any(x=>x.Name == "Poison"));
        }

        [TestMethod]
        public void LowestManaSpentToWin()
        {
            var state = new GameState
            {
                PlayerHitPoints = 50,
                PlayerMana = 500,
                BossHitPoints = 58,
                BossDamage = 9,
                Debug = false
            };

            var spellChain = new[] { "Poison", "Recharge", "Magic Missile", "Poison", "Recharge", "Shield", "Poison", "Drain", "Magic Missile" };

            var result = _day22.LeastAmountOfManaToWin(state);
            var actualSpells = result.SpellChain.Select(spell => spell.Name).ToList();
            

            CollectionAssert.AreEqual(spellChain, actualSpells);
            Assert.AreEqual(1269, result.ManaSpent);
        }

    }
}