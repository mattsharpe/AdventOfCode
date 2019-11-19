using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2015.Solutions
{
    class Day14
    {
        private List<Reindeer> _reindeer;

        public void ParseReindeer(string[] input)
        {
            _reindeer = input.Select(x =>
            {
                var split = x.Split(' ');
                return new Reindeer
                {
                    Name = split[0],
                    Speed = Convert.ToInt32(split[3]),
                    FlightTime = Convert.ToInt32(split[6]),
                    FlightTimeRemaining = Convert.ToInt32(split[6]),
                    RestTime = Convert.ToInt32(split[13]),
                    RestTimeRemaining = Convert.ToInt32(split[13]),
                };
            }).ToList();
        }

        public void Simulate(int time)
        {
            foreach (var i in Enumerable.Range(1, time))
            {
                foreach (var reindeer in _reindeer)
                {
                    reindeer.ProcessTurn();
                    Console.WriteLine(reindeer.Name + ": " + reindeer.Score);
                }

                foreach (var reindeer in _reindeer.Where(x => x.DistanceTraveled == _reindeer.Max(y => y.DistanceTraveled)))
                {
                    reindeer.Score++;
                }
            }
        }

        public int DistanceWinningReindeerHasTraveled()
        {
            return _reindeer.OrderByDescending(x => x.DistanceTraveled).First().DistanceTraveled;
        }

        public int WinningReindeerScore()
        {
            return _reindeer.OrderByDescending(x => x.Score).First().Score;
        }
    }

    internal class Reindeer
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int FlightTime { get; set; }
        public int RestTime { get; set; }
        public int DistanceTraveled { get; set; }
        public bool Flying { get; set; } = true;

        public int RestTimeRemaining { get; set; }
        public int FlightTimeRemaining { get; set; }

        public int Score { get; set; }

        public void ProcessTurn()
        {
            if (Flying)
            {
                DistanceTraveled += Speed;
                FlightTimeRemaining--;

                if (FlightTimeRemaining == 0)
                {
                    Flying = false;
                    RestTimeRemaining = RestTime;
                }
            }
            else
            {
                RestTimeRemaining--;
                if (RestTimeRemaining == 0)
                {
                    Flying = true;
                    FlightTimeRemaining = FlightTime;
                }
            }
        }
    }
}