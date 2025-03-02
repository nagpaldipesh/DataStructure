
namespace DataStructurePractice.Arrays
{
    public class MatrixProblems
    {
        // Given an image represented by N*N matrix, where each pixel in the image is 4 bytes. Write an method to rotate the image by 90 degree. Can you please do inplace.

        //
        public static int[,] RotateMatrix(int[,] matrix)
        {
            var transformMatrix = TransposeMatrix(matrix);

            return ReverseRowsInMatrix(transformMatrix);
        }

        public static int[,] ReverseRowsInMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(1);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) / 2; j++)
                {
                    (matrix[i, j], matrix[i, n - j -1]) = (matrix[i, n - j -1], matrix[i, j]);
                }
            }

            //while (i < matrix.Length && j < matrix.Length)
            //{
            //    int temp = matrix[i, j];
            //    matrix[i, j] = matrix[i, j - i];
            //    matrix[i, j - i] = temp;

            //    j++;

            //    if (j == matrix.Length)
            //    {
            //        i++;
            //        j = 0;
            //    }
            //}

            return matrix;
        }

        // convert row to column
        public static int[,] TransposeMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n ; j++)
                {
                    (matrix[i, j], matrix[j, i]) = (matrix[j, i], matrix[i, j]);
                }
            }
            //while (i < matrix.GetLength(0) && j < matrix.GetLength(0))
            //{
            //    int temp = matrix[i, j];
            //    matrix[i, j] = matrix[j, i];
            //    matrix[j, i] = temp;

            //    j++;

            //    if (j == matrix.GetLength(0))
            //    {
            //        i++;
            //        j = i;
            //    }
            //}

            return matrix;
        }

        public static int[,] ZeroMatrix(int[,] matrix)
        {
            HashSet<int> columnIndexWithZero = new HashSet<int> { };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0 && !columnIndexWithZero.Contains(j))
                    {
                        columnIndexWithZero.Add(j);
                    }
                }
            }

            foreach (int columnIndex in columnIndexWithZero)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    // Row update
                    matrix[columnIndex, j] = 0;

                    //Column Update
                    matrix[j, columnIndex] = 0;
                }
            }

            return matrix;
        }
    }
}
