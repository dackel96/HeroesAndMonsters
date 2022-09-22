namespace HeroesAndMonsters.Engine
{
    public class MainMenu
    {
        public void Start()
        {
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("       Welcome!");

            Console.SetCursorPosition(50, 2);
            Console.WriteLine("......................");

            Console.SetCursorPosition(50, 3);
            Console.WriteLine("Press any key to play.");

            Console.ReadKey(true);
            Console.Clear();
        }
    }
}