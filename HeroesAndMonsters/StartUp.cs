using HeroesAndMonsters.Common;
using HeroesAndMonsters.Data.Models;
using HeroesAndMonsters.Data.Models.Heroes;

public class StartUp
{
    private static void Main(string[] args)
    {
        //Field newBoard = new Field();
        //
        //newBoard.Matrix();

        //Hero war = new Warrior(WarriorConstants.BaseSTR, WarriorConstants.BaseAGI, WarriorConstants.BaseINT, WarriorConstants.BaseRange);
        //war.Setup();
        //Console.WriteLine($"{war.HP} {war.MP} {war.DMG}");

        Monster mon = new Monster();

        mon.StrengthGenerator();

        Console.WriteLine(mon.Strength);

        Console.WriteLine(mon.Agility);

        Console.WriteLine(mon.Intelligence);
    }
}