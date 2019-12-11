using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2019.Solutions
{
    class Day10
    {
        private readonly HashSet<(int x, int y)> _asteroids = new HashSet<(int x, int y)>();

        public (int visibleAsteroids, int x, int y) BestLocationForStation(string[] input)
        {
            //build a list of asteroids co-ordinates
            for (var y = 0; y < input.Length; y++)
            {
                var line = input[y];
                for (var x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#')
                        _asteroids.Add((x, y));
                }
            }

            return _asteroids.Select(asteroid =>
                {
                    var count = NumberOfAsteroidsInSight(asteroid);
                    return (count, asteroid.x, asteroid.y);
                }).OrderByDescending(x => x.count)
                .First();
        }

        public int NumberOfAsteroidsInSight((int x, int y) station)
        {
            var angles = new HashSet<double>();
            foreach (var target in _asteroids)
            {
                if (station.x != target.x || station.y != target.y)
                {
                    angles.Add(Math.Atan2(target.y - station.y, target.x - station.x));
                }
            }

            return (angles.Count);
        }

        public List<(int x, int y)> FireTheLaserPewPew((int x, int y) station)
        {
            List<(int X, int Y, double angle, double distance)> targets = _asteroids.Select(target => 
                (
                    target.x, 
                    target.y,
                    Math.Atan2(target.y - station.y, target.x - station.x) * (180 / Math.PI), //convert rads to degrees
                    Math.Sqrt(Math.Pow(station.x - target.x, 2) + Math.Pow(station.y - target.y, 2)) //distance between them
                )).OrderBy(x=>x.Item3).ThenBy(x=>x.Item4).ToList();
            
            //get unique list of angles we need to hit
            var anglesToAttack = targets.Select(x => x.angle).ToHashSet().ToList();
            var currentAngleId = anglesToAttack.IndexOf(-90d);
            var destroyed = new List<(int x, int y)>();
            
            while (targets.Any())
            {
                var nextAngle = anglesToAttack[currentAngleId];
                if(targets.Exists(x => x.angle.Equals(nextAngle)))
                {
                    var targetAsteroid = targets.First(x => x.angle.Equals(nextAngle));
                    targets.Remove(targetAsteroid);
                    destroyed.Add((targetAsteroid.X,targetAsteroid.Y));
                }
                currentAngleId = currentAngleId < anglesToAttack.Count - 1 ? currentAngleId + 1 : 0;
            }

            return destroyed;
        }
    }
}