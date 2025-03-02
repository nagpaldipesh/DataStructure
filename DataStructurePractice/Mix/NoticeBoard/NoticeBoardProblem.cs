using Shouldly;

namespace DataStructurePractice.Mix.NoticeBoard
{
    public class NoticeBoardProblem
    {

        public static void Execute()
        {
            var notices = new List<int[]> { new int[] { 5, 15 }, new int[] { 16, 18 }, new int[] { 12, 20 } };

            GetNoticeBoardResult(notices).ShouldBe(2);

            var notices2 = new List<int[]> { new int[] { 1, 5 }, new int[] { 6, 10 }, new int[] { 2, 7 } };
            GetNoticeBoardResult(notices2).ShouldBe(2);

            var notices3 = new List<int[]> { new int[] { 1, 3 }, new int[] { 2, 4 }, new int[] { 5, 6 } };
            GetNoticeBoardResult(notices3).ShouldBe(2);

            var notices4 = new List<int[]> { new int[] { 5, 15 }, new int[] { 12, 20 } };

            GetNoticeBoardResult(notices).ShouldBe(2);
        }

        static int GetNoticeBoardResult(List<int[]> notices)
        {
            notices.Sort((a, b) => a[0].CompareTo(b[0]));
            
            int visibleCount = 0;
            int currentEnd = 0;

            foreach (var notice in notices)
            {
                int left = notice[0], right = notice[1];

                if (left > currentEnd)
                {
                    // A new visible notice starts
                    visibleCount++;
                    currentEnd = Math.Max(currentEnd, right);
                }
            }

            if (notices[notices.Count - 1][1] > currentEnd)
            {
                visibleCount++;
            }

            return visibleCount;
        }
    }
}
