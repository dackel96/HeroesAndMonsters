using HeroesAndMonsters.Common;
using HeroesAndMonsters.Data.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesAndMonsters.Engine
{
    public class CharacterSelect
    {
        public void Select()
        {
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("Choose character type:");

            Console.SetCursorPosition(50, 3);
            Console.WriteLine("       Options:");

            Console.SetCursorPosition(50, 5);
            Console.WriteLine("    1) Warrior");

            Console.SetCursorPosition(50, 6);
            Console.WriteLine("    2) Archer");

            Console.SetCursorPosition(50, 7);
            Console.WriteLine("    3) Mage");

            Console.SetCursorPosition(50, 9);
            Console.Write("    Your pick: ");

            ConsoleKeyInfo read = Console.ReadKey(true);

            if (read.KeyChar.ToString() == "1")
            {
                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine(">>>WARRIOR<<<");
                Hero warrior = new Warrior(WarriorConstants.BaseSTR,WarriorConstants.BaseAGI,WarriorConstants.BaseINT,WarriorConstants.BaseRange);
                this.BuffUp();
            }
            else if (read.KeyChar.ToString() == "2")
            {
                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine(">>>ARCHER<<<");
                Hero archer = new Archer(ArcherConstants.BaseSTR, ArcherConstants.BaseAGI, ArcherConstants.BaseINT, ArcherConstants.BaseRange);
                this.BuffUp();
            }
            else if (read.KeyChar.ToString() == "3")
            {
                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine(">>>MAGE<<<");
                Hero mage = new Mage(MageConstants.BaseSTR, MageConstants.BaseAGI, MageConstants.BaseINT, MageConstants.BaseRange);
                this.BuffUp();
            }
        }

        public void BuffUp()
        {
            Console.SetCursorPosition(30, 1);
            Console.WriteLine("Would you like to buff up your stats before starting?");

            Console.SetCursorPosition(47, 3);
            Console.WriteLine("(Limit: 3 points total)");

            Console.SetCursorPosition(47, 5);
            Console.WriteLine("Response ( Y | N ):");
            ConsoleKeyInfo read = Console.ReadKey(true);

            if (read.KeyChar.ToString().ToUpper() == "Y")
            {
                Console.Clear();
               
                Console.SetCursorPosition(50, 1);
                Console.WriteLine("Remaining Points: 3");

                Console.SetCursorPosition(50, 3);
                Console.WriteLine("Add to Strenght:");
                Console.SetCursorPosition(68, 3);
                read = Console.ReadKey(true);
                int strPlus = int.Parse(read.KeyChar.ToString());

                Console.SetCursorPosition(50, 4);
                Console.WriteLine("Add to Agility:");
                Console.SetCursorPosition(65, 4);
                read = Console.ReadKey(true);
                int agiPlus = int.Parse(read.KeyChar.ToString());

                Console.SetCursorPosition(50, 5);
                Console.WriteLine("Add to Intelligence:");
                Console.SetCursorPosition(75, 5);
                read = Console.ReadKey(true);
                int intPlus = int.Parse(read.KeyChar.ToString());
            }
            else if (read.KeyChar.ToString().ToUpper() == "N")
            {
                InGame game = new InGame();
                game.Run();
            }
        }
    }
}
