namespace HeroesAndMonsters.Data.Models
{
    using HeroesAndMonsters.Common;
    using System.Runtime.CompilerServices;

    public class Field
    {
        public Field(char[,] board)
        {
            this.Board = board;
        }
        public char[,] Board { get; set; }
        public void Creation(int heroX, int heroY, char heroSymbol, List<Monster> monsters)
        {


            for (int row = 0; row < this.Board.GetLength(0); row++)
            {
                char symb = FieldConstants.Symbol;

                for (int col = 0; col < this.Board.GetLength(1); col++)
                {
                    this.Board[row, col] = symb;
                }
            }
            foreach (var monster in monsters)
            {
                this.Board[monster.Position.X, monster.Position.Y] = FieldConstants.MonsterSymbol;
            }
            this.Board[heroX, heroY] = heroSymbol;
        }

        public Monster SpawnMonster()
        {
            Random random = new Random();

            Monster newMonster = new Monster();

            newMonster.StrengthGenerator();
            newMonster.Position = new Cell(random.Next(1, 10), random.Next(1, 10));

            this.Board[newMonster.Position.X, newMonster.Position.Y] = FieldConstants.MonsterSymbol;

            return newMonster;
        }

        public void Draw()
        {

            for (int i = 0; i < this.Board.GetLength(0); i++)
            {
                Console.SetCursorPosition(FieldConstants.PositionX, FieldConstants.PositionY + i);
                for (int z = 0; z < this.Board.GetLength(1); z++)
                {
                    Console.Write(this.Board[i, z]);
                }
                Console.WriteLine();
            }
        }
        public bool IsInRange(int row, int col)
        {
            return row >= 0 && row < this.Board.GetLength(0) && col >= 0 && col < this.Board.GetLength(1);
        }

        public bool RangeOfHero(int row, int col, int range)
        {
            for (int i = 1; i < range; i++)
            {

                if (this.Board[row + i, col] == FieldConstants.Symbol) //UP
                {
                    return false;
                }
                else if (this.Board[row - i, col] == FieldConstants.Symbol) //DOWN
                {
                    return false;
                }
                else if (this.Board[row, col - i] == FieldConstants.Symbol) //LEFT
                {
                    return false;
                }
                else if (this.Board[row, col + i] == FieldConstants.Symbol) //RIGHT
                {
                    return false;
                }
                else if (this.Board[row - i, col - i] == FieldConstants.Symbol) //DOWNLEFT
                {
                    return false;
                }
                else if (this.Board[row - i, col + i] == FieldConstants.Symbol) //DOWNRIGHT
                {
                    return false;
                }
                else if (this.Board[row + i, col - i] == FieldConstants.Symbol) //UPLEFT
                {
                    return false;
                }
                else if (this.Board[row - i, col + i] == FieldConstants.Symbol) //UPRIGHT
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
