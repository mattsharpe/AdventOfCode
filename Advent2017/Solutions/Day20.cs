using System.Numerics;
using System.Text.RegularExpressions;

namespace Advent2017.Solutions
{
    internal class Day20
    {

        public int Part1(string[] input)
        {
            var particles = ParseInput(input);

            return particles.OrderBy(p => p.Acceleration.LengthSquared())
                            .ThenBy(p => p.Velocity.LengthSquared())
                            .ThenBy(p => p.Position.LengthSquared())
                            .First().Id;
        }

        public int Part2(string[] input) {

            var particles = ParseInput(input);
            SimulateParticlesWithCollisions(particles, 1000);
            return particles.Count;
        }

        public List<Particle> ParseInput(string[] input)
        {
            return Enumerable.Zip(input, Enumerable.Range(0, input.Length), ParseLine).ToList();
        }

        public Particle ParseLine(string line, int id)
        {
            var numbers = Regex.Matches(line, "-?\\d+").Select(x => int.Parse(x.Value)).ToArray();

            return new Particle(id,
                            new Vector3(numbers[0], numbers[1], numbers[2]),
                            new Vector3(numbers[3], numbers[4], numbers[5]),
                            new Vector3(numbers[6], numbers[7], numbers[8]));
        }

        private void SimulateParticlesWithCollisions(List<Particle> particles, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                var positionMap = new Dictionary<Vector3, List<Particle>>();

                foreach (var particle in particles)
                {
                    particle.Velocity += particle.Acceleration;
                    particle.Position += particle.Velocity;

                    if (!positionMap.TryGetValue(particle.Position, out List<Particle> value))
                    {
                        value = ([]);
                        positionMap[particle.Position] = value;
                    }

                    value.Add(particle);
                }

                foreach (var group in positionMap.Values.Where(g => g.Count > 1))
                {
                    foreach (var particle in group)
                    {
                        particles.Remove(particle);
                    }
                }
            }
        }
    }

    record Particle(int Id, Vector3 Position, Vector3 Velocity, Vector3 Acceleration)
    {
        public Vector3 Position { get; set; } = Position;
        public Vector3 Velocity { get; set; } = Velocity;
        public Vector3 Acceleration { get; set; } = Acceleration;
    }
}
