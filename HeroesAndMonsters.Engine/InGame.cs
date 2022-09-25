using HeroesAndMonsters.Common;
using HeroesAndMonsters.Data.Models;
using HeroesAndMonsters.Data.Models.Enums;
using HeroesAndMonsters.Data.Models.Heroes;

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
        }

        public void Run()
        {
            char[,] board = new char[FieldConstants.RowSize, FieldConstants.ColumnSize];

            Field field = new Field(board);

            while (true)
            {
                Console.SetCursorPosition(0, 0);

                Console.WriteLine($"Health: {this.hero.HP}    Mana: {this.hero.MP}");

                field.Creation(this.hero.Position.X, this.hero.Position.Y, this.hero.Symbol);

                Cell oldCell = new Cell(this.hero.Position.X, this.hero.Position.Y);

                field.Draw();

                this.GetDirection();

                if (!field.IsInRange(this.hero.Position.X, this.hero.Position.Y))
                {
                    this.hero.Position.X = oldCell.X;
                    this.hero.Position.Y = oldCell.Y;
                } 
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
                if (true)
                {
                    Console.SetCursorPosition(0, 17);
                    Console.WriteLine("No available targets in your range");
                }
                else
                {
                    this.hero.Attack();
                }
            }
            else if (read.KeyChar.ToString() == "2")
            {
                
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
