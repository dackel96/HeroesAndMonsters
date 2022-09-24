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

        private Field map;

        private Monster monster;

        public InGame(Field map, Hero hero)
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

            this.map = map;

            this.monster = new Monster();

            this.hero = hero;
        }

        public void Run()
        {
            while (true)
            {
                int row = 0;
                int col = 0;
                map.Draw(this.map.Matrix);
                Console.SetCursorPosition(this.hero.Position.X, this.hero.Position.Y);
                Console.WriteLine(this.hero.Symbol);
                this.GetDirection();
                if (TryMove())
                {
                    if (direction == Direction.Up)
                    {
                        this.hero.Position.Y -= this.position[direction].Y;
                    }
                    if (direction == Direction.Down)
                    {
                        this.hero.Position.Y += this.position[direction].Y;
                    }
                    if (direction == Direction.Left)
                    {
                        this.hero.Position.X -= this.position[direction].X;
                    }
                    if (direction == Direction.Right)
                    {
                        this.hero.Position.X += this.position[direction].X;
                    }
                    if (direction == Direction.UpLeft)
                    {
                        this.hero.Position.X -= this.position[direction].X;
                        this.hero.Position.Y -= this.position[direction].Y;
                    }
                    if (direction == Direction.UpRight)
                    {
                        this.hero.Position.X += this.position[direction].X;
                        this.hero.Position.Y -= this.position[direction].Y;
                    }
                    if (direction == Direction.DownLeft)
                    {
                        this.hero.Position.X -= this.position[direction].X;
                        this.hero.Position.Y += this.position[direction].Y;
                    }
                    if (direction == Direction.DownRight)
                    {
                        this.hero.Position.X += this.position[direction].X;
                        this.hero.Position.Y += this.position[direction].Y;
                    }
                }
            }

        }


        public static bool IsInRange(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }

        private bool TryMove()
        {

            if (IsInRange(this.map.Matrix, hero.Position.X, hero.Position.Y))
            {
                return true;
            }
            return false;
        }

        private void GetDirection()
        {
            Console.SetCursorPosition(this.hero.Position.X, this.hero.Position.Y);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.KeyChar.ToString().ToUpper() == "A")
            {
                direction = Direction.Left;
            }
            if (keyInfo.KeyChar.ToString().ToUpper() == "D")
            {
                direction = Direction.Right;
            }
            if (keyInfo.KeyChar.ToString().ToUpper() == "W")
            {
                direction = Direction.Up;
            }
            if (keyInfo.KeyChar.ToString().ToUpper() == "S")
            {
                direction = Direction.Down;
            }
            if (keyInfo.KeyChar.ToString().ToUpper() == "Q")
            {
                direction = Direction.UpLeft;
            }
            if (keyInfo.KeyChar.ToString().ToUpper() == "E")
            {
                direction = Direction.UpRight;
            }
            if (keyInfo.KeyChar.ToString().ToUpper() == "Z")
            {
                direction = Direction.DownLeft;
            }
            if (keyInfo.KeyChar.ToString().ToUpper() == "X")
            {
                direction = Direction.DownRight;
            }
        }
    }
}
