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
        public void Creation(int heroX, int heroY, char heroSymbol)
        {


            for (int row = 0; row < this.Board.GetLength(0); row++)
            {
                char symb = FieldConstants.Symbol;

                for (int col = 0; col < this.Board.GetLength(1); col++)
                {
                    this.Board[row, col] = symb;
                }
            }

            this.Board[heroX, heroY] = heroSymbol;
        }

        public void Draw()
        {
            Random random = new Random();

            int monsterRow = random.Next(1, 10);

            int monsterCol = random.Next(1, 10);

            this.Board[monsterRow, monsterCol] = FieldConstants.MonsterSymbol;

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
    }
}
