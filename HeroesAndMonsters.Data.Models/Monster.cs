using HeroesAndMonsters.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndMonsters.Data.Models
{
    public class Monster
    {
        public int Strength { get; set; }

        public int Agility { get; set; }

        public int Intelligence { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }

        public bool IsDeath
            => this.Health == 0 ? true : false;

        public char Symbol
            => FieldConstants.MonsterSymbol;

        public Cell Position { get; set; } = null!;

        public void StrengthGenerator()
        {
            Random random = new Random();

            this.Strength = random.Next(MonsterConstants.LowerBound, MonsterConstants.UpperBound);

            this.Agility = random.Next(MonsterConstants.LowerBound, MonsterConstants.UpperBound);

            this.Intelligence = random.Next(MonsterConstants.LowerBound, MonsterConstants.UpperBound);

            this.Health = this.Strength * 5;
            this.Mana = this.Intelligence * 3;
            this.Damage = this.Agility * 2;
        }

    }
}
