namespace HeroesAndMonsters.Engine
{
    using HeroesAndMonsters.Common;
    using HeroesAndMonsters.Data.Models.Heroes;
    public class CharacterSelect
    {
        private Hero? hero;

        private int addStr;

        private int addAgi;

        private int addInt;

        public Hero? Hero
        {
            get
            {
                return this.hero;
            }
            private set
            {
                this.hero = value;
            }
        }

        public int AddStr
        {
            get
            {
                return this.addStr;
            }
            private set
            {
                this.addStr = value;
            }
        }

        public int AddAgi
        {
            get
            {
                return this.addAgi;
            }
            private set
            {
                this.addAgi = value;
            }
        }

        public int AddInt
        {
            get
            {
                return this.addInt;
            }
            private set
            {
                this.addInt = value;
            }
        }

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
                this.hero = new Warrior(WarriorConstants.BaseSTR, WarriorConstants.BaseAGI, WarriorConstants.BaseINT, WarriorConstants.BaseRange);
                this.BuffUp();
            }
            else if (read.KeyChar.ToString() == "2")
            {
                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine(">>>ARCHER<<<");
                this.hero = new Archer(ArcherConstants.BaseSTR, ArcherConstants.BaseAGI, ArcherConstants.BaseINT, ArcherConstants.BaseRange);
                this.BuffUp();
            }
            else if (read.KeyChar.ToString() == "3")
            {
                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine(">>>MAGE<<<");
                this.hero = new Mage(MageConstants.BaseSTR, MageConstants.BaseAGI, MageConstants.BaseINT, MageConstants.BaseRange);
                this.BuffUp();
            }
        }

        public void BuffUp()
        {
            Console.Clear();
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

                    Console.SetCursorPosition(50, 3);
                    Console.WriteLine("Add to Strenght:");

                    Console.SetCursorPosition(50, 4);
                    Console.WriteLine("Add to Agility:");

                    Console.SetCursorPosition(50, 5);
                    Console.WriteLine("Add to Intelligence:");
                    if (flagSTR && buttonSTR)
                    {
                        buttonSTR = false;
                        Console.SetCursorPosition(67, 3);
                        read = Console.ReadKey();
                        if (read.KeyChar != '1' && read.KeyChar != '2' && read.KeyChar != '3' && read.KeyChar != '0')
                        {
                            Console.Clear();
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine($"You can add only positive number which is not above 3");
                            Console.SetCursorPosition(50, 9);
                            Console.WriteLine("Go back to BuffUp ( Y | N ):");
                            read = Console.ReadKey(true);
                            if (read.KeyChar.ToString().ToUpper() == "Y")
                            {
                                this.BuffUp();
                            }
                            break;
                        }
                        int strPlus = int.Parse(read.KeyChar.ToString());

                        if (strPlus == 3)
                        {
                            flagSTR = false;
                            buttonSTR = false;
                        }
                        if (strPlus > points)
                        {
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine($"You have only {points} points remaining!!");
                            continue;
                        }
                        else
                        {
                            points -= strPlus;
                            this.addStr += strPlus;
                            continue;
                        }
                    }
                    if (flagAGI && buttonAGI)
                    {
                        buttonAGI = false;

                        
                        Console.SetCursorPosition(66, 4);
                        read = Console.ReadKey();
                        if (read.KeyChar != '1' && read.KeyChar != '2' && read.KeyChar != '3' && read.KeyChar != '0')
                        {
                            Console.Clear();
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine($"You can add only positive number which is not above 3");
                            Console.SetCursorPosition(50, 9);
                            Console.WriteLine("Go back to BuffUp ( Y | N ):");
                            read = Console.ReadKey(true);
                            if (read.KeyChar.ToString().ToUpper() == "Y")
                            {
                                this.BuffUp();
                            }
                            break;
                        }
                        int agiPlus = int.Parse(read.KeyChar.ToString());
                        if (agiPlus == 3)
                        {
                            flagAGI = false;
                        }
                        if (agiPlus > points)
                        {
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine($"You have only {points} points remaining!");
                            continue;
                        }
                        else
                        {
                            points -= agiPlus;
                            this.addAgi += agiPlus;
                            continue;
                        }
                    }
                    if (flagINT && buttonINT)
                    {
                        buttonINT = false;
                        
                        Console.SetCursorPosition(71, 5);
                        read = Console.ReadKey();
                        if (read.KeyChar != '1' && read.KeyChar != '2' && read.KeyChar != '3' && read.KeyChar != '0')
                        {
                            Console.Clear();
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine($"You can add only positive number which is not above 3");
                            Console.SetCursorPosition(50, 9);
                            Console.WriteLine("Go back to BuffUp ( Y | N ):");
                            read = Console.ReadKey(true);
                            if (read.KeyChar.ToString().ToUpper() == "Y")
                            {
                                this.BuffUp();
                            }
                            break;
                        }
                        int intPlus = int.Parse(read.KeyChar.ToString());
                        if (intPlus == 3)
                        {
                            flagINT = false;
                        }
                        if (intPlus > points)
                        {
                            Console.SetCursorPosition(50, 7);
                            Console.WriteLine($"You have only {points} points remaining!");
                            continue;
                        }
                        else
                        {
                            points -= intPlus;
                            this.addInt += intPlus;
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
                    Console.Clear();
                }
                if (points != 0)
                {
                    if (this.Hero != null)
                    {
                        this.Hero.Setup();
                    }
                    Console.WriteLine("No added stats!");
                    Console.WriteLine("To Start press any key!");
                    Console.ReadKey(true);
                }
                
                if (this.Hero != null)
                {
                    this.Hero.Strenght += this.AddStr;
                    this.Hero.Agility += this.AddAgi;
                    this.Hero.Intelligence += this.AddInt;

                    this.Hero.Setup();
                }

                Console.Clear();
                Console.SetCursorPosition(50, 1);
                Console.WriteLine("Successfully added stats!");
                Console.SetCursorPosition(50, 2);
                Console.WriteLine("To Start press any key!");
                Console.ReadKey(true);
            }
            else if (read.KeyChar.ToString().ToUpper() == "N")
            {
                if (this.Hero != null)
                {
                    this.Hero.Setup();
                }

                Console.Clear();
                Console.SetCursorPosition(50, 1);
                Console.WriteLine("No added stats!");
                Console.WriteLine("To Start press any key!");
                Console.ReadKey(true);
            }
        }
    }
}
