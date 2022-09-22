using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndMonsters.Data.Models.Interface
{
    public interface IHero
    {
        string Name { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public int DMG { get; set; }

        public bool IsDeath { get; set; }

        public void Move();

        public void Attack();

    }
}
