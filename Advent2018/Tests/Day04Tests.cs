using Advent2018.Solutions;
using Advent2018.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Advent2018.Tests
{
    [TestClass]
    public class Day04Tests
    {
        private Day04 _day04;
        private string[] _input = {"[1518-11-01 00:00] Guard #10 begins shift",
            "[1518-11-01 00:05] falls asleep",
            "[1518-11-01 00:25] wakes up",
            "[1518-11-01 00:30] falls asleep",
            "[1518-11-01 00:55] wakes up",
            "[1518-11-01 23:58] Guard #99 begins shift",
            "[1518-11-02 00:40] falls asleep",
            "[1518-11-02 00:50] wakes up",
            "[1518-11-03 00:05] Guard #10 begins shift",
            "[1518-11-03 00:24] falls asleep",
            "[1518-11-03 00:29] wakes up",
            "[1518-11-04 00:02] Guard #99 begins shift",
            "[1518-11-04 00:36] falls asleep",
            "[1518-11-04 00:46] wakes up",
            "[1518-11-05 00:03] Guard #99 begins shift",
            "[1518-11-05 00:45] falls asleep",
            "[1518-11-05 00:55] wakes up"};

        [TestInitialize]
        public void Setup()
        {
            _day04 = new Day04();
        }

        [TestMethod]
        public void CreateLogEntry()
        {
            string input = "[1518-11-01 23:59] Guard #10 begins shift";
            var result = _day04.ParseLine(input);

            Assert.AreEqual(result.Time.Year, 1518);
            Assert.AreEqual(result.Time.Month, 11);
            Assert.AreEqual(result.Time.Day, 1);

            Assert.AreEqual(result.Time.Hour, 23);
            Assert.AreEqual(result.Time.Minute, 59);

            Assert.AreEqual(input, result.ToString());

            Assert.AreEqual(result.Log, "Guard #10 begins shift");
        }

        [TestMethod]
        public void ProcessLogs()
        {
            var input = FileReader.ReadFile("day04.txt");

            _day04.ParseInDateOrder(input);
        }

        [TestMethod]
        public void SampleData()
        {
            _day04.ParseInDateOrder(_input);
            Assert.AreEqual(240, _day04.GuardWithMostMinutesAsleep());
        }

        [TestMethod]
        public void WhatIsTheIdOfTheSnooziestGuardMultipliedByTheirSnooziestMinute()
        {
            _day04.ParseInDateOrder(FileReader.ReadFile("day04.txt"));
            Assert.AreEqual(21083, _day04.GuardWithMostMinutesAsleep());
        }

        [TestMethod]
        public void WhichGuardIsMostFrequentlyAsleepOnTheSameMinute_Sample()
        {
            _day04.ParseInDateOrder(_input);
            Assert.AreEqual(4455, _day04.WhichGuardIsMostFrequentlyAsleepOnTheSameMinute());
        }

        [TestMethod]
        public void WhichGuardIsMostFrequentlyAsleepOnTheSameMinute()
        {
            _day04.ParseInDateOrder(FileReader.ReadFile("day04.txt"));
            Assert.AreEqual(53024, _day04.WhichGuardIsMostFrequentlyAsleepOnTheSameMinute());
        }
    }
}

