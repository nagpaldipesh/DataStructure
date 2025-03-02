//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using DataStructurePractice.Graph;
using DataStructurePractice.Graph.Problems.Knight;
using DataStructurePractice.LinkedList;
using DataStructurePractice.Mix;
using DataStructurePractice.Mix.Calender;
using DataStructurePractice.Mix.KVendor;
using DataStructurePractice.Mix.Monster;
using DataStructurePractice.Mix.NoticeBoard;
using DataStructurePractice.Mix.Serialize_and_Deserialize_an_N_ary_Tree;
using DataStructurePractice.Mix.Sudoko;
using DataStructurePractice.Mix.TrappingRainWater;
using DataStructurePractice.Recursion;
using DataStructurePractice.Recursion.Problems;
using DataStructurePractice.Stack;

class Program {

    public static void Main(String[] args) {

        //RunRecurssionMidAlgo();

        //RunRecurssionAdvanceAlgo();

        //RecursionMidLevel.TowerOfHanoi(3, "source", "helper", "destination");

        //Console.WriteLine("Test");
        N_aryTree.Execute();
        //int[] arr = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        //var result = MaximumWaterWithoutWall(arr);

        //int[] arr = { 5, 1, 4, 3, 6, 8, 10, 7, 9 };
        //var result = FindPeekElement(arr);

        //Console.WriteLine("Result: " + result);
    }

    public static void RunRecurssionAdvanceAlgo() {
        RecurssionAdvanceLevel obj = new RecurssionAdvanceLevel();

        string str = "abc";
        obj.PrintPermutationsOfString(str.ToCharArray(), 0);
    }

    static List<int> GetEmployeeFreeTime(List<List<int>> schedules)
    {
        List<int[]> intervals = new List<int[]>();

        foreach (var schedule in schedules)
        {
            for (int i = 0; i < schedule.Count; i = i + 2)
            {
                int[] interval = new int[] 
                { 
                    schedule[i],
                    schedule[i +1]
                };

                intervals.Add(interval);
            }
        }

        intervals.Sort((a, b) => a[0].CompareTo(b[0]));

        List<int> result= new List<int>();
        int end = 0;

        foreach (var interval in intervals)
        {
            if (interval[0] > end)
            {
                result.Add(end);
                result.Add(interval[0]);

                end = interval[1] + 1;
            }
        }
        
        if(end < 100000000)
        {
            result.Add(end + 1);
            result.Add(100000000);
        }

        return result;
    }

    public static void RunRecurssionEasyAlgo() {
        //RecursionEasy obj = new RecursionEasy();

        //obj.PrintNaturalNumbers(10);

        //int sum = obj.PrintSumOfNaturalNumbers(5);
        //Console.WriteLine("Sum = " + sum);

        //int factorial = obj.PrintFactorial(10);
        //Console.WriteLine("Factorial = " + factorial);


        //obj.PrintFibonacciSequence(10, 0, 1);

        //var result = obj.GetNumberExponential(5, 8);
        //Console.WriteLine(result);
    }

    public static void RunRecurssionMidAlgo() {
        //int numOfDiscs = 4;
        //RecursionMidLevel.TowerOfHanoi(numOfDiscs, "source", "helper", "destination");
        //string str = "Hello Baby";

        //var reverseString = RecursionMidLevel.ReverseString(str);

        //Console.WriteLine($"reverseString is {reverseString}");

        //RecursionMidLevel.PrintReverseString(str, str.Length - 1);

        RecursionMidLevel obj = new RecursionMidLevel();

        //string str = "asdasffajasfhhas";
        //Console.WriteLine($"string is {str} and Length is {str.Length}");
        //obj.CheckFirstAndLastOccuOfElement(str, 's');

        //int[] numbers = { 1, 45, 54, 65, 768, 878, 8755 };

        //var isSorted = obj.IsArraySortedAcending(numbers);

        //Console.WriteLine(isSorted);

        //var str = "adasfafsfaw";
        //var newstr = obj.PlaceElementsAtEnd(str, 'f', 0);
        //Console.WriteLine(newstr);

        var str = "aaa";
        //var newStr = obj.RemoveDuplicateCharacters(str, 0);
        //Console.WriteLine(newStr);

        //obj.PrintAllSubsequence(str, 0);

        //Console.WriteLine("Unique");
        //obj.PrintUniqueSubsequence(str, 0);

        obj.PrintKeypadCombinations("4", 0);
    }


    public static int FindPeekElement(int[] arr) {
        int peekElement = -1;

        for (int index = 1; index < arr.Length - 1; index++) {

            bool isTrue = true;

            for (int innerIndex = 0; innerIndex < index; innerIndex++) {
                if (arr[innerIndex] >= arr[index]) {
                    isTrue = false;
                    break;
                }
            }
            if (isTrue) {
                for (int innerIndex = index + 1; innerIndex < arr.Length; innerIndex++) {
                    if (arr[innerIndex] <= arr[index]) {
                        isTrue = false;
                        break;
                    }
                }

                if (isTrue) {
                    peekElement = arr[index];
                    break;
                }
            }
        }

        return peekElement;
    }

    public static int MaximumWaterWithoutWall(int[] arr) {
        int maximumWater = -1;

        for (int index = 0; index < arr.Length; index++) {

            for (int innerIndex = index + 1; innerIndex < arr.Length; innerIndex++) {
                int indexDiff = innerIndex - index;

                int maximumWaterAllowedPerWall = arr[index] < arr[innerIndex] ? arr[index] : arr[innerIndex];
                int waterCapacity = indexDiff * maximumWaterAllowedPerWall;

                if (waterCapacity > maximumWater) {
                    maximumWater = waterCapacity;
                }
            }
        }

        //int biggestNumber = 0;
        //int biggestNumberIndex = 0;
        //for (int index = 0; index < arr.Length; index++) {
        //    if (index > biggestNumber) {
        //        biggestNumber = arr[index];
        //        biggestNumberIndex = index;
        //    }
        //}

        //for (int index = biggestNumberIndex; index < arr.Length; index++) {

        //    int indexDiff = index - biggestNumberIndex;

        //    int waterCapacity = arr[index] * indexDiff;

        //    if(waterCapacity > maximumWater) {
        //        maximumWater = waterCapacity;
        //    }
        //}
        return maximumWater;
    }

    //public static int MaximumWaterWithWall(int[] arr) {
    //    int maximumWater = -1;

    //}
}