using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructurePractice.Mix.Sudoko
{
    public class CheckSudokoConfiguration
    {

        public static void Execute()
        {
            int[,] mat = { { 9, 3, 0, 0, 7, 0, 0, 0, 0 },
                        { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                        { 0, 5, 8, 0, 0, 0, 0, 6, 0 },
                        { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                        { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                        { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                        { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                        { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                        { 0, 0, 0, 0, 8, 0, 0, 7, 9 } };
            IsSudokoConfigurationValid(mat).ShouldBeTrue();

            int[,] mat1 = {
    { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
    { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
    { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
    { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
    { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
    { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
    { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
    { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
    { 3, 4, 5, 2, 8, 6, 1, 7, 9 }
};

            // Expected Output: true
            IsSudokoConfigurationValid(mat1).ShouldBeTrue();

            int[,] mat2 = {
    { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
    { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
    { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
    { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
    { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
    { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
    { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
    { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
    { 3, 4, 5, 2, 8, 6, 1, 7, 5 } // Duplicate 5 in the last row
};

            // Expected Output: false
            IsSudokoConfigurationValid(mat2).ShouldBeFalse();

            int[,] mat3 = {
    { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
    { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
    { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
    { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
    { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
    { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
    { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
    { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
    { 3, 4, 5, 2, 8, 6, 1, 7, 9 },
    { 5, 9, 5, 0, 0, 0, 0, 6, 0 } // Duplicate 5 in the first column
};

            // Expected Output: false
            IsSudokoConfigurationValid(mat3).ShouldBeFalse();

            int[,] mat4 = {
    { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
    { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
    { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
    { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
    { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
    { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
    { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
    { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
    { 2, 0, 0, 0, 0, 0, 0, 6, 0 } // Duplicate 2 in the first 3x3 subgrid
};

            // Expected Output: false
            IsSudokoConfigurationValid(mat4).ShouldBeFalse();

            int[,] mat5 = new int[,] 
            { 
                { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                { 0, 0, 0, 0, 8, 0, 0, 7, 9 } 
            };

            IsSudokoConfigurationValid(mat5).ShouldBeTrue();

        }

        static bool IsSudokoConfigurationValid(int[,] subokoBoard)
        {
            if (AreRowsValid(subokoBoard) && AreColumnValid(subokoBoard))
            {
                for (int i = 0; i < subokoBoard.GetLength(0); i += 3)
                {
                    for (int j = 0; j < subokoBoard.GetLength(1); j += 3)
                    {
                        if (!IsSubSudokoValid(subokoBoard, i, j))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            return false;
        }

        static bool IsSubSudokoValid(int[,] subokoBoard, int startRow, int startCol)
        {

            for (int i = startRow; i < startRow + 3; i++)
            {
                HashSet<int> set = new HashSet<int>();

                for (int j = startCol; j < startCol + 3; j++)
                {
                    int val = subokoBoard[i, j];

                    if (val == 0)
                    {
                        continue;
                    }
                    else if (set.Contains(val))
                    {
                        return false;
                    }

                    set.Add(val);
                }
            }

            return true;
        }

        static bool AreColumnValid(int[,] subokoBoard)
        {
            for (int i = 0; i < subokoBoard.GetLength(0); i++)
            {
                HashSet<int> set = new HashSet<int>();

                for (int j = 0; j < subokoBoard.GetLength(1); j++)
                {
                    int val = subokoBoard[j, i];

                    if (val == 0)
                    {
                        continue;
                    }
                    else if (set.Contains(val))
                    {
                        return false;
                    }
                    set.Add(val);
                }
            }

            return true;
        }

        static bool AreRowsValid(int[,] sudokoBoard)
        {

            for (int i = 0; i < sudokoBoard.GetLength(0); i++)
            {
                HashSet<int> set = new HashSet<int>();

                for (int j = 0; j < sudokoBoard.GetLength(1); j++)
                {
                    int val = sudokoBoard[i, j];

                    if (val == 0)
                    {
                        continue;
                    }
                    else if (set.Contains(val))
                    {
                        return false;
                    }
                    set.Add(val);
                }
            }

            return true;
        }
    }
}


