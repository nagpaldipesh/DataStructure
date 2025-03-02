using System.Data.Common;

namespace DataStructurePractice.Mix.TicTacToe
{
    public class TicTacToe
    {
        private char[,] board;

        public TicTacToe()
        {
            board = new char[,]
            {
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' },
                { ' ', ' ', ' ' }
            };
        }

        public string CheckWinner()
        {
            //Check Row
            for (int i = 0; i < 3; i++) 
            {
                var result = CheckRow(i);
                if (result != ' ')
                {
                    return $"Player {result} Won"; 
                }
            }

            //Check Column
            for (int i = 0; i < 3; i++)
            {
                var result = CheckColumn(i);
                if (result != ' ')
                {
                    return $"Player {result} Won";
                }
            }

            //Check Diagonal
            var digonalResult = CheckDiagonal();
            if (digonalResult != ' ')
            {
                return $"Player {digonalResult} Won";
            }

            // Draw if all all places are occupied
            bool isDraw = true;

            //Check All boxes are filled
            for (int i = 0; i < 3;i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (board[i, j] ==  ' ')
                    {
                        isDraw = false;
                    }
                }
            }


            return isDraw ? "Draw" : "Ongoing";
        }

        public char CheckRow(int row)
        {
            for (int column = 1; column < 3; column++)
            {
                if (board[row, column] == ' ' || (board[row, column-1] != board[row, column]))
                {
                    return ' ';
                }
            }

            return board[row, 0];
        }

        public char CheckDiagonal()
        {
            for (int i = 1; i < 3; i++)
            {
                if (board[i,i] == ' ' || board[i,i] != board[i-1, i-1])
                {
                    return ' ';
                }
            }

            return board[0, 0];
        }

        public char CheckColumn(int column)
        {
            for (int row = 1; row < 3; row++)
            {
                if (board[row, column] == ' ' || (board[row -1, column] != board[row, column]))
                {
                    return ' ';
                }
            }

            return board[0, column];
        }

        public bool MakeMove(int row, int col, char player)
        {
            if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row,col] == ' ')
            {
                board[row, col] = player;
                return true;
            }

            return false;
        }
    }
}
