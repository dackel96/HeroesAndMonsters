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

        private int addStr;

        private int addAgi;

        private int addInt;

        public Hero Hero { get; private set; } = null!;
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
                this.Hero = new Warrior(WarriorConstants.BaseSTR, WarriorConstants.BaseAGI, WarriorConstants.BaseINT, WarriorConstants.BaseRange);
                this.BuffUp();
            }
            else if (read.KeyChar.ToString() == "2")
            {
                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine(">>>ARCHER<<<");
                this.Hero = new Archer(ArcherConstants.BaseSTR, ArcherConstants.BaseAGI, ArcherConstants.BaseINT, ArcherConstants.BaseRange);
                this.BuffUp();
            }
            else if (read.KeyChar.ToString() == "3")
            {
                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine(">>>MAGE<<<");
                this.Hero = new Mage(MageConstants.BaseSTR, MageConstants.BaseAGI, MageConstants.BaseINT, MageConstants.BaseRange);
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

                int points = 3;

                bool flagSTR = true;

                bool flagAGI = true;

                bool flagINT = true;

                bool buttonSTR = true;

                bool buttonAGI = true;

                bool buttonINT = true;
                while (points != 0)
                {
                    Console.SetCursorPosition(50, 1);
                    Console.WriteLine($"Remaining Points: {points}");
                    if (flagSTR && buttonSTR)
                    {
                        buttonSTR = false;
                        Console.SetCursorPosition(50, 3);
                        Console.WriteLine("Add to Strenght:");
                        Console.SetCursorPosition(68, 3);
                        read = Console.ReadKey();
                        int strPlus = int.Parse(read.KeyChar.ToString());
                        if (strPlus == 3)
                        {
                            flagSTR = false;
                            buttonSTR = false;
                        }
                        if (strPlus > 3 || strPlus < 0)
                        {
                            Console.WriteLine($"You have only {points} remaining!");
                            continue;
                        }
                        else
                        {
                            points -= strPlus;
                            continue;
                        }
                    }
                    if (flagAGI && buttonAGI)
                    {
                        buttonAGI = false;

                        Console.SetCursorPosition(50, 4);
                        Console.WriteLine("Add to Agility:");
                        Console.SetCursorPosition(65, 4);
                        read = Console.ReadKey();
                        int agiPlus = int.Parse(read.KeyChar.ToString());
                        if (agiPlus == 3)
                        {
                            flagAGI = false;
                        }
                        if (agiPlus > 3 || agiPlus < 0)
                        {
                            Console.WriteLine($"You have only {points} remaining!");
                            continue;
                        }
                        else
                        {
                            points -= agiPlus;
                            continue;
                        }
                    }
                    if (flagINT && buttonINT)
                    {
                        buttonINT = false;
                        Console.SetCursorPosition(50, 5);
                        Console.WriteLine("Add to Intelligence:");
                        Console.SetCursorPosition(75, 5);
                        read = Console.ReadKey();
                        int intPlus = int.Parse(read.KeyChar.ToString());
                        if (intPlus == 3)
                        {
                            flagINT = false;
                        }
                        if (intPlus > 3 || intPlus < 0)
                        {
                            Console.WriteLine($"You have only {points} remaining!");
                            continue;
                        }
                        else
                        {
                            points -= intPlus;
                            continue;
                        }
                    }
                    if (points != 0)
                    {
                        buttonSTR = true;
                        buttonAGI = true;
                        buttonINT = true;
                        Console.Clear();
                    }
                }

                this.Hero.Strenght += this.addStr;
                this.Hero.Agility += this.addAgi;
                this.Hero.Intelligence += this.addInt;

                Console.Clear();
                Console.SetCursorPosition(50, 1);
                Console.WriteLine("Successfully added stats!");
                Console.SetCursorPosition(50, 2);
                Console.WriteLine("To Start press any key!");
                Console.ReadKey(true);

            }
            else if (read.KeyChar.ToString().ToUpper() == "N")
            {
                Console.Clear();
                Console.SetCursorPosition(50, 1);
                Console.WriteLine("No added stats!");
                Console.WriteLine("To Start press any key!");
                Console.ReadKey(true);
            }
        }
    }
}
