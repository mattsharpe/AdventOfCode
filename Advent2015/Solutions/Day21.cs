using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2015.Solutions
{
    class Day21
    {
        private readonly (string Name, int Cost, int Damage)[] weapons = new [] {
            ("Dagger",      8,  4),
            ("Shortsword",  10, 5),
            ("Warhammer",   25, 6),
            ("Longsword",   40, 7),
            ("Greataxe",    74, 8),
        };

        private readonly (string Name, int Cost, int Armour)[] armour = new[] {
            ("None",        0,      0),
            ("Leather",     13,     1),
            ("Chainmail",   31,     2),
            ("Splintmail",  53,     3),
            ("Bandedmail",  75,     4),
            ("Platemail",   102,    5),
        };

        private readonly (string Name, int Cost, int Damage, int Armour)[] rings = new[] {
            //two 'none' rings to account for not buying one
            ("None",        0,      0,  0),
            ("None",        0,      0,  0),
            ("Damage +1",   25,     1,  0),
            ("Damage +2",   50,     2,  0),
            ("Damage +3",   100,    3,  0),
            ("Defense +1",  20,     0,  1),
            ("Defense +2",  40,     0,  2),
            ("Defense +3",  80,     0,  3),
        };

        public Boss Boss { get; set; } = new Boss
        {
            HitPoints = 104,
            Damage = 8,
            Armour = 1
        };

        public IEnumerable<Fighter> GenerateCombinations()
        {
            var results = from weapon in weapons
            from shirt in armour
            from ring1 in rings
            from ring2 in rings.Where(x => x != ring1)
            select new Fighter
            {
                HitPoints = 100,
                Damage = weapon.Damage + ring1.Damage + ring2.Damage,
                Armour = shirt.Armour + ring1.Armour + ring2.Armour,
                Cost = weapon.Cost + shirt.Cost + ring1.Cost + ring2.Cost,
                Kit = $"{weapon.Name};{shirt.Name};{ring1.Name};{ring2.Name}"
            };

            return results;
        }

        public bool PlayerWins(Fighter fighter)
        {
            var bossDiesOnTurn = Math.Ceiling(Boss.HitPoints / (double) Math.Max(1, fighter.Damage - Boss.Armour));
            var playerDiesOnTurn = Math.Ceiling(fighter.HitPoints / (double) Math.Max(1, Boss.Damage - fighter.Armour));

            return playerDiesOnTurn >= bossDiesOnTurn;
        }

        public int MinimumSpendToWin()
        {
            return GenerateCombinations().Where(PlayerWins).Min(x => x.Cost);
        }

        public int Part2()
        {
            return GenerateCombinations().Where(x => !PlayerWins(x)).Max(x => x.Cost);
        }
    }

    class Fighter
    {
        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public int Armour { get; set; }
        public int Cost { get; set; }
        public string Kit { get; set; }
    }

    class Boss
    {
        public int HitPoints { get; set; }
        public int Damage { get; set; }
        public int Armour { get; set; }
    }
}
