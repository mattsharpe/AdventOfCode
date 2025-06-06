﻿using System;
using System.Text;
using Advent2016.Utilities;

namespace Advent2016.Solutions
{
/*
--- Day 2: Bathroom Security ---

You arrive at Easter Bunny Headquarters under cover of darkness. However, you left in such a rush that you forgot to use the bathroom! Fancy office buildings like this one usually have keypad locks on their bathrooms, so you search the front desk for the code.

"In order to improve security," the document you find says, "bathroom codes will no longer be written down. Instead, please memorize and follow the procedure below to access the bathrooms."

The document goes on to explain that each button to be pressed can be found by starting on the previous button and moving to adjacent buttons on the keypad: U moves up, D moves down, L moves left, and R moves right. Each line of instructions corresponds to one button, starting at the previous button (or, for the first line, the "5" button); press whatever button you're on at the end of each line. If a move doesn't lead to a button, ignore it.

You can't hold it much longer, so you decide to figure out the code as you walk to the bathroom. You picture a keypad like this:

1 2 3
4 5 6
7 8 9
Suppose your instructions are:

ULL
RRDDD
LURDL
UUUUD
You start at "5" and move up (to "2"), left (to "1"), and left (you can't, and stay on "1"), so the first button is 1.
Starting from the previous button ("1"), you move right twice (to "3") and then down three times (stopping at "9" after two moves and ignoring the third), ending up with 9.
Continuing from "9", you move left, up, right, down, and left, ending with 8.
Finally, you move up four times (stopping at "2"), then down once, ending with 5.
So, in this example, the bathroom code is 1985.

Your puzzle input is the instructions from the document you found at the front desk. What is the bathroom code?

Your puzzle answer was 52981.

--- Part Two ---

You finally arrive at the bathroom (it's a several minute walk from the lobby so visitors can behold the many fancy conference rooms and water coolers on this floor) and go to punch in the code. Much to your bladder's dismay, the keypad is not at all like you imagined it. Instead, you are confronted with the result of hundreds of man-hours of bathroom-keypad-design meetings:

    1
  2 3 4
5 6 7 8 9
  A B C
    D
You still start at "5" and stop when you're at an edge, but given the same instructions as above, the outcome is very different:

You start at "5" and don't move at all (up and left are both edges), ending at 5.
Continuing from "5", you move right twice and down three times (through "6", "7", "B", "D", "D"), ending at D.
Then, from "D", you move five more times (through "D", "B", "C", "C", "B"), ending at B.
Finally, after five more moves, you end at 3.
So, given the actual keypad layout, the code would be 5DB3.

Using the same instructions in your puzzle input, what is the correct bathroom code?

Your puzzle answer was 74CD2.

*/
    public class Day02
    {
        // 1 2 3
        // 4 5 6
        // 7 8 9
        public int CurrentKey { get; set; }
        public Location CurrentLocation { get; set; } = new Location(1, 1);
        private int[,] _keys = new int[3, 3]
        {
            {1,2,3},
            {4,5,6},
            {7,8,9},
        };
        
        public int CalculateDoorCode(string input)
        {
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new StringBuilder();
            foreach(var line in lines)
            {
                ProcessLine(line);
                result.Append(GetCurrentKeyPadNumber());
            }
            return Convert.ToInt32(result.ToString());
        }

        public int ProcessLine(string input)
        {
            var instructions = input.ToCharArray();
            foreach (var instruction in instructions)
            {
                ProcessInstruction(instruction);
                Console.WriteLine("Processed {0} now at {1},{2}, {3}", instruction, CurrentLocation.X, CurrentLocation.Y,GetCurrentKeyOnRealPad());
            }
            Console.WriteLine("---end of line---");
            return GetCurrentKeyPadNumber();
        }

        public void ProcessInstruction(char instruction)
        {
            switch (instruction)
            {
                case 'U': CurrentLocation.Y--; break;
                case 'D': CurrentLocation.Y++; break;
                case 'L': CurrentLocation.X--; break;
                case 'R': CurrentLocation.X++; break;
            }

            CurrentLocation.X = Fixify(CurrentLocation.X);
            CurrentLocation.Y = Fixify(CurrentLocation.Y);
        }
        private int Fixify(int x)
        {
            return x < 0 ? 0 : x > 2 ? 2 : x;
        }
        public int GetCurrentKeyPadNumber()
        {
            return _keys[CurrentLocation.Y, CurrentLocation.X];
        }

        //Part 2

        private string[,] _actualKeys =
        {
            {null, null, "1", null, null},
            {null, "2", "3", "4", null},
            {"5", "6", "7", "8", "9"},
            {null, "A", "B", "C", null},
            {null, null, "D", null, null}
        };

        public string CalculateRealDoorCode(string input)
        {
            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new StringBuilder();
            foreach (var line in lines)
            {
                result.Append(ProcessLineOnRealPad(line));
            }
            return result.ToString();
        }

        public string GetCurrentKeyOnRealPad()
        {
            return _actualKeys[CurrentLocation.Y, CurrentLocation.X];
        }

        public string ProcessLineOnRealPad(string input)
        {
            var instructions = input.ToCharArray();
            foreach (var instruction in instructions)
            {
                ProcessInstructionOnRealPad(instruction);
            }
            return GetCurrentKeyOnRealPad();
        }

        public void ProcessInstructionOnRealPad(char instruction)
        {
            var lastKnownGood = new Location(CurrentLocation.X, CurrentLocation.Y);

            switch (instruction)
            {
                case 'U': CurrentLocation.Y--; break;
                case 'D': CurrentLocation.Y++; break;
                case 'L': CurrentLocation.X--; break;
                case 'R': CurrentLocation.X++; break;
            }

            if (CurrentLocation.X < 0 || CurrentLocation.X > 4 || 
                CurrentLocation.Y < 0 || CurrentLocation.Y > 4 || 
                String.IsNullOrEmpty(GetCurrentKeyOnRealPad()))
            {
                //not a good place to be - head for open water!
                CurrentLocation = lastKnownGood;
            }
        }


    }
}