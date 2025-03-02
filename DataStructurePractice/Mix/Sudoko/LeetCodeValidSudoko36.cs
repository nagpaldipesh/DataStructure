using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Mix.Sudoko
{
    public class LeetCodeValidSudoko36
    {
        public static void Execute()
        {
            char[][] board = new char[][] {
            new char[] { '.', '.', '.', '.', '5', '.', '.', '1', '.' },
            new char[] { '.', '4', '.', '3', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '3', '.', '.', '1' },
            new char[] { '8', '.', '.', '.', '.', '.', '.', '2', '.' },
            new char[] { '.', '.', '2', '.', '7', '.', '.', '.', '.' },
            new char[] { '.', '1', '5', '.', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '.', '.', '.', '2', '.', '.', '.' },
            new char[] { '.', '2', '.', '9', '.', '.', '.', '.', '.' },
            new char[] { '.', '.', '4', '.', '.', '.', '.', '.', '.' }
        };
            bool isValid = IsValidSudoku(board);
            Console.WriteLine(isValid ? "The Sudoku board is valid." : "The Sudoku board is not valid.");
        }

        static bool IsValidSudoku(char[][] board)
        {

            if (AreRowsOrColumnValid(board) && AreRowsOrColumnValid(board, false))
            {
                for (int i = 0; i < board[0].Length; i += 3)
                {
                    for (int j = 0; j < board[1].Length; j += 3)
                    {
                        if (!IsSubSudokuValid(board, i, j))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            return false;
        }

        static bool IsSubSudokuValid(char[][] board, int startRow, int startColumn)
        {

            for (int i = startRow; i < startRow + 3; i++)
            {

                HashSet<char> filledValues = new HashSet<char>();

                for (int j = startColumn; j < startColumn + 3; j++)
                {
                    char filledValue = board[i][j];

                    if (filledValue == '.')
                    {
                        continue;
                    }
                    else if (filledValues.Contains(filledValue))
                    {
                        return false;
                    }

                    filledValues.Add(filledValue);
                }
            }

            return true;
        }

        static bool AreRowsOrColumnValid(char[][] board, bool isRowsVerification = true)
        {

            for (int i = 0; i < board[0].Length; i++)
            {
                HashSet<char> filledValues = new HashSet<char>();
                for (int j = 0; j < board[1].Length; j++)
                {
                    char filledValue = isRowsVerification ? board[i][j] : board[j][i];

                    if (filledValue == '.')
                    {
                        continue;
                    }
                    else if (filledValues.Contains(filledValue))
                    {
                        return false;
                    }

                    filledValues.Add(filledValue);
                }

            }
            return true;
        }
    }
}
