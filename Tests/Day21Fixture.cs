﻿using System;
using AdventOfCode.Solutions;
using AdventOfCode.Utilities;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    [TestFixture]
    public class Day21Fixture
    {
        private Day21 _day21;

        [SetUp]
        public void Setup()
        {
            _day21 = new Day21();
        }

        [Test]
        public void SampleData()
        {
            string[] sample =
            {
                "swap position 4 with position 0",
                "swap letter d with letter b",
                "reverse positions 0 through 4",
                "rotate left 1 step",
                "move position 1 to position 4",
                "move position 3 to position 0",
                "rotate based on position of letter b",
                "rotate based on position of letter d"
            };
            _day21.Password = "abcde";
            _day21.Solve(sample);

            Assert.AreEqual("decab", _day21.Password);
        }

        [Test]
        public void Part1()
        {
            _day21.Password = "abcdefgh";
            _day21.Solve(FileReader.ReadFile("day 21.txt"));
            Assert.AreEqual("cbeghdaf", _day21.Password);
        }

        [Test]
        public void ParseInstruction_SwapPosition()
        {
            _day21.Password = "abcdef";
            var instruction = "swap position 1 with position 3";
            _day21.SwapPosition(instruction);
            Assert.AreEqual(_day21.Password, "adcbef");
        }
        
        [Test]
        public void ParseInstruction_SwapPosition_Sample()
        {
            _day21.Password = "abcdef";
            var instruction = "swap position 4 with position 0";
            _day21.SwapPosition(instruction);
            Assert.AreEqual(_day21.Password, "ebcdaf");
        }

        [Test]
        public void ParseInstruction_SwapLetter()
        {
            _day21.Password = "abcdef";
            var instruction = "swap letter a with letter f";
            _day21.SwapLetter(instruction);
            Assert.AreEqual(_day21.Password, "fbcdea");
        }

        [Test]
        public void ParseInstruction_Reverse()
        {
            _day21.Password = "abcdef";
            var instruction = "reverse positions 0 through 5";
            _day21.ReversePositions(instruction);
            Assert.AreEqual(_day21.Password, "fedcba");
        }

        [Test]
        public void ParseInstruction_ReverseSubset()
        {
            _day21.Password = "abcdef";
            var instruction = "reverse positions 1 through 4";
            _day21.ReversePositions(instruction);
            Assert.AreEqual(_day21.Password, "aedcbf");
        }

        [Test]
        public void ParseInstruction_RotateRight()
        {
            //rotate left/right X steps means that the whole string should be rotated; for example, one right rotation would turn abcd into dabc.
            _day21.Password = "abcd";
            var instruction = "rotate right 1 step";
            _day21.Rotate(instruction);
            Assert.AreEqual(_day21.Password, "dabc");
        }

        [Test]
        public void ParseInstruction_RotateLeft()
        {
            //rotate left/right X steps means that the whole string should be rotated; for example, one right rotation would turn abcd into dabc.
            _day21.Password = "abcd";
            var instruction = "rotate left 1 step";
            _day21.Rotate(instruction);
            Assert.AreEqual(_day21.Password, "bcda");
        }

        [Test]
        public void ParseInstruction_AdvancedRotate()
        {
            //rotate based on position of letter X
            //abcde -> abcde deabc, rotates 1 plus value of index (2)
            //abcde -> eabcd -> deabc -> cdeab
            _day21.Password = "abcde";
            var instruction = "rotate based on position of letter c";
            _day21.AdvancedRotate(instruction);
            Assert.AreEqual(_day21.Password, "cdeab");
        }

        [Test]
        public void ParseInstruction_AdvancedRotateWithIndexGreaterThan4()
        {
            //rotate based on position of letter X
            //abcde -> abcde deabc, rotates 1 plus value of index (7) plus 1
            //abcdefghijk
            //kabcdefghij - 1 
            //jkabcdefghi - 2 
            //ijkabcdefgh - 3 
            //ghijkabcdef - 4
            //fghijkabcde - 5
            //efghijkabcd - 6
            //defghijkabc - 7
            //cdefghijkab - 8
            //bcdefghijka - 9
            _day21.Password = "abcdefghijk";
            var instruction = "rotate based on position of letter h";
            _day21.AdvancedRotate(instruction);
            Assert.AreEqual(_day21.Password, "cdefghijkab");
        }

        [Test]
        public void ParseInstruction_AdancedRotate_SampleData()
        {
            _day21.Password = "abdec";
            var instruction = "rotate based on position of letter b";
            _day21.AdvancedRotate(instruction);
            Assert.AreEqual(_day21.Password, "ecabd");
        }

        [Test]
        public void ParseInstruction_AdancedRotate_SampleData_MoreThan4()
        {
            _day21.Password = "ecabd";
            var instruction = "rotate based on position of letter d";
            _day21.AdvancedRotate(instruction);
            Assert.AreEqual(_day21.Password, "decab");
        }

        [Test]
        public void ParseInstruction_MovePosition()
        {
            _day21.Password = "bcdea";
            var instruction = "move position 1 to position 4";
            _day21.MovePosition(instruction);
            Assert.AreEqual(_day21.Password, "bdeac");
            
        }
    }
}
