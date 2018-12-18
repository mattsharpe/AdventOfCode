using System.Collections.Generic;
using System.Linq;
using Advent2018.Utilities;

namespace Advent2018.Solutions
{
    public class Day9
    {
        LinkedListNode<int> FindNextMarble(LinkedListNode<int> node, int amount)
        {
            Enumerable.Range(0, amount).ForEach(x => node = node.Next ?? node.List.First);
            return node;
        }

        LinkedListNode<int> Previous(LinkedListNode<int> node)
        {
            Enumerable.Range(0,7).ForEach(x=> node = node.Previous ?? node.List.Last);
            return node;
        }

        public long PlayMarbles(int players, int lastMarble)
        {
            var scores = new long[players];
            var currentPlayer = 0;

            var marbles = new LinkedList<int>();
            marbles.AddFirst(0);
            var currentMarble = marbles.First;
            
            for (var i = 1; i <= lastMarble; i++)
            {
                if (i % 23 == 0)
                {
                    scores[currentPlayer] += i;
                    var sevenBack = Previous(currentMarble);
                    scores[currentPlayer] += sevenBack.Value;
                    currentMarble = sevenBack.Next ?? marbles.First;
                    marbles.Remove(sevenBack);
                }
                else
                {
                    marbles.AddAfter(FindNextMarble(currentMarble, 1), i);
                    currentMarble = marbles.Find(i);
                }

                currentPlayer = (currentPlayer + 1) % players;
            }

            return scores.Max();
        }
    }
}
