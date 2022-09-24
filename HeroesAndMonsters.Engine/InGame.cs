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
            char[,] board = new char[FieldConstants.RowSize,FieldConstants.ColumnSize];

            while (true)
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    char symb = FieldConstants.Symbol;

                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        board[row, col] = symb;
                    }
                }
                board[this.hero.Position.X, this.hero.Position.Y] = this.hero.Symbol;
                Cell oldCell = new Cell(this.hero.Position.X,this.hero.Position.Y);
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    Console.SetCursorPosition(FieldConstants.PositionX, FieldConstants.PositionY + i);
                    for (int z = 0; z < board.GetLength(1); z++)
                    {
                        Console.Write(board[i, z]);
                    }
                    Console.WriteLine();
                }
                this.GetDirection();
                if (direction == Direction.Up)
                {
                    this.hero.Position.X--;
                }
                else if (direction == Direction.Down)
                {
                    this.hero.Position.X++;
                }
                else if (direction == Direction.Left)
                {
                    this.hero.Position.Y--;
                }
                else if (direction == Direction.Right)
                {
                    this.hero.Position.Y++;
                }
                else if (direction == Direction.UpLeft)
                {
                    this.hero.Position.X--;
                    this.hero.Position.Y--;
                }
                else if (direction == Direction.UpRight)
                {
                    this.hero.Position.Y++;
                    this.hero.Position.X--;
                }
                else if (direction == Direction.DownLeft)
                {
                    this.hero.Position.Y--;
                    this.hero.Position.X++;
                }
                else if (direction == Direction.DownRight)
                {
                    this.hero.Position.X++;
                    this.hero.Position.Y++;
                }
                if (!IsInRange(board,this.hero.Position.X,this.hero.Position.Y))
                {
                    this.hero.Position.X = oldCell.X;
                    this.hero.Position.Y = oldCell.Y;
                }
            }

        }


        public static bool IsInRange(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
        private void GetDirection()
        {
            //Console.SetCursorPosition(this.hero.Position.X, this.hero.Position.Y);
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
        }
    }
}
