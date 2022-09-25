using HeroesAndMonsters.Common;
using HeroesAndMonsters.Data.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndMonsters.Data.Models.Heroes
{
    public abstract class Hero : IHero, IRace
    {
        public Hero(int str, int agi, int intel, int range)
        {
            this.Strenght = str;

            this.Agility = agi;

            this.Intelligence = intel;

            this.Range = range;

            this.Position = new Cell(FieldConstants.PositionX, FieldConstants.PositionY);
        }

        public Cell Position { get; set; }

        public virtual char Symbol { get; set; }

        public int Strenght { get; set; }

        public int Agility { get; set; }

        public int Intelligence { get; set; }

        public int Range { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }

        public int DMG { get; set; }

        public bool IsDeath
            => this.HP == 0 ? true : false;

        public void Attack(Monster monster) 
        {
            monster.Health -= this.DMG;
            if (monster.Health < 0)
            {
                monster.Health = 0;
            }
        }

        public void Setup()
        {
            this.HP = this.Strenght * 5;
            this.MP = this.Intelligence * 3;
            this.DMG = this.Agility * 2;
        }
    }
}
