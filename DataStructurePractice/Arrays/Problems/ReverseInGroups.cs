
namespace DataStructurePractice.Arrays.Problems
{
    public class ReverseArrayInGroups
    {
        public int[] ReverseInGroups(int[] arr, int k)
        {
            int low = 0, high = k - 1, endIndex = k - 1;

            if (k > arr.Length)
            {
                high = arr.Length - 1;
                endIndex = arr.Length - 1;
            }

            while (low < high && high < arr.Length)
            {
                while (low < high)
                {
                    int temp = arr[low];
                    arr[low++] = arr[high];
                    arr[high--] = temp;
                }
                low = endIndex + 1;
                endIndex += k;
                high = Math.Min(endIndex, arr.Length - 1);
            }

            return arr;
        }
    }
}
