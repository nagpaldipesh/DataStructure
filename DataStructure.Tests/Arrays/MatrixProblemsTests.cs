using DataStructurePractice.Arrays;
using Shouldly;

namespace DataStructure.Tests.Arrays
{
    [TestFixture]
    internal class MatrixProblemsTests
    {
        [Test]
        public void Test_Square_Matrix_3x3_TransposeMatrix()
        {
            int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

            int[,] expected = {
            {1, 4, 7},
            {2, 5, 8},
            {3, 6, 9}
        };

            MatrixProblems.TransposeMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Square_Matrix_4x4_TransposeMatrix()
        {
            int[,] matrix = {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 16}
        };

            int[,] expected = {
            {1, 5, 9, 13},
            {2, 6, 10, 14},
            {3, 7, 11, 15},
            {4, 8, 12, 16}
        };

            MatrixProblems.TransposeMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Single_Element_Matrix_TransposeMatrix()
        {
            int[,] matrix = { { 1 } };
            int[,] expected = { { 1 } };

            MatrixProblems.TransposeMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Two_By_Two_Matrix_TransposeMatrix()
        {
            int[,] matrix = {
                {1, 2},
                {3, 4}
            };

            int[,] expected = {
                {1, 3},
                {2, 4}
            };

            MatrixProblems.TransposeMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Square_Matrix_3x3_ReverseRows()
        {
            int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

            int[,] expected = {
            {3, 2, 1},
            {6, 5, 4},
            {9, 8, 7}
        };

            MatrixProblems.ReverseRowsInMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Square_Matrix_4x4_ReverseRows()
        {
            int[,] matrix = {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 16}
        };

            int[,] expected = {
            {4, 3, 2, 1},
            {8, 7, 6, 5},
            {12, 11, 10, 9},
            {16, 15, 14, 13}
        };

            MatrixProblems.ReverseRowsInMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Single_Element_Matrix_ReverseRows()
        {
            int[,] matrix = { { 1 } };
            int[,] expected = { { 1 } };

            MatrixProblems.ReverseRowsInMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Two_By_Two_Matrix_ReverseRows()
        {
            int[,] matrix = {
            {1, 2},
            {3, 4}
        };

            int[,] expected = {
            {2, 1},
            {4, 3}
        };

            MatrixProblems.ReverseRowsInMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Rectangular_Matrix_ReverseRows()
        {
            int[,] matrix = {
            {1, 2, 3, 4, 5},
            {6, 7, 8, 9, 10}
        };

            int[,] expected = {
            {5, 4, 3, 2, 1},
            {10, 9, 8, 7, 6}
        };

            MatrixProblems.ReverseRowsInMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Square_Matrix_3x3()
        {
            int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

            int[,] expected = {
            {7, 4, 1},
            {8, 5, 2},
            {9, 6, 3}
        };

            MatrixProblems.RotateMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Square_Matrix_4x4()
        {
            int[,] matrix = {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 16}
        };

            int[,] expected = {
            {13, 9, 5, 1},
            {14, 10, 6, 2},
            {15, 11, 7, 3},
            {16, 12, 8, 4}
        };

            MatrixProblems.RotateMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Two_By_Two_Matrix()
        {
            int[,] matrix = {
            {1, 2},
            {3, 4}
        };

            int[,] expected = {
            {3, 1},
            {4, 2}
        };

            MatrixProblems.RotateMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Single_Element_Matrix()
        {
            int[,] matrix = { { 1 } };
            int[,] expected = { { 1 } };

            MatrixProblems.RotateMatrix(matrix).ShouldBe(expected);
        }

        [Test]
        public void Test_Matrix_With_Single_Zero()
        {
            int[,] matrix = {
            {1, 2, 3},
            {4, 0, 6},
            {7, 8, 9}
        };

            int[,] expected = {
            {1, 0, 3},
            {0, 0, 0},
            {7, 0, 9}
        };

            MatrixProblems.ZeroMatrix(matrix);
            matrix.ShouldBe(expected);
        }

        [Test]
        public void Test_Matrix_With_Zero_In_First_Row_And_Column()
        {
            int[,] matrix = {
            {0, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

            int[,] expected = {
            {0, 0, 0},
            {0, 5, 6},
            {0, 8, 9}
        };

            MatrixProblems.ZeroMatrix(matrix);
            matrix.ShouldBe(expected);
        }

        [Test]
        public void Test_Matrix_With_Zero_In_Last_Row_And_Column()
        {
            int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 0}
        };

            int[,] expected = {
            {1, 2, 0},
            {4, 5, 0},
            {0, 0, 0}
        };

            MatrixProblems.ZeroMatrix(matrix);
            matrix.ShouldBe(expected);
        }

        [Test]
        public void Test_Matrix_With_All_Zeros()
        {
            int[,] matrix = {
            {0, 0, 0},
            {0, 0, 0},
            {0, 0, 0}
        };

            int[,] expected = {
            {0, 0, 0},
            {0, 0, 0},
            {0, 0, 0}
        };

            MatrixProblems.ZeroMatrix(matrix);
            matrix.ShouldBe(expected);
        }

        [Test]
        public void Test_Matrix_With_No_Zeros()
        {
            int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

            int[,] expected = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

            MatrixProblems.ZeroMatrix(matrix);
            matrix.ShouldBe(expected);
        }
    }
}
