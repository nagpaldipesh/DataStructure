using Shouldly;

namespace DataStructurePractice.Mix
{
    public class Strobogrammatic
    {

        public static void Execute()
        {
            IsStrobogrammatic("69").ShouldBeTrue();
            IsStrobogrammatic("962").ShouldBeFalse();
        }

        static bool IsStrobogrammatic(string num)
        {
            int left = 0, right = num.Length - 1;

            Dictionary<char, char> mirrorMap = new Dictionary<char, char>()
            {
                { '0', '0' },
                { '1', '1' },
                { '6', '9' },
                { '8', '8' },
                { '9', '6' }
            };

            while (left < right)
            {
                if (!mirrorMap.ContainsKey(num[left]) ||
                    mirrorMap[num[left++]] != num[right])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
