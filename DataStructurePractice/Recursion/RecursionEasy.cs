    namespace DataStructurePractice.Recursion {
    internal class RecursionEasy {

        public  int GetNumberExponential(int num, int exponent) {
            if (exponent == 1)
                return num;

            return num * GetNumberExponential(num, --exponent);
        }

        public  void PrintNaturalNumbers(int num) {

            if (num == 0)
                return;

            Console.WriteLine(num);

            PrintNaturalNumbers(num - 1);
        }

        public  int PrintSumOfNaturalNumbers(int num) {

            if (num == 0)
                return num;

            Console.WriteLine(num);

            return num + PrintSumOfNaturalNumbers(num - 1);
        }

        public  int PrintFactorial(int num) {
            if (num == 0 || num == 1)
                return 1;

            if (num == 2)
                return num;

            return num * PrintFactorial(num - 1);
        }

        public  void PrintFibonacciSequence(int n, int x, int y) {
            Console.WriteLine(x);
            Console.WriteLine(y);

            PrintNextFibonacciNumber(n, x, y);
        }

        public  void PrintNextFibonacciNumber(int n, int x, int y) {
            if (n == 0)
                return;

            int fibonachiNumber = x + y;

            Console.WriteLine(fibonachiNumber);
            PrintNextFibonacciNumber(n - 1, y, fibonachiNumber);
        }
    }
}
