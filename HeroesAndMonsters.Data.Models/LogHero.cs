using HeroesAndMonsters.Data.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndMonsters.Data.Models
{
    public class LogHero
    {
        public int Id { get; set; }

        public string HeroRace { get; set; } = null!;

        public int Strenght { get; set; }

        public int Agility { get; set; }

        public int Intelligence { get; set; }

        public int Range { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public int DMG { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
