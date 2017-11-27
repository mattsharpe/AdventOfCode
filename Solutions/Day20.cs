using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2016.Solutions
{
    /*
     * --- Day 20: Firewall Rules ---

You'd like to set up a small hidden computer here so you can use it to get back into the network later. 
However, the corporate firewall only allows communication with certain external IP addresses.

You've retrieved the list of blocked IPs from the firewall, but the list seems to be messy and poorly maintained, 
and it's not clear which IPs are allowed. Also, rather than being written in dot-decimal notation, 
they are written as plain 32-bit integers, which can have any value from 0 through 4294967295, inclusive.

For example, suppose only the values 0 through 9 were valid, and that you retrieved the following blacklist:

5-8
0-2
4-7
The blacklist specifies ranges of IPs (inclusive of both the start and end value) that are not allowed. 
Then, the only IPs that this firewall allows are 3 and 9, since those are the only numbers not in any range.

Given the list of blocked IPs you retrieved from the firewall (your puzzle input), 
what is the lowest-valued IP that is not blocked?

*/
    public class Day20
    {
        
        public long Solve(string[] ranges, bool returnCount = false)
        {
            var blacklist = BlockedRanges(ranges).ToList();

            long result = 0;
            var range = blacklist.FirstOrDefault(x => x.Lower <= result && x.Upper >= result);
            var count = 0;
            while (result <= uint.MaxValue)
            {
                while (range != null)
                {
                    result = range.Upper + 1;
                    range = blacklist.FirstOrDefault(x => x.Lower <= result && x.Upper >= result);
                }
                //if we're only after hte first match, return it (Part 1)
                if(!returnCount) return result;

                if (result <= 4294967295)
                {
                    //increment the count of valid IPs and move onto the next number
                    count++;
                    result++;
                    //check if this is in a banned range and back to the top of the loop
                    range = blacklist.FirstOrDefault(x => x.Lower <= result && x.Upper >= result);
                }
            }
            return count;
        }

        public IEnumerable<NumberRange> BlockedRanges(string[] ranges)
        {
            
            foreach (var blockedRange in ranges)
            {
                var numbers = blockedRange.Split('-');
                var lower = Convert.ToInt64(numbers[0]);
                var upper = Convert.ToInt64(numbers[1]);
                
                yield return new NumberRange {Lower = lower, Upper = upper};
            }
        }
    }

    public class NumberRange
    {
        public long Lower { get; set; }
        public long Upper { get; set; }

        public bool IsInRange(long input)
        {
            return input >= Lower && input <= Upper;
        }
    }


}
