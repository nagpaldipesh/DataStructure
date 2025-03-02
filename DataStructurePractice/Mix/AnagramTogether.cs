using Shouldly;
using System.Linq;

namespace DataStructurePractice.Mix
{
    public class AnagramTogether
    {

        public static void Execute()
        {
            string[] arr = { "act", "god", "cat", "dog", "tac" };
            List<List<string>> expectedResult = new List<List<string>>()
            {
                new List<string>() { "act", "cat", "tac" },
                new List<string>() { "god", "dog" }
            };
            GetAnagrams(arr).ShouldBe(expectedResult);

            string[] arr2 = { "no", "on", "is" };
            List<List<string>> expectedResult2 = new List<List<string>>()
            {
                new List<string>() { "no", "on" },
                new List<string>() { "is" },

            };
            GetAnagrams(arr2).ShouldBe(expectedResult2);

            string[] arr3 = { "listen", "silent", "enlist", "abc", "cab", "bac", "rat", "tar", "art" };
            List<List<string>> expectedResult3 = new List<List<string>>()
            {
                new List<string>() { "listen", "silent", "enlist" },
                new List<string>() { "abc", "cab", "bac" },
                new List<string>() { "rat", "tar", "art" }
            };
            GetAnagrams(arr3).ShouldBe(expectedResult3);

        }

        static List<List<string>> GetAnagrams(string[] arr)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

            foreach (string str in arr)
            {
                string key = string.Concat(str.OrderBy(o => o));

                if (dict.ContainsKey(key))
                {
                    dict[key].Add(str);
                }
                else
                {
                    dict.Add(key, new List<string>() { str });
                }
            }

            return dict.Values.ToList();

            //var anagramsList = new List<List<String>>();

            //foreach (var str in arr)
            //{
            //    bool isAdded = false;

            //    foreach (var anagrams in anagramsList)
            //    {
            //        var anagram = anagrams.First();

            //        if(string.Concat(str.OrderBy(o => o)) == string.Concat(anagram.OrderBy(o => o)))
            //        {
            //            isAdded = true;
            //            anagrams.Add(str);
            //            break;
            //        }
            //    }

            //    if(!isAdded)
            //    {
            //        anagramsList.Add(new List<string> { str });
            //    }
            //}

            //return anagramsList;
        }
    }
}
