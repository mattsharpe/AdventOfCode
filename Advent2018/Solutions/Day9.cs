using System.Collections.Generic;
using System.Linq;
using Advent2018.Utilities;

namespace Advent2018.Solutions
{
    public class Day9
    {
        public long PlayMarbles(int players, int lastMarble)
        {
            var scores = new long[players];
            
            var currentPlayer = 1;

            var currentMarble = new Marble
            {
                Id = 0
            };

            currentMarble.Left = currentMarble;
            currentMarble.Right = currentMarble;

            for (var i = 1; i <= lastMarble; i++)
            {
                //current marble is number 1
                if (i % 23 == 0)
                {
                    scores[currentPlayer] += i;

                    //rotate and add the score for that marble
                    Enumerable.Range(0, 7).ForEach(x => currentMarble = currentMarble.Left);
                    scores[currentPlayer] += currentMarble.Id;

                    // Remove the marble 
                    currentMarble.Left.Right = currentMarble.Right;
                    currentMarble.Right.Left = currentMarble.Left;
                    currentMarble = currentMarble.Right;
                }
                else
                {
                    currentMarble = currentMarble.Right;
                    var next = new Marble { Id = i, Left = currentMarble, Right = currentMarble.Right};

                    currentMarble.Right.Left = next;
                    currentMarble.Right = next;

                    currentMarble = next;
                }
                currentPlayer = (currentPlayer + 1) % players;
            }
            return scores.Max();
        }
    }

    public class Marble
    {
        public int Id { get; set; }
        public Marble Left { get; set; }
        public Marble Right { get; set; }
    }
}
