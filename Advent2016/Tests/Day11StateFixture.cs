using System;
using System.Collections.Generic;
using Advent2016.Utilities;
using Advent2016.Utilities.Day11;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2016.Tests
{
    [TestClass]
    public class Day11StateFixture
    {
        [DataTestMethod]
        public void StateEquality()
        {
            TestData().ForEach(x=> Assert.IsTrue(Equals(x.Item1, x.Item2)));
            
        }

        [DataTestMethod]
        public void StateHashCodeEquality()
        {
            TestData().ForEach(x => Assert.AreEqual(x.Item1.GetHashCode(), x.Item2.GetHashCode()));
        }

        [DataTestMethod]
        public void StateSetEquality()
        {
            TestData().ForEach(x =>
            {
                var set = new HashSet<State> { x.Item1 };
                Assert.IsTrue(set.Contains(x.Item2));
            });
        }
        
        [TestMethod]
        public void StateInequality()
        {
            Assert.IsFalse(Equals(Day11Fixture.SampleData, Day11Fixture.Part1StartState));
        }

        [TestMethod]
        public void StateHashCodeInequality()
        {
            Assert.AreNotEqual(Day11Fixture.SampleData.GetHashCode(), Day11Fixture.Part1StartState.GetHashCode());
        }

        [TestMethod]
        public void StateSetInequality()
        {
            var set = new HashSet<State> { Day11Fixture.SampleData };
            Assert.IsFalse(set.Contains(Day11Fixture.Part1StartState));
        }
        
        public static IEnumerable<Tuple<State,State>> TestData()
        {
            yield return new Tuple<State, State>(new State(), new State());
            yield return new Tuple<State, State>(new State {CurrentFloor = 1}, new State {CurrentFloor = 1});
            yield return new Tuple<State, State>(Day11Fixture.SampleData, Day11Fixture.SampleData.Clone(false));
            yield return new Tuple<State, State>(Day11Fixture.Part1StartState, Day11Fixture.Part1StartState.Clone(false));
        }

        [TestMethod]
        public void Clone()
        {
            var state = Day11Fixture.SampleData;
            var clone = state.Clone();
            for (int i = 0; i < state.Items.Length; i++)
            {
                Assert.AreEqual(state.Items[i],clone.Items[i]);
            }

            clone.Items[3] = 3;
            
            Assert.AreEqual(0, state.Items[3]);
        }

        [TestMethod]
        public void VisitedStates()
        {
            var set = new HashSet<State>();

            set.Add(Day11Fixture.SampleData);
            Assert.AreEqual(1, set.Count);

            set.Add(Day11Fixture.SampleData);
            Assert.AreEqual(1, set.Count);

            set.Add(Day11Fixture.SampleData.Clone());
            Assert.AreEqual(1, set.Count);
        }

        [TestMethod]
        public void EquivalentStatesGiveSameHash()
        {
            /*
                F4 .   .   .   .   .  
                F3 .   .   .   LiG .  
                F2 .   HyG .   .   .  
                F1 [E] .   HyM .   LiM
                
                is equivalent to:
                
                F4 .   .   .   .   .  
                F3 .   HyG .   .   .  
                F2 .   .   .   LiG .  
                F1 [E] .   HyM .   LiM

            */

            var state1 = new State {Items = new[] {1, 0, 2, 0}, Elements = new[] { "Hy", "Li" } };
            var state2 = new State {Items = new[] {2, 0, 1, 0}, Elements = new[] { "Hy", "Li" } };

            Assert.IsTrue(state1.Equals(state2));
            Assert.AreEqual(state1.GetHashCode(), state2.GetHashCode());
            var set = new HashSet<State> {state1};
            Assert.IsTrue(set.Contains(state1));
            Assert.IsTrue(set.Contains(state2));
        }
    }
}
