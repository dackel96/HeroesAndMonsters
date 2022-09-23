using HeroesAndMonsters.Data;
using HeroesAndMonsters.Data.Models;
using HeroesAndMonsters.Data.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndMonsters.Engine
{
    public class InGame
    {
        public void Run()
        {
            var db = new HeroesAndMonstersContext();
            db.Database.EnsureCreated();

            CharacterSelect session = new CharacterSelect();
            session.Select();

            Console.Clear();

            Field board = new Field();
            //50 , 0
            board.Matrix();

            if (session.Hero != null)
            {
                ImportLog(db,session.Hero);
            }

            Console.ReadKey(true);


        }

        public static void ImportLog(HeroesAndMonstersContext context, Hero hero)
        {
            LogHero newLog = new LogHero()
            {
                HeroRace = hero.GetType().Name.ToString(),
                Strenght = hero.Strenght,
                Agility = hero.Agility,
                Intelligence = hero.Intelligence,
                Range = hero.Range,
                HP = hero.HP,
                MP = hero.MP,
                DMG = hero.DMG,
                CreationTime = DateTime.UtcNow
            };
            context.Add(newLog);
            context.SaveChanges();
        }
    }
}
