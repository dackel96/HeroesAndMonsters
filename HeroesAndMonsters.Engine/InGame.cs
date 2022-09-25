using HeroesAndMonsters.Common;
using HeroesAndMonsters.Data.Models;
using HeroesAndMonsters.Data.Models.Enums;
using HeroesAndMonsters.Data.Models.Heroes;
using System.Reflection.Metadata.Ecma335;

namespace HeroesAndMonsters.Engine
{
    public class InGame
    {
        private Direction direction;

        private Dictionary<Direction, Cell> position;

        private Hero hero;

        private Monster monster;

        public InGame(Hero hero)
        {
            this.position = new Dictionary<Direction, Cell>()
            {
                {Direction.None,new Cell(0,0) },

                {Direction.Up,new Cell(0,-1) },

                {Direction.Down,new Cell(0,1) },

                 {Direction.Left,new Cell(-1,0) },

                {Direction.Right,new Cell(1,0) },

                {Direction.UpRight,new Cell(1,-1) },

                {Direction.UpLeft,new Cell(-1,-1) },

                {Direction.DownLeft,new Cell(-1,1) },

                {Direction.DownRight,new Cell(1,1) },
            };

            this.monster = new Monster();

            this.hero = hero;

            this.Board = new char[FieldConstants.RowSize, FieldConstants.ColumnSize];

            this.Field = new Field(this.Board);

            this.Monsters = new List<Monster>();
        }

        public char[,] Board { get; set; }

        public Field Field { get; set; }

        public List<Monster> Monsters { get; set; }

        public void Run()
        {

            while (true)
            {
                Monster newMonster = this.Field.SpawnMonster();

                this.Monsters.Add(newMonster);

                Console.SetCursorPosition(0, 0);

                Console.WriteLine($"Health: {this.hero.HP}    Mana: {this.hero.MP}");

                this.Field.Creation(this.hero.Position.X, this.hero.Position.Y, this.hero.Symbol, this.Monsters);

                position[Direction.None].X = this.hero.Position.X;
                position[Direction.None].Y = this.hero.Position.Y;

                this.Field.Draw();

                this.Decision();


            }

        }

        public void Decision()
        {
            Console.SetCursorPosition(0, 12);
            Console.WriteLine("Choose Action");
            Console.SetCursorPosition(0, 14);
            Console.WriteLine("1) Attack");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("2) Move");
            ConsoleKeyInfo read = Console.ReadKey(true);
            if (read.KeyChar.ToString() == "1")
            {
                if (this.Field.RangeOfHero(this.hero.Position.X, this.hero.Position.Y, this.hero.Range))
                {
                    Console.SetCursorPosition(0, 17);
                    Console.WriteLine("No available targets in your range");
                }
                else
                {
                    if (this.Monsters.FirstOrDefault() != null)
                    {
                        Monster monster = this.Monsters.First();
                        this.hero.Attack(monster);
                        if (monster.IsDeath)
                        {
                            this.Monsters.Remove(monster);
                        }
                    }
                }
            }
            else if (read.KeyChar.ToString() == "2")
            {
                this.GetDirection();

                if (!this.Field.IsInRange(this.hero.Position.X, this.hero.Position.Y))
                {
                    this.hero.Position.X = position[Direction.None].X;
                    this.hero.Position.Y = position[Direction.None].Y;
                }
            }
            else
            {
                this.Decision();
            }
        }

        private void GetDirection()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.KeyChar.ToString().ToUpper() == "A")
            {
                direction = Direction.Left;
            }

            else if (keyInfo.KeyChar.ToString().ToUpper() == "D")
            {
                direction = Direction.Right;
            }

            else if (keyInfo.KeyChar.ToString().ToUpper() == "W")
            {
                direction = Direction.Up;
            }

            else if (keyInfo.KeyChar.ToString().ToUpper() == "S")
            {
                direction = Direction.Down;
            }

            else if (keyInfo.KeyChar.ToString().ToUpper() == "Q")
            {
                direction = Direction.UpLeft;
            }

            else if (keyInfo.KeyChar.ToString().ToUpper() == "E")
            {
                direction = Direction.UpRight;
            }

            else if (keyInfo.KeyChar.ToString().ToUpper() == "Z")
            {
                direction = Direction.DownLeft;
            }

            else if (keyInfo.KeyChar.ToString().ToUpper() == "X")
            {
                direction = Direction.DownRight;
            }

            else
            {
                this.GetDirection();
            }

            if (direction == Direction.Up)
            {
                this.hero.Position.X -= this.hero.Range;
            }

            else if (direction == Direction.Down)
            {
                this.hero.Position.X += this.hero.Range;
            }

            else if (direction == Direction.Left)
            {
                this.hero.Position.Y -= this.hero.Range;
            }

            else if (direction == Direction.Right)
            {
                this.hero.Position.Y += this.hero.Range;
            }

            else if (direction == Direction.UpLeft)
            {
                this.hero.Position.X -= this.hero.Range;
                this.hero.Position.Y -= this.hero.Range;
            }

            else if (direction == Direction.UpRight)
            {
                this.hero.Position.Y += this.hero.Range;
                this.hero.Position.X -= this.hero.Range;
            }

            else if (direction == Direction.DownLeft)
            {
                this.hero.Position.Y -= this.hero.Range;
                this.hero.Position.X += this.hero.Range;
            }

            else if (direction == Direction.DownRight)
            {
                this.hero.Position.X += this.hero.Range;
                this.hero.Position.Y += this.hero.Range;
            }
        }
    }
}
