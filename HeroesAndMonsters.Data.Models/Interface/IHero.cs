using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndMonsters.Data.Models.Interface
{
    public interface IHero
    {
        public int HP { get; set; }

        public int MP { get; set; }

        public int DMG { get; set; }

        public bool IsDeath { get;}

        public void Move();

        public void Attack();

    }
}
