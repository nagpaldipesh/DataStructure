using Shouldly;

namespace DataStructurePractice.Recursion.Problems
{
    public class CheckGivenArrayIsSorted
    {
        public static void Execute()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            IsArraySorted(arr).ShouldBeTrue();

            int[] arr2 = { 1, 2, 7, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            IsArraySorted(arr2).ShouldBeFalse();

        }

        static bool IsArraySorted(int[] arr)
        {
            return IsArraySorted(arr, 0);
        }

        static bool IsArraySorted(int[] arr, int index)
        {
            if (arr == null || arr.Length < 1)
                return false;

            if (index == arr.Length - 1)
                return true;

            if (arr[index] > arr[index + 1])
            {
                return false;
            }

            return IsArraySorted(arr, index + 1);
        }
    }
}
