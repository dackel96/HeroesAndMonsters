using HeroesAndMonsters.Common;

namespace HeroesAndMonsters.Data.Models
{
    public class Field
    {
        private int row;

        private int column;

        private char symbol;

        public Field()
        {
            this.row = FieldConstants.RowSize;

            this.column = FieldConstants.ColumnSize;

            this.symbol = FieldConstants.Symbol;
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            private set
            {
                this.row = value;
            }
        }

        public int Column
        {
            get
            {
                return this.column;
            }

            private set
            {
                this.column = value;
            }
        }

        public char Symbol
        {
            get
            {
                return this.symbol;
            }

            private set
            {
                this.symbol = value;
            }
        }

        public void Matrix()
        {
            char[,] board = new char[this.Row, this.Column];
            for (int row = 0; row < board.GetLength(0); row++)
            {
                char symb = this.Symbol;

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = symb;
                }
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.SetCursorPosition(50, 4 + i);
                for (int z = 0; z < board.GetLength(1); z++)
                {
                    Console.Write(board[i, z]);
                }
                Console.WriteLine();
            }
        }

        public static bool IsInRange(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
    }
}
