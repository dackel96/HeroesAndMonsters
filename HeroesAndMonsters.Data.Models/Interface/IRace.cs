using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndMonsters.Data.Models.Interface
{
    public interface IRace
    {
        public int Strenght { get; set; }

        public int Agility { get; set; }

        public int Intelligence { get; set; }

        public int Range { get; set; }

        public void Setup();
    }
}
