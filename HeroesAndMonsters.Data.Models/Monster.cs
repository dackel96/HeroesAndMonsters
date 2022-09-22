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

        public void StrengthGenerator()
        {
            Random random = new Random();

            this.Strength = random.Next(MonsterConstants.LowerBound,MonsterConstants.UpperBound);

            this.Agility = random.Next(MonsterConstants.LowerBound, MonsterConstants.UpperBound);

            this.Intelligence = random.Next(MonsterConstants.LowerBound, MonsterConstants.UpperBound);
        }

    }
}
