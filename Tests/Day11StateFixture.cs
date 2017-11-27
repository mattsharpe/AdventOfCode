using System.Collections.Generic;
using AdventOfCode2016.Utilities.Day11;
using NUnit.Framework;

namespace AdventOfCode2016.Tests
{
    [TestFixture]
    class Day11StateFixture
    {
        [TestCaseSource(nameof(TestData))]
        public void StateEquality(State a, State b)
        {
            Assert.That(Equals(a, b));
        }

        [TestCaseSource(nameof(TestData))]
        public void StateHashCodeEquality(State a, State b)
        {
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
        }
        
        [TestCaseSource(nameof(TestData))]
        public void StateSetEquality(State a, State b)
        {
            var set = new HashSet<State> { a };
            Assert.That(set.Contains(b));
        }
        
        [TestCaseSource(nameof(MismatchedTestCaseData))]
        public void StateInequality(State a, State b)
        {
            Assert.IsFalse(Equals(a,b));
        }

        [TestCaseSource(nameof(MismatchedTestCaseData))]
        public void StateHashCodeInequality(State a, State b)
        {
            Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode());
        }

        [TestCaseSource(nameof(MismatchedTestCaseData))]
        public void StateSetInequality(State a, State b)
        {
            var set = new HashSet<State> { a };
            Assert.IsFalse(set.Contains(b));
        }
        
        public static IEnumerable<TestCaseData> TestData()
        {
            yield return new TestCaseData(new State(), new State()) {TestName = "Empty States"};
            yield return new TestCaseData(new State {CurrentFloor = 1}, new State {CurrentFloor = 1}) {TestName = "Simple Comparison"};
            yield return new TestCaseData(Day11Fixture.SampleData, Day11Fixture.SampleData.Clone(false)){TestName = "Cloned Sample Data"};
            yield return new TestCaseData(Day11Fixture.Part1StartState, Day11Fixture.Part1StartState.Clone(false)){TestName = "Cloned Part 1 Data"};
        }

        public static IEnumerable<TestCaseData> MismatchedTestCaseData()
        {
            yield return new TestCaseData(Day11Fixture.SampleData, Day11Fixture.Part1StartState) {TestName = "Mismatched start state"};
        }

        [Test]
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

        [Test]
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

        [Test]
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

            State.Elements = new[] {"Hy", "Li"};
            var state1 = new State {Items = new[] {1, 0, 2, 0}};
            var state2 = new State {Items = new[] {2, 0, 1, 0}};

            Assert.That(state1.Equals(state2));
            Assert.AreEqual(state1.GetHashCode(), state2.GetHashCode());
            var set = new HashSet<State> {state1};
            Assert.That(set.Contains(state1));
            Assert.That(set.Contains(state2));
        }
    }
}
