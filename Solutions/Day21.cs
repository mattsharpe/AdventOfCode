/*
    --- Day 21: Scrambled Letters and Hash ---

    The computer system you're breaking into uses a weird scrambling function to store its passwords. 
    It shouldn't be much trouble to create your own scrambled password so you can add it to the system; 
    you just have to implement the scrambler.

    The scrambling function is a series of operations (the exact list is provided in your puzzle input). 
    Starting with the password to be scrambled, apply each operation in succession to the string. 
    The individual operations behave as follows:

    swap position X with position Y means that the letters at indexes X and Y (counting from 0) should be swapped.
    swap letter X with letter Y means that the letters X and Y should be swapped (regardless of where they appear in the string).
    rotate left/right X steps means that the whole string should be rotated; for example, one right rotation would turn abcd into dabc.
    rotate based on position of letter X means that the whole string should be rotated to the right based on the index of letter X (counting from 0) as determined before this instruction does any rotations. Once the index is determined, rotate the string to the right one time, plus a number of times equal to that index, plus one additional time if the index was at least 4.
    reverse positions X through Y means that the span of letters at indexes X through Y (including the letters at X and Y) should be reversed in order.
    move position X to position Y means that the letter which is at index X should be removed from the string, then inserted such that it ends up at index Y.
    For example, suppose you start with abcde and perform the following operations:

    swap position 4 with position 0 swaps the first and last letters, producing the input for the next step, ebcda.
    swap letter d with letter b swaps the positions of d and b: edcba.
    reverse positions 0 through 4 causes the entire string to be reversed, producing abcde.
    rotate left 1 step shifts all letters left one position, causing the first letter to wrap to the end of the string: bcdea.
    move position 1 to position 4 removes the letter at position 1 (c), then inserts it at position 4 (the end of the string): bdeac.
    move position 3 to position 0 removes the letter at position 3 (a), then inserts it at position 0 (the front of the string): abdec.
    rotate based on position of letter b finds the index of letter b (1), then rotates the string right once plus a number of times equal to that index (2): ecabd.
    rotate based on position of letter d finds the index of letter d (4), then rotates the string right once, plus a number of times equal to that index, plus an additional time because the index was at least 4, for a total of 6 right rotations: decab.
    After these steps, the resulting scrambled password is decab.

    Now, you just need to generate a new scrambled password and you can access the system. Given the list of scrambling operations in your puzzle input, what is the result of scrambling abcdefgh?

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2016.Utilities;

namespace AdventOfCode2016.Solutions
{
    public class Day21
    {
        private readonly Regex _swapLetter = new Regex(@"swap letter (\w) with letter (\w)");
        private readonly Regex _swapPosition = new Regex(@"swap position (\d) with position (\d)");
        private readonly Regex _reversePostions = new Regex(@"reverse positions (\d) through (\d)");
        private readonly Regex _rotate = new Regex(@"rotate (\w*) (\d) step");
        private readonly Regex _advancedRotateRegex = new Regex(@"rotate based on position of letter (\w)");
        private readonly Regex _movePosition = new Regex(@"move position (\d) to position (\d)");

        private List<char> _password;

        public string Password
        {
            get
            {
                return new string(_password.ToArray());
            }
            set
            {
                _password = new List<char>(value);
            }
        }

        public void Solve(string[] instructions)
        {
            instructions.ForEach(x =>
            {
                ProcessInstruction(x);
            });
        }

        public void ProcessInstruction(string instruction, bool invert = false)
        {
            
            if (_swapLetter.IsMatch(instruction))
            {
                SwapLetter(instruction);
            }
            else if (_swapPosition.IsMatch(instruction))
            {
                SwapPosition(instruction);
            }
            else if (_rotate.IsMatch(instruction))
            {
                Rotate(instruction, invert);
            }
            else if (_advancedRotateRegex.IsMatch(instruction))
            {
                Password = AdvancedRotate(instruction, null, invert);
            }
            else if (_reversePostions.IsMatch(instruction))
            {
                ReversePositions(instruction);
            }
            else if (_movePosition.IsMatch(instruction))
            {
                MovePosition(instruction, invert);
            }
            else
            {
                throw new Exception($"No instructions have matched, not sure what to do with \r\"{instruction}\"");
            }
            //swap position X with position Y 
            //swap letter X with letter Y 
            //rotate left/ right X steps 
            //rotate based on position of letter X 
            //reverse positions X through Y 
            //move position X to position Y 
        }

        public void SwapPosition(string instruction)
        {
            var match = _swapPosition.Match(instruction);
            var first = Convert.ToInt32(match.Groups[1].Value);
            var second = Convert.ToInt32(match.Groups[2].Value);
            var firstChar = Password[first];
            var secondChar = Password[second];
            
            _password[first] = secondChar;
            _password[second] = firstChar;
        }

        public void SwapLetter(string instruction, bool invert = false)
        {
            
            var match = _swapLetter.Match(instruction);
            var firstLetter = match.Groups[1].Value[0];
            var secondLetter = match.Groups[2].Value[0];

            for (var i = 0; i < Password.Length; i++)
            {
                if (Password[i] == firstLetter)
                {
                    _password[i] = secondLetter;
                    continue;
                }
                if (Password[i] == secondLetter) _password[i] = firstLetter;
            }
        }

        public void Rotate(string instruction, bool invert = false)
        {
            var match = _rotate.Match(instruction);
            var direction = match.Groups[1].Value;
            var steps = Convert.ToInt32(match.Groups[2].Value);
            if (invert)
            {
                direction = direction == "right" ? "left" : "right";
            }
            var password = Password;
            Password = direction.ToLower() == "right" ?
                RotateRight(password, steps) : 
                RotateLeft(password, steps);
        }

        private string RotateLeft(string password, int steps)
        {
            if (steps > password.Length) steps = steps % password.Length;
            var result = password.Substring(steps, password.Length - steps);
            result += password.Substring(0, steps);
            return result;
        }

        private string RotateRight(string password, int steps)
        {
            if (steps > password.Length) steps = steps % password.Length;
            var result = password.Substring(password.Length - steps);
            result += password.Substring(0, password.Length - steps);
            return result;
        }

        public string AdvancedRotate(string instruction, string password = null, bool invert = false)
        {
            password = password ?? Password;
            //rotate based on position of letter X means that the whole string should be rotated to the right 
            //based on the index of letter X(counting from 0) as determined before this instruction does any rotations. 
            //Once the index is determined, rotate the string to the right one time, plus a number of times equal to that index, 
            //plus one additional time if the index was at least 4.
            
            if (invert)
            {
                return AdvancedRotateInverse(instruction);
                
            }

            var match = _advancedRotateRegex.Match(instruction);
            var characterToFind = Convert.ToChar(match.Groups[1].Value);

            var stepsToRotate = 1 +
                password.IndexOf(characterToFind) +
                (password.IndexOf(characterToFind) >= 4 ? 1 : 0);

            return RotateRight(password, stepsToRotate);
        }

        private string AdvancedRotateInverse(string instruction)
        {
            //rotate one to the left and check if the result matches our current password.

            var currentPassword = Password;

            var adjusted = RotateLeft(Password, 1);
            while (AdvancedRotate(instruction, adjusted) != currentPassword)
            {
                adjusted = RotateLeft(adjusted, 1);
            }
            return adjusted;
        }

        public void ReversePositions(string instruction)
        {
            var match = _reversePostions.Match(instruction);
            var first = Convert.ToInt32(match.Groups[1].Value);
            var second = Convert.ToInt32(match.Groups[2].Value);

            _password.Reverse(first,second - first + 1);
        }

        public void MovePosition(string instruction, bool invert = false)
        {
            var match = _movePosition.Match(instruction);

            var startIndex = Convert.ToInt32(match.Groups[1].Value);
            var destinationIndex = Convert.ToInt32(match.Groups[2].Value);

            
            var word = new List<char>(Password);
            var character = word[startIndex];
            if (invert)
            {
                character = word[destinationIndex];
                word.RemoveAt(destinationIndex);
                word.Insert(startIndex, character);
            }
            else
            {
                word.RemoveAt(startIndex);
                word.Insert(destinationIndex, character);
            }

            _password = word;
            
        }

        public void Unscramble(IEnumerable<string> instructions)
        {
            Console.WriteLine(Password);
            instructions.Reverse().ForEach(x =>
            {
                ProcessInstruction(x, true);
            });
        }
    }
}
