using HeroesAndMonsters.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndMonsters.Data.Models.Heroes
{
    public class Mage : Hero
    {
        public Mage(int str, int agi, int intel, int range) 
            : base(str, agi, intel, range)
        {
        }
        public override char Symbol
            => FieldConstants.MageSymbol;
    }
}
