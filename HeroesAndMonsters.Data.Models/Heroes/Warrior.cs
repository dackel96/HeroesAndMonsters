using HeroesAndMonsters.Common;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndMonsters.Data.Models.Heroes
{
    public class Warrior : Hero
    {
        public Warrior(int str, int agi, int intel, int range) 
            : base(str, agi, intel, range)
        {
        }
        public override char Symbol
            => FieldConstants.WarriorSymbol;
    }
}
