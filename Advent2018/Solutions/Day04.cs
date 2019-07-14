using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using Advent2018.Utilities;

namespace Advent2018.Solutions
{
    public class Day04
    {
        private Dictionary<int, int[]> _guards = new Dictionary<int, int[]>();

        public void ParseInDateOrder(string[] input)
        {
            var ordered = input.Select(ParseLine).OrderBy(x => x.Time);
            ProcessLogs(ordered);
        }

        internal LogEntry ParseLine(string input)
        {
            var regex = new Regex(@"\[(.*)] (.*)");
            var matches = regex.Match(input);
            var log = matches.Groups[2].Value;

            var action = log == "wakes up" ? GuardEvent.WakesUp :
                         log == "falls asleep" ? GuardEvent.FallsAsleep : 
                         GuardEvent.StartsShift;

            return new LogEntry
            {
                Time = DateTime.Parse(matches.Groups[1].Value),
                Log = log,
                Event = action
            };
        }

        private void ProcessLogs(IEnumerable<LogEntry> logEntries)
        {
            var guardNumber = new Regex(@"Guard #(\d*) begins shift");
            
            var shiftLog = new Queue<LogEntry>(logEntries);
            int currentGuard = 0;
            int fellAsleep = 0;

            while (shiftLog.Count > 0)
            {
                var guardLog = shiftLog.Dequeue();

                switch (guardLog.Event)
                {
                    case GuardEvent.StartsShift:
                        currentGuard = Convert.ToInt32(guardNumber.Match(guardLog.Log).Groups[1].Value);
                        if(!_guards.ContainsKey(currentGuard)) _guards.Add(currentGuard, new int[60]);
                        break;
                    case GuardEvent.FallsAsleep:
                        fellAsleep = guardLog.Time.Minute;
                        break;
                    case GuardEvent.WakesUp:
                        var guard = currentGuard;
                        Enumerable.Range(fellAsleep,guardLog.Time.Minute - fellAsleep).ForEach(x=> _guards[guard][x]++);
                        break;
                }
            }
        }

        public int GuardWithMostMinutesAsleep()
        {
            var mostSnoozy = _guards.OrderByDescending(x => x.Value.Sum()).First();
            var minutesAsleep = new List<int>(mostSnoozy.Value);

            return mostSnoozy.Key * minutesAsleep.IndexOf(minutesAsleep.Max());
        }

        public int WhichGuardIsMostFrequentlyAsleepOnTheSameMinute()
        {
            var mostSnoozy = _guards.OrderByDescending(x => x.Value.Max()).First();
            var minutesAsleep = new List<int>(mostSnoozy.Value);

            return mostSnoozy.Key * minutesAsleep.IndexOf(minutesAsleep.Max());
        }
    }
    public class LogEntry
    {
        public DateTime Time { get; set; }
        public string Log { get; set; }
        public GuardEvent Event { get; set; }

        public override string ToString()
        {
            return $"[{Time.Year}-{Time.Month:0#}-{Time.Day:0#} {Time.Hour:0#}:{Time.Minute:0#}] {Log}";
        }
    }

    public enum GuardEvent
    {
        StartsShift,
        FallsAsleep,
        WakesUp
    }
}
