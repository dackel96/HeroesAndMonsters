using HeroesAndMonsters.Common;
using HeroesAndMonsters.Data.Models;
using HeroesAndMonsters.Data.Models.Heroes;
using HeroesAndMonsters.Engine;

public class StartUp
{
    private static void Main(string[] args)
    {
        MainMenu menu = new MainMenu();
        menu.Start();

        InGame game = new InGame();
        game.Run();
    }
}