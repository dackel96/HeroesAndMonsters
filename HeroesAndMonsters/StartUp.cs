using HeroesAndMonsters.Common;
using HeroesAndMonsters.Data;
using HeroesAndMonsters.Data.Models;
using HeroesAndMonsters.Data.Models.Heroes;
using HeroesAndMonsters.Engine;

public class StartUp
{
    private static void Main(string[] args)
    {
        //var db = new HeroesAndMonstersContext();
        //db.Database.EnsureCreated();

        //MainMenu menu = new MainMenu();
        //menu.Start();

        //CharacterSelect session = new CharacterSelect();

        //session.Select();

        //if (session.Hero != null)
        //{
        //    ImportLog(db, session.Hero);

        //    InGame game = new InGame(session.Hero);
        //    Console.Clear();
        //    game.Run();
        //}
        Hero testHero = new Mage(10, 10, 10, 3);
        testHero.Setup();
        InGame gameTest = new InGame(testHero);
        gameTest.Run();
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