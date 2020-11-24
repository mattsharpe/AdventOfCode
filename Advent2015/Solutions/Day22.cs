using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Advent2015.Solutions
{
    class Day22
    {
        public ReadOnlyCollection<Spell> Grimoire = new List<Spell>
        {
            new Spell("Magic Missile", 53, damage: 4),
            new Spell("Drain", 73, damage: 2, heal: 2),
            new Spell("Shield", 113, armour: 7, duration: 6),
            new Spell("Poison", 173, damage: 3, duration: 6),
            new Spell("Recharge", 229, mana: 101, duration: 5),
        }.AsReadOnly();


        public GameState LeastAmountOfManaToWin(GameState state)
        {
            var explore = new Queue<GameState>();
            explore.Enqueue(state);

            var bestOption = new GameState {ManaSpent = int.MaxValue};

            while (explore.Count > 0)
            {
                var currentState = explore.Dequeue();
                var spells = AvailableSpells(currentState);
                foreach (var spell in spells)
                {
                    var newGameState = (GameState) currentState.Clone();
                    var result = newGameState.ProcessTurn(spell);

                    if (result == null && newGameState.ManaSpent < bestOption.ManaSpent)
                    {
                        explore.Enqueue(newGameState);
                    }
                    else if (result == true && newGameState.ManaSpent < bestOption.ManaSpent)
                    {
                        bestOption = newGameState;
                        Console.WriteLine($"New best option {bestOption.ManaSpent}, left to explore {explore.Count}");
                        explore = new Queue<GameState>(explore.Where(x => x.ManaSpent < newGameState.ManaSpent));
                        Console.WriteLine($"Pruned states : {explore.Count}");
                    }
                }
            }

            return bestOption;
        }

        public IEnumerable<Spell> AvailableSpells(GameState state)
        {
            return Grimoire.Where(x =>
            {
                return state.PlayerMana >= x.Cost &&
                       state.ActiveSpells.Where(s => s.Value > 1).All(s => s.Key.Name != x.Name);
            });
        }
    }

    public class Spell
    {
        public Spell(string name, int cost, int damage = 0, int heal = 0, int armour = 0, int mana = 0,
            int duration = 0)
        {
            Name = name;
            Cost = cost;
            Damage = damage;
            Heal = heal;
            Armour = armour;
            Mana = mana;
            Duration = duration;
        }

        public string Name { get; }
        public int Cost { get; }
        public int Damage { get; }
        public int Heal { get; }
        public int Armour { get; }
        public int Mana { get; }
        public int Duration { get; }
    }

    public class GameState : ICloneable
    {
        public int ManaSpent { get; set; }
        public int PlayerHitPoints { get; set; }
        public int PlayerMana { get; set; }
        public int BossHitPoints { get; set; }
        public int BossDamage { get; set; }
        public bool Debug { get; set; }
        public Dictionary<Spell, int> ActiveSpells = new Dictionary<Spell, int>();

        public List<Spell> SpellChain { get; set; } = new List<Spell>();

        private int PlayerArmour => ActiveSpells.Any(x => x.Key.Name == "Shield") ? 7 : 0;
        public bool Hard { get; set; }


        public object Clone()
        {
            return new GameState
            {
                ManaSpent = ManaSpent,
                PlayerHitPoints = PlayerHitPoints,
                PlayerMana = PlayerMana,
                BossDamage = BossDamage,
                BossHitPoints = BossHitPoints,
                Debug = Debug,
                Hard = Hard,
                ActiveSpells = new Dictionary<Spell, int>(ActiveSpells),
                SpellChain = new List<Spell>(SpellChain),
            };
        }


        public bool? ProcessTurn(Spell spell)
        {
            //Player Goes First
            Log("-- Player Turn --");
            if (Hard)
            {
                PlayerHitPoints--;
            }

            LogState();

            ProcessActiveSpells();
            //if no HP or mana left player loses
            if (PlayerHitPoints <= 0 || PlayerMana < 53) return false;

            CastSpell(spell);
            if (BossHitPoints <= 0)
            {
                Log("This kills the boss, and the player wins");
                return true;
            }

            Log("");

            //Boss Turn
            Log("-- Boss Turn --");
            LogState();

            ProcessActiveSpells();
            if (BossHitPoints <= 0)
            {
                Log("This kills the boss, and the player wins");
                return true;
            }

            BossAttack();
            if (PlayerHitPoints <= 0) return false;
            Log("");

            return null;
        }

        private void BossAttack()
        {
            PlayerHitPoints -= (BossDamage - PlayerArmour);

            Log(PlayerArmour > 0
                ? $"Boss attacks for {BossDamage} - {PlayerArmour} = {BossDamage - PlayerArmour} damage!"
                : $"Boss attacks for {BossDamage} damage!");
        }


        public void ProcessActiveSpells()
        {
            foreach (var spell in ActiveSpells.Keys.ToList())
            {
                ApplyEffects(spell);
                ActiveSpells[spell]--;

                if (ActiveSpells[spell] == 0)
                {
                    Log($"{spell.Name} wears off");
                    ActiveSpells.Remove(spell);
                }
            }
        }

        private void LogState()
        {
            //Log($"- Player has {PlayerHitPoints} hit points, {PlayerArmour} armor, {PlayerMana} mana");
            //Log($"- Boss has {BossHitPoints} hit points");
        }

        private void Log(string message)
        {
            if (Debug)
            {
                Console.WriteLine(message);
            }
        }

        public void ApplyEffects(Spell spell)
        {
            BossHitPoints -= spell.Damage;
            PlayerHitPoints += spell.Heal;
            PlayerMana += spell.Mana;

            if (!Debug) return;

            switch (spell.Name)
            {
                case "Poison":
                    Log($"{spell.Name} deals {spell.Damage} damage. It's timer is now {ActiveSpells[spell] - 1}");
                    break;
                case "Recharge":
                    Log($"{spell.Name} provides {spell.Mana} mana; its timer is now  {ActiveSpells[spell] - 1}");
                    break;
                case "Shield":
                    Log($"{spell.Name} timer is now  {ActiveSpells[spell] - 1}");
                    break;
            }
        }

        public void CastSpell(Spell spell)
        {
            SpellChain.Add(spell);
            ManaSpent += spell.Cost;
            PlayerMana -= spell.Cost;

            if (spell.Duration > 0)
            {
                Log($"Player casts {spell.Name}.");
                ActiveSpells.Add(spell, spell.Duration);
            }
            else
            {
                ApplyEffects(spell);
                if (!Debug) return;
                switch (spell.Name)
                {
                    case "Magic Missile":
                        Log($"Player casts Magic Missile, dealing {spell.Damage} damage.");
                        break;
                    case "Drain":
                        Log(
                            $"Player casts {spell.Name}, dealing {spell.Damage} damage, and healing {spell.Heal} hit points");
                        break;
                }
            }
        }
    }
}