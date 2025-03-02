
namespace DataStructurePractice.Arrays.Problems
{
    public class CheckIsArrayRotatedAndSorted
    {
        //Check array is rotated or sorted in increasing or decreasing order
        public bool CheckArrayIsRotatedAndSorted(int[] arr)
        {
            int countIncreasing = 0, countDecreasing = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    countIncreasing++;
                }
                else if (arr[i] < arr[i - 1])
                {
                    countDecreasing++;
                }
            }

            if (countIncreasing == 1)
            {
                if (arr[0] < arr[arr.Length - 1])
                {
                    return true;
                }
            }

            if (countDecreasing == 1)
            {
                if (arr[0] > arr[arr.Length - 1])
                {
                    return true;
                }
            }

            return false;
            //if (arr == null || arr.Length <= 2)
            //{
            //    return false;
            //}

            //var direction = GetDirection(arr);

            //switch (direction)
            //{
            //    case Direction.Accending:
            //        // No rotation 1, 2, 3, 4, 5
            //        if (arr[0] < arr[arr.Length - 1])
            //            return false;
            //        return CheckAccendingArrayIsRotatedOrSorted(arr);

            //    case Direction.Decending:
            //        // No rotation 5, 4, 3, 2, 1 
            //        if (arr[0] > arr[arr.Length - 1]) { return false; }
            //        return CheckDecendingArrayIsRotatedOrSorted(arr);
            //}

            //return true;
        }

        private bool CheckAccendingArrayIsRotatedOrSorted(int[] arr)
        {
            bool isRotated = false;

            // 8, 9, 10, 1, 2, 5, 3
            for (int i = 1; i < arr.Length; i++)
            {
                if (!isRotated && arr[i] < arr[i - 1])
                {
                    isRotated = true;
                }
                else if (isRotated && arr[i] < arr[i - 1])
                {
                    return false;
                }
            }

            return isRotated;
        }
        private bool CheckDecendingArrayIsRotatedOrSorted(int[] arr)
        {
            bool isRotated = false;

            // 10, 9, 8, 14, 13, 12
            for (int i = 1; i < arr.Length; i++)
            {
                if (!isRotated && arr[i] > arr[i - 1])
                {
                    isRotated = true;
                }
                else if (isRotated && arr[i] > arr[i - 1])
                {
                    return false;
                }
            }

            return isRotated;
        }

        private Direction GetDirection(int[] arr)
        {
            /// 3, 2, 1, 5, 4 
            if (arr[0] < arr[arr.Length - 1] && arr[arr.Length - 2] > arr[arr.Length - 1])
            {
                return Direction.Decending;
            }

            return Direction.Accending;
        }
    }

    public enum Direction
    {
        Accending,
        Decending
    }
}
